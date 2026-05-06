using Catalogo.Models; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
    public class CatalogoController : Controller
    {
        private static List<Item> _items = new()
        {
            new Item
            {
                Id = 1,
                Nombre = "Cochinita pibil",
                Ingredientes = "Carne de cerdo, achiote, naranja agria, cebolla morada",
                Precio = 150,
                Descripcion = "Mollete tradicional mexicano originario de la península de Yucatán, preparado con carne de cerdo marinada en achiote y jugo de naranja agria, cocida lentamente hasta que esté tierna y jugosa",
                Categoria = "Regional"
            },

            new Item
            {
                Id = 2,
                Nombre = "Peperoni",
                Ingredientes = "Pepperoni, queso, salsa de tomate",
                Precio = 120,
                Descripcion = "Mollete clásico con pepperoni, queso fundido y salsa de tomate",
                Categoria = "Clasica"
            },

            new Item
            {
                Id = 3,
                Nombre = "Mollete tradicional",
                Ingredientes = "Pan, frijoles, queso, salsa",
                Precio = 100,
                Descripcion = "Mollete tradicional mexicano con pan, frijoles, queso y salsa",
                Categoria = "Clasica"
            },
        };

        public IActionResult Index(string? genero)
        {
            var resultado = string.IsNullOrEmpty(genero)
                ? _items
                : _items.Where(i => i.Categoria == genero).ToList();
            ViewBag.Categorias = _items.Select(i => i.Categoria).Distinct().ToList();
            ViewBag.CategoriaActual = genero;

            return View(resultado);
        }

        public IActionResult Detalle(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            return item == null ? NotFound() : View(item);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar (Item item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            return RedirectToAction("Index");
        }
    }
}