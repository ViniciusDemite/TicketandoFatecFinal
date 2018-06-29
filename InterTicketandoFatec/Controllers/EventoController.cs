using InterTicketandoFatec.Models;
using InterTicketandoFatec.DAL;
using System.Web.Mvc;

namespace InterTicketandoFatec.Controllers
{
    [AuthFilerComissao]
    public class EventoController : Controller
    {
        public ActionResult EventoIndex()
        {
            using (EventoDAL dal = new EventoDAL())
            {
                return View(dal.ReadAll());
            }
        }

        public ActionResult EventoCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EventoCreate(Evento eventos)
        {
            using (EventoDAL dal = new EventoDAL())
            {
                dal.Create(eventos);

                return Redirect("/Conferente/ConferenteCreate");
            }
        }

        public ActionResult EventoUpdate(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EventoUpdate(Evento eventos)
        {
            using (EventoDAL dal = new EventoDAL())
            {
                dal.Update(eventos);

                return RedirectToAction("EventoIndex");
            }
        }

        //public ActionResult EventoDelete(int id)
        //{
        //    using (EventoDAL dal = new EventoDAL())
        //    {
        //        dal.Delete(id);

        //        return RedirectToAction("ConferenteIndex");
        //    }
        //}
    }
}