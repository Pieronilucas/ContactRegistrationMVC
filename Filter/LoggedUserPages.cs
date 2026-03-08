using ContactRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace ContactRegistration.Filter;

public class LoggedUserPages : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        string userSession = context.HttpContext.Session.GetString("LoggedUser");

        if (string.IsNullOrEmpty(userSession))
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
        }
        else
        {
            UsuarioModel user = System.Text.Json.JsonSerializer.Deserialize<UsuarioModel>(userSession);

            if (user == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
        }
        
        base.OnActionExecuting((context));
        
        
    }
}