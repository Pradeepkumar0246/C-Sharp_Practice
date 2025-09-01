using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorProductManager.Pages
{
    public class HelloModel : PageModel
    {
        public string Name{ get; set; } 
        public void OnGet()
        {
            Name="Welcome to my Razor Page!";
        }
    }
}
