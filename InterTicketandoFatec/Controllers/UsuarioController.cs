using InterTicketandoFatec.Models;
using InterTicketandoFatec.DAL;
using System.Web.Mvc;

namespace InterTicketandoFatec.Controllers
{
    public class UsuarioController : Controller
    {
        [AuthFilterUsuario]
        public ActionResult UsarioIndex()
        {
            Usuario usuario = Session["usuario"] as Usuario;

            using (ChamadaDAL dal = new ChamadaDAL())
            {
                return View(dal.ReadAll(usuario.ID));
            }
        }

        public ActionResult UsuarioCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UsuarioCreate(Usuario u)
        {
            using (UsuarioDAL dal = new UsuarioDAL())
            {
                dal.Create(u);

                return RedirectToAction("UsarioIndex");
            }
        }

        [AuthFilterUsuario]
        [HttpGet]
        public ActionResult UsuarioUpdate()
        {
            Usuario usuario = Session["usuario"] as Usuario;

            using (UsuarioDAL dal = new UsuarioDAL())
            {
                return View(dal.Read(usuario.ID));
            }
        }

        [HttpPost]
        public ActionResult UsuarioUpdate(Usuario u)
        {
            using (UsuarioDAL dal = new UsuarioDAL())
            {
                dal.Update(u);

                return Redirect("/PaginaInicial/PaginaInicial");
            }
        }

        [AuthFilterUsuario]
        public ActionResult UsuarioDelete(int id)
        {
            using (UsuarioDAL dal = new UsuarioDAL())
            {
                dal.Delete(id);

                return Redirect("/PaginaInicial/PaginaInicial");
            }
        }

        public ActionResult UsuarioLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UsuarioLogin(FormCollection form)
        {
            string login = form["login"];
            string senha = form["senha"];

            using (UsuarioDAL dal = new UsuarioDAL())
            {
                Usuario usuarios = dal.RedUsuario(login, senha);

                if (usuarios == null)
                {
                    ViewBag.Error = "E-mail ou senha inválidos";

                    return View();
                }
                else
                {
                    Session["usuario"] = usuarios;

                    return Redirect("/PaginaInicial/PaginaInicial");
                }
            }
        }

        public ActionResult UsuarioLogOff()
        {
            Session.Abandon();

            return Redirect("/PaginaInicial/PaginaInicial");
        }
    }
}