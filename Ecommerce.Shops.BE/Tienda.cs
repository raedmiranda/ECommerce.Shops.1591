namespace ECommerce.Shops.BE
{
    public class Tienda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public bool Abierto { get; set; }
    }
}
