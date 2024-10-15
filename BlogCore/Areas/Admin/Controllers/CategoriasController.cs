using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        //private readonly ApplicationDbContext _context;// ya no llamamos al contexto sino a la unidad de trabajo patrón unit of work

        private readonly IContenedorTrabajo _contenedorTrabajo;// patron unit of work llamamos ahora al contenedor de trabajo que tiene el dbcontext

        public CategoriasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]// traemos la vista
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid) //validación del lado del servidor
            {
                // logica paraguardar en base de datos
                _contenedorTrabajo.Categoria.Add(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }   
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria categoria = new Categoria();  //instaciamos en memoria el modelo categoria
            categoria = _contenedorTrabajo.Categoria.Get(id);
            if (categoria == null) 
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                //Logica para actualizar en BD
                _contenedorTrabajo.Categoria.Update(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        #region llamadas a la API

        [HttpGet]
         public ActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Categoria.GetAll() });// traemos la data json de categoría
        }


        [HttpDelete]
        public IActionResult Delete(int id) // es un metodo ajax que utiliza sweet alert por eso se pone en esta región
        {
            var objFromDb = _contenedorTrabajo.Categoria.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando categoría" });
            }

            _contenedorTrabajo.Categoria.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Categoría Borrada Correctamente" });
        }
        #endregion 

        //[HttpPost]
    }
}
