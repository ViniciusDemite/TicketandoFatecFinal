using InterTicketandoFatec.DAL;
using InterTicketandoFatec.Models;
using System.Web.Mvc;

namespace InterTicketandoFatec.Controllers
{
    public class ComissaoLoginController : Controller
    {
        public ActionResult ComissaoLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ComissaoLogin(FormCollection form)
        {
            string login = form["login"];
            string senha = form["senha"];

            using (ComissaoDAL dal = new ComissaoDAL())
            {
                Comissao comissoes = dal.Read(login, senha);

                if (comissoes == null)
                {
                    ViewBag.Error = "E-mail ou senha inválidos";

                    return View();
                }
                else
                {
                    Session["comissao"] = comissoes;

                    return Redirect("/Comissao/ComissaoIndex");
                }
            }
        }

        public ActionResult ComissaoLogOff()
        {
            Session.Abandon();

            return Redirect("/PaginaInicial/PaginaInicial");
        }
    }
}