using FStore.BusinessObject;
using FStore.DataAccess.IRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FStore.SalesRazorApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IMemberRepository _memberRepository;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            Member member = _memberRepository.GetMember(Email);
            if (member != null && member.Password.Equals(Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, member.Role)
                };

                if (member.Role.Equals("User"))
                {
                    claims.Add(new Claim("MemberId", member.MemberId.ToString()));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);

                if (member.Role.Equals("Admin"))
                {
                    string? role = member.Role;
                    HttpContext.Session.SetString("Role", role);
                    return RedirectToPage("/ProductPage/Index");
                }
                else if (member.Role.Equals("User"))
                {
                    string? role = member.Role;
                    HttpContext.Session.SetString("Role", role);
                    return RedirectToPage("/OrderPage/Index");
                }
            }
            ErrorMessage = "Invalid login attempt.";
            return Page();
        }
    }
}
