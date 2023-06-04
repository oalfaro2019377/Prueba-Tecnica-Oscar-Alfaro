//Importacion de librerias necesarias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OscarAlfaroPruebaTecnica.Models;
using Rotativa.AspNetCore;

namespace OscarAlfaroPruebaTecnica.Controllers
{
    public class ProductoesController : Controller
    {
        private readonly PTDBContext _context;

        public ProductoesController(PTDBContext context)
        {
            _context = context;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            //Recoger información de los modelos de cada clase según su ID
            var pTDBContext = _context.Productos.Include(p => p.IdMarcaNavigation).Include(p => p.IdPresentacionNavigation).Include(p => p.IdProveedorNavigation).Include(p => p.IdZonaNavigation);
            return View(await pTDBContext.ToListAsync());
        }
        //Método para generar reporte en PDF para todos los Productos
        public async Task<IActionResult> IndexPDF()
        {
            var pTDBContext = _context.Productos.Include(p => p.IdMarcaNavigation).Include(p => p.IdPresentacionNavigation).Include(p => p.IdProveedorNavigation).Include(p => p.IdZonaNavigation);
            return new ViewAsPdf(await pTDBContext.ToListAsync());
        }

        // GET: Productoes/Details/5
        //Método para generar reporte en PDF detallado para cada producto
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdMarcaNavigation)
                .Include(p => p.IdPresentacionNavigation)
                .Include(p => p.IdProveedorNavigation)
                .Include(p => p.IdZonaNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return new ViewAsPdf(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "DescripcionMarca");
            ViewData["IdPresentacion"] = new SelectList(_context.Presentacions, "IdPresentacion", "DescripcionPresentacion");
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "DescripcionProveedor");
            ViewData["IdZona"] = new SelectList(_context.Zonas, "IdZona", "DescripcionZona");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,IdMarca,IdPresentacion,IdProveedor,IdZona,Codigo,DescripcionProducto,Precio,Stock,Iva,Peso")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "DescripcionMarca", producto.IdMarca);
            ViewData["IdPresentacion"] = new SelectList(_context.Presentacions, "IdPresentacion", "DescripcionPresentacion", producto.IdPresentacion);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "DescripcionProveedor", producto.IdProveedor);
            ViewData["IdZona"] = new SelectList(_context.Zonas, "IdZona", "DescripcionZona", producto.IdZona);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "DescripcionMarca", producto.IdMarca);
            ViewData["IdPresentacion"] = new SelectList(_context.Presentacions, "IdPresentacion", "DescripcionPresentacion", producto.IdPresentacion);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "DescripcionProveedor", producto.IdProveedor);
            ViewData["IdZona"] = new SelectList(_context.Zonas, "IdZona", "DescripcionZona", producto.IdZona);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,IdMarca,IdPresentacion,IdProveedor,IdZona,Codigo,DescripcionProducto,Precio,Stock,Iva,Peso")] Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.IdProducto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMarca"] = new SelectList(_context.Marcas, "IdMarca", "DescripcionMarca", producto.IdMarca);
            ViewData["IdPresentacion"] = new SelectList(_context.Presentacions, "IdPresentacion", "DescripcionPresentacion", producto.IdPresentacion);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "DescripcionProveedor", producto.IdProveedor);
            ViewData["IdZona"] = new SelectList(_context.Zonas, "IdZona", "DescripcionZona", producto.IdZona);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdMarcaNavigation)
                .Include(p => p.IdPresentacionNavigation)
                .Include(p => p.IdProveedorNavigation)
                .Include(p => p.IdZonaNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.IdProducto == id);
        }
    }
}
