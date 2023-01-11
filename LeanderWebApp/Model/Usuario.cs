namespace LeanderWebApp.Model
{
    public class Usuario
    {
        public int? id { get; set; }
        public string? nombre { get; set; }

        public string? apellido { get; set; }
        public string? cedula_identidad { get; set; }

        public string? nombre_banco { get; set; }

        public string? numero_cuenta { get; set; }

        public string? numero_telefono { get; set; }

        public string? email { get; set; }
        public byte[]? password { get; set; }

        public byte[]? salt { get; set; }

        public int? rol { get; set; }

    }
}
