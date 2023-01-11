using LeanderWebApp.Model;
using MySqlConnector;
using System.Data;

namespace LeanderWebApp.Data.Auth
{
    public class ConsultaAuth
    {
        private ParametrosConfiguracion ParametrosConfiguracion = new ParametrosConfiguracion("MySqlConnection");


        // solo para listar y probar la api
        public object ListCuentas()
        {
            try
            {
                Success success = new Success();
                var procedure = "proc_listar_usuarios";
                using ( MySqlConnection conexion = new MySqlConnection(ParametrosConfiguracion.getConexionString()))
                { 
                    conexion.Open();    
                    MySqlCommand cmd = new MySqlCommand(procedure, conexion);   
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read()) 
                    {
                        success.Numero = 200;
                        success.Resultado = reader["JsonResponse"].ToString();
                        
                    }
                    return success;
                }
            }
            catch   (Exception e) 
            {
                Errors error = new Errors();
                error.Message = e.Message;
                return error;

            }
        }


        #region registro

        public object Register(Usuario usuario)
        {
            try
            {
                Success success = new Success();
                var procedure = "proc_insert_usuario";
                using (MySqlConnection conexion = new MySqlConnection(ParametrosConfiguracion.getConexionString()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(procedure, conexion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@u_nombre", usuario.nombre);
                    cmd.Parameters.AddWithValue("@u_apellido", usuario.apellido);
                    cmd.Parameters.AddWithValue("@u_cedula_identidad", usuario.cedula_identidad);
                    cmd.Parameters.AddWithValue("@u_nombre_banco", usuario.nombre_banco);
                    cmd.Parameters.AddWithValue("@u_numero_cuenta", usuario.numero_cuenta);
                    cmd.Parameters.AddWithValue("@u_numero_telefono", usuario.numero_telefono);
                    cmd.Parameters.AddWithValue("@u_email", usuario.email);
                    cmd.Parameters.AddWithValue("@u_password", usuario.password);
                    cmd.Parameters.AddWithValue("@u_salt", usuario.salt);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        success.Numero = 200;
                        success.Resultado = reader["JsonResponse"].ToString();
                    }
                    conexion.Close();
                    return success;
                }
            }
            catch (Exception e)
            {
                Errors error = new Errors();
                error.Message = e.Message;
                return error;
            }
        }

        #endregion


        #region login
        public object Login(string email)
        {

            try
            {
                Usuario cuenta = new Usuario();
                var procedure = "proc_select_by_correo";
                using (MySqlConnection conexion = new MySqlConnection(ParametrosConfiguracion.getConexionString()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(procedure, conexion);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@u_email", email);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cuenta.id = (int)reader["id"];
                        cuenta.nombre = reader["nombre"].ToString();
                        cuenta.apellido = reader["apellido"].ToString();
                        cuenta.cedula_identidad = reader["cedula_identidad"].ToString() ;
                        cuenta.nombre_banco = reader["nombre_banco"].ToString();
                        cuenta.numero_cuenta = reader["numero_cuenta"].ToString();
                        cuenta.numero_telefono = reader["numero_telefono"].ToString();
                        cuenta.email = reader["email"].ToString();
                        cuenta.rol = (int) reader["rol"];
                        cuenta.password = (byte[]) reader["password"];    
                        cuenta.salt = (byte[])reader["salt"]; 

                    
                    }
                    conexion.Close();
                    return cuenta;
                }
            }
            catch (Exception e)
            {
                Errors error = new Errors();
                error.Message = e.Message;
                return error;
            }
        }
        #endregion
    }
}
