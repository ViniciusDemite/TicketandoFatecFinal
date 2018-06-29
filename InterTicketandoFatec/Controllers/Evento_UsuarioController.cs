using InterTicketandoFatec.Models;
using InterTicketandoFatec.DAL;
using System.Web.Mvc;

namespace InterTicketandoFatec.Controllers
{
    [AuthFilerComissao]
    public class Evento_UsuarioController : Controller
    {
        public ActionResult Evento_UsuarioIndex()
        {
            using (Evento_UsuarioDAL dal = new Evento_UsuarioDAL())
            {
                return View(dal.ReadEventosUsuario());
            }
        }

        public ActionResult Evento_UsuarioCreate()
        {
            using (EventoDAL dal = new EventoDAL())
            {
                ViewBag.Eventos = dal.ReadAll();
            }

            using (UsuarioDAL dal = new UsuarioDAL())
            {
                ViewBag.Usuarios = dal.ReadAll();
            }

            using (StatusDAL dal = new StatusDAL())
            {
                ViewBag.Status = dal.ReadAll();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Eventu_UsuarioCreate(Evento_Usuario eU)
        {
            using (Evento_UsuarioDAL dal = new Evento_UsuarioDAL())
            {
                dal.Create(eU);

                return RedirectToAction("Evento_UsuarioIndex");
            }
        }

        public ActionResult Evento_UsuarioDelete(int id, int id2)
        {
            using (Evento_UsuarioDAL dal = new Evento_UsuarioDAL())
            {
                dal.Delete(id, id2);

                return RedirectToAction("Evento_UsuarioIndex");
            }
        }
    }
}