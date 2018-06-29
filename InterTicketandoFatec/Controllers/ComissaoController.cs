using InterTicketandoFatec.DAL;
using InterTicketandoFatec.Models;
using System.Web.Mvc;

namespace InterTicketandoFatec.Controllers
{
    [AuthFilerComissao]
    public class ComissaoController : Controller
    {
        public ActionResult ComissaoIndex()
        {
            using (ComissaoDAL dal = new ComissaoDAL())
            {
                return View(dal.Read());
            }
        }

        public ActionResult ComissaoResponsavel()
        {
            using (ComissaoDAL dal = new ComissaoDAL())
            {
                return View(dal.ReadResponsavel());
            }
        }

        public ActionResult PessoaComissao()
        {
            using (ComissaoDAL dal = new ComissaoDAL())
            {
                return View(dal.ReadPessoaComissao());
            }
        }

        public ActionResult ComissaoCreate()
        {
            using (EventoDAL dal = new EventoDAL())
            {
                ViewBag.Eventos = dal.ReadAll();
            }

                return View();
        }

        [HttpPost]
        public ActionResult ComissaoCreate(Comissao c)
        {
            using (ComissaoDAL dal = new ComissaoDAL())
            {
                dal.Create(c);

                return RedirectToAction("ComissaoIndex");
            }
        }

        [HttpGet]
        public ActionResult ComissaoUpdate(int id)
        {
            using (ComissaoDAL dalC = new ComissaoDAL())
            using (EventoDAL dalE = new EventoDAL())
            {
                ViewBag.Eventos = dalE.ReadAll();

                return View(dalC.Read(id));
            }
        }

        [HttpPost]
        public ActionResult ComissaoUpdate(Comissao c)
        {
            using (ComissaoDAL dal = new ComissaoDAL())
            {
                dal.Update(c);

                return RedirectToAction("ComissaoIndex");
            }
        }

        public ActionResult ComissaoDelete(int id)
        {
            using (ComissaoDAL dal = new ComissaoDAL())
            {
                dal.Delete(id);

                return Redirect("/PaginaInicial/PaginaInicial");
            }
        }
    }
}