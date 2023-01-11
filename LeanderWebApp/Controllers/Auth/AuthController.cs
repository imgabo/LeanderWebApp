using LeanderWebApp.Data.Auth;
using LeanderWebApp.Model;
using LeanderWebApp.Model.Auth;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;

namespace LeanderWebApp.Controllers.Auth
{
    [EnableCors("corspolicy")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {

        private ConsultaAuth consulta = new ConsultaAuth(); 
        private ConsultaAuth auth = new ConsultaAuth();

        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult ListCuentas()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;


            var list = consulta.ListCuentas();
            return Ok(list);
        }



        #region registro
        [HttpPost]
        public IActionResult Register(Usuario usuario , string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] salt);
            usuario.password = passwordHash;
            usuario.salt = salt;
            var insert = auth.Register(usuario);
            return Ok(insert);  
        }


        #endregion

        #region login

        [HttpPost]
        public IActionResult Login(Login request)
        {
            try
            {
                Usuario cuenta = (Usuario)auth.Login(request.Email);

                if (string.IsNullOrEmpty(cuenta.email))
                {
                    return BadRequest("Email Incorrecto");
                }

                //if (cuenta.vigente != 1)
                //{
                //    return BadRequest("Tu usuario no se encuentra vigente");
                //}

                if (!VerifyPasswordHash(request.Password, cuenta.password, cuenta.salt))
                {
                    return BadRequest("Clave Incorrecta");
                }

                string token = CreateToken(cuenta);
                return Ok(token);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        #endregion





        #region metodos de encriptacion password y salt

        private string CreateToken(Usuario user)
        {
            List<Claim> claims = new List<Claim> { };
            var options = new JsonSerializerOptions { WriteIndented = true };
            claims.Add(new Claim("data", JsonSerializer.Serialize<Usuario>(user)));

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:Key").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }





        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));


            }
        }


        #endregion

    }
}
