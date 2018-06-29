using InterTicketandoFatec.DAL;
using InterTicketandoFatec.Models;
using System.Web.Mvc;

namespace InterTicketandoFatec.Controllers
{
    public class PaginaInicialController : Controller
    {
        public ActionResult PaginaInicial()
        {
            using (AtividadeDAL dal = new AtividadeDAL())
            {
                return View(dal.ReadAll());
            }
        }

        [AuthFilterUsuario]
        public ActionResult InscreverEvento(int id)
        {
            Usuario usuario = Session["usuario"] as Usuario;

            using (ChamadaDAL dal = new ChamadaDAL())
            {
                dal.Insercrever(usuario.ID, id);

                return RedirectToAction("PaginaInicial");
            }
        }

        [AuthFilterUsuario]
        public ActionResult DesincreverEvento(int id)
        {
            Usuario usuario = Session["usuario"] as Usuario;

            using (ChamadaDAL dal = new ChamadaDAL())
            {
                dal.Deinscrever(usuario.ID, id);

                return Redirect("/Usuario/UsarioIndex");
            }
        }
    }
}