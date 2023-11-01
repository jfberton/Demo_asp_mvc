using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VentaController : Controller
    {
        private readonly Contexto _context;

        public VentaController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ventas = _context.Ventas.ToList();
            return View(ventas);
        }

        public IActionResult VerDetalle(int id)
        {
            var venta = _context.Ventas.Include("Detalle").Include("Detalle.Producto").FirstOrDefault(v => v.Id == id);
            if (venta == null)
            {
                return NotFound();
            }
            return View(venta);
        }

        [HttpPost]
        public IActionResult EliminarVenta(int id)
        {
            var venta = _context.Ventas.FirstOrDefault(v => v.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(venta);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult NuevaVenta()
        {

            var productos = _context.Productos.ToList(); // Obtén la lista de productos para la vista

            ViewBag.Productos = new SelectList(productos, "Id", "Nombre");

            return View();
        }

        [HttpPost]
        public IActionResult NuevaVenta(Venta nuevaVenta)
        {

            if (ModelState.IsValid)
            {
                // Se inicializa la fecha y hora de la venta
                nuevaVenta.Fecha_hora = DateTime.Now;
                nuevaVenta.Total = nuevaVenta.Detalle.Sum(d=> d.Total_linea);
                _context.Ventas.Add(nuevaVenta);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(nuevaVenta);
        }
    }

}
