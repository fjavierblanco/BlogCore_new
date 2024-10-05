using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
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

        #region llamadas a la API

        [HttpGet]
         public ActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Categoria.GetAll() });// traemos la data json de categoría
        }


        #endregion

        //[HttpPost]
    }
}
