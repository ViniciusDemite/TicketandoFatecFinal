using InterTicketandoFatec.Models;
using InterTicketandoFatec.DAL;
using System.Web.Mvc;

namespace InterTicketandoFatec.Controllers
{
    [AuthFilerComissao]
    public class AtividadeController : Controller
    {
        public ActionResult AtividadeIndex()
        {
            using (AtividadeDAL dal = new AtividadeDAL())
            {
                return View(dal.ReadAll());
            }
        }

        public ActionResult AtividadeCreate()
        {
            using (EventoDAL dal = new EventoDAL())
            {
                ViewBag.Eventos = dal.ReadAll();
            }

            using (ConferenteDAL dal = new ConferenteDAL())
            {
                ViewBag.Conferentes = dal.ReadAll();
            }

            using (TipoDAL dal = new TipoDAL())
            {
                ViewBag.Tipos = dal.Read();
            }
            return View();
        }

        [HttpPost]
        public ActionResult AtividadeCreate(Atividade a)
        {
            using (AtividadeDAL dal = new AtividadeDAL())
            {
                dal.Create(a);

                return RedirectToAction("AtividadeIndex");
            }
        }

        public ActionResult AtividadeUpdate(int id)
        {
            using (ConferenteDAL dalC = new ConferenteDAL())
            using (EventoDAL dalE = new EventoDAL())
            using (TipoDAL dalT = new TipoDAL())
            using (AtividadeDAL dalA = new AtividadeDAL())
            {
                ViewBag.Tipos = dalT.Read();

                ViewBag.Eventos = dalE.ReadAll();

                ViewBag.Conferentes = dalC.ReadAll();

                return View(dalA.ReadAll());
            }
        }

        [HttpPost]
        public ActionResult AtividadeUpdate(Atividade a)
        {
            using (AtividadeDAL dal = new AtividadeDAL())
            {
                dal.Update(a);

                return RedirectToAction("AtividadeIndex");
            }
        }

        public ActionResult AtividadeDelete(int id)
        {
            using (AtividadeDAL dal = new AtividadeDAL())
            {
                dal.Delete(id);

                return RedirectToAction("AtividadeIndex");
            }
        }
    }
}