using MaratonaAspNetCore.Models.Model;
using MaratonaAspNetCore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MaratonaAspNetCore.Services.Filters
{
    public class ModelStateValidatorAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Controller controller = context.Controller as Controller;

            var controllerName = context.RouteData.Values["controller"].ToString(); ;
            var actionName = context.RouteData.Values["action"].ToString();


            if (!context.ModelState.IsValid)
            {
                context.Result = new ViewResult
                {
                    ViewName = actionName,
                    ViewData = controller.ViewData,
                    TempData = controller.TempData
                };
            }
            base.OnActionExecuting(context);
        }
       
    }
}
