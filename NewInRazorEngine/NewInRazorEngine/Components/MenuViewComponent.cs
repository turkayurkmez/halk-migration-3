using Microsoft.AspNetCore.Mvc;
using NewInRazorEngine.Models;

namespace NewInRazorEngine.Components
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = new List<Category>()
            {

                new(){ Id=1, Name="Kozmetik"},
                new(){ Id=1, Name="Bilgisayar"},
            };
            return View(categories);
        }
    }
}
