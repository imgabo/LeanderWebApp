namespace LeanderWebApp.Model
{
    public class Producto
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? fecha_ingreso { get; set; }
        public int? fk_id_categoria { get; set; }
        public int? fk_id_estado { get; set; }
        public int? fk_id_locacion { get; set; }
        public double? precio_compra { get; set; }
        public double? precio_venta { get; set; }
        public string? observaciones { get; set; }
        public string? imagen { get; set; }
    }
}
