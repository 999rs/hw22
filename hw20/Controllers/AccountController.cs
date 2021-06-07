//using System.ComponentModel.DataAnnotations;
//using System.Threading.Tasks;
//using hw20.Areas.Identity.Data;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace  hw20.Controllers
//{
//    [AllowAnonymous]
//    public class AccountController : Controller
//    {
//        private readonly SignInManager<hw20User> signInManager;

//        public AccountController(SignInManager<hw20User> signInManager)
//        {
//            //SignInManager<hw20User> signInManager
//            this.signInManager = signInManager;
//        }

//        [HttpGet]
//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
//        {
//            ViewData["ReturnUrl"] = returnUrl;
//            if (ModelState.IsValid)
//            {
//                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
//                if (result.Succeeded)
//                {
//                    return RedirectToAction("Index", "HomeController");
//                    //return RedirectToAction(nameof(hw20.Controllers.HomeController.Index), "Home");
//                }
//                else
//                {
//                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//                    return View(model);
//                }
//            }
//            return View(model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Logout()
//        {
//            await signInManager.SignOutAsync();
//            return RedirectToAction("Login");
//        }

//        public IActionResult AccessDenied()
//        {
//            return View();
//        }
//    }
//    public class LoginModel
//    {
//        [Required]
//        public string UserName { get; set; }
//        [Required]
//        [DataType(DataType.Password)]
//        public string Password { get; set; }
//        [Display(Name = "Remember me?")]
//        public bool RememberMe { get; set; }
//    }
//}