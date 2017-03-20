using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using NovaApp.API.DataProvider;

namespace NovaApp.API.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController(IDataProvider dataProvider)
        {
            DataProvider = dataProvider;
        }

        protected IDataProvider DataProvider { get; private set; }

        protected static string AbsoluteAction(ActionContext context, string actionName, string controllerName, object routeValues = null)
        {
            var urlHelper = new UrlHelper(context);
            string scheme = urlHelper.ActionContext.HttpContext.Request.Scheme;
            var urlStr =  urlHelper.Action(actionName, controllerName, routeValues, scheme);

            return urlStr;
        }
    }
}