using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;

namespace OdeToFood.ViewComponents
{
    public class GreetingViewComponent : ViewComponent
    {
        private readonly IGreeter _greeter;

        public GreetingViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetGreeting();
            return View("Default",model);
        }
    }
}