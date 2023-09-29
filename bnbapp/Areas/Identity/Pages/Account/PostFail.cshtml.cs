using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bnbapp.Areas.Identity.Pages.Account
{
    public class PostFailModel : PageModel
    {
        public string Error { get; set; } = "";
        public void OnGet(string data)
        {
            Error = data;
            

        }

    }
}
