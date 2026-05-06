namespace Catalogo.Models
{
    public class Item
    {
        public int Id { get; set ; }
        public string Nombre { get; set ; }
        public string Ingredientes { get; set ; }
        public int Precio { get; set ; }
        public string Descripcion { get; set ; }

        public string Categoria { get; set; }
    }
    
}
