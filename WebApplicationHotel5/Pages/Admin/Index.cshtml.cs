using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace WebApplicationHotel5.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public bool isauthentified=false;
        public bool isAdminMode = false;
        IConfiguration configuration;
        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult OnGet()
        {
            isAdminMode = true;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string username, string password)
        {

            var credentials = configuration.GetSection("Auth");
            string adminlogin = credentials["AdminLogin"];
            string adminpassword = credentials["AdminPassword"];
	            if (username == adminlogin && password==adminpassword)
	            {
                isauthentified = true;
                var claims = new List<Claim>
						{
						new Claim(ClaimTypes.Name, username)
						};
					var claimsIdentity = new ClaimsIdentity(claims, "Login");
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new
					ClaimsPrincipal(claimsIdentity));                
                
            }
	            return Page();
			}

        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin");
            
        }
    }
}
