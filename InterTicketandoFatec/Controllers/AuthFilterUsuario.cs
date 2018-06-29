using System.Web.Mvc;

namespace InterTicketandoFatec.Controllers
{
    public class AuthFilterUsuario : ActionFilterAttribute
    {
        //filterContext -- tem toda a informação q vem do cliente para o servidor
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //se o usuário foi nulo redireciona para o login, senão segue os outros comandos
            if (filterContext.HttpContext.Session["usuario"] == null)
            {
                filterContext.Result = new RedirectResult("/Usuario/UsuarioLogin");
            }
        }
    }
}