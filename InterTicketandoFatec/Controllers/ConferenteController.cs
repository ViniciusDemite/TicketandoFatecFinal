using InterTicketandoFatec.DAL;
using InterTicketandoFatec.Models;
using System.Web.Mvc;

namespace InterTicketandoFatec.Controllers
{
    [AuthFilerComissao]
    public class ConferenteController : Controller
    {
        public ActionResult ConferenteIndex()
        {
            using (ConferenteDAL dal = new ConferenteDAL())
            {
                return View(dal.ReadAll());
            }
        }

        public ActionResult ConferenteCreate()
        {
             return View();
        }

        [HttpPost]
        public ActionResult ConferenteCreate(Conferente conferentes)
        {
            using (ConferenteDAL dal = new ConferenteDAL())
            {
                dal.Create(conferentes);

                return Redirect("/Atividade/AtividadeCreate");
            }
        }

        public ActionResult ConferenteUpdate(int id)
        {
             return View();
        }

        [HttpPost]
        public ActionResult ConferenteUpdate(Conferente conferentes)
        {
            using (ConferenteDAL dal = new ConferenteDAL())
            {
                dal.Update(conferentes);

                return RedirectToAction("ConferenteIndex");
            }
        }

        //public ActionResult ConferenteDelete(int id)
        //{
        //    using (ConferenteDAL dal = new ConferenteDAL())
        //    {
        //        dal.Delete(id);

        //        return RedirectToAction("ConferenteIndex");
        //    }
        //}
    }
}