using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using p.Models;
using p.ViewModels;
namespace p.Controllers
{
    public class AccountController : Controller
    {
        private ProyContext _context;

        private UserManager<IdentityUser> _UserManager;

        private SignInManager<IdentityUser> _SingInManager;

        public AccountController(ProyContext c , UserManager<IdentityUser> um, SignInManager<IdentityUser> si){
            _context = c;
            _UserManager = um;
            _SingInManager = si;
        }

        public IActionResult Registrar(){
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Registrar r){
            if(ModelState.IsValid){
                var user = new IdentityUser();
                user.UserName = r.Usuario;
                user.Email = r.Email;

                var resbool = _UserManager.CreateAsync(user,r.Password);
                if(resbool.Result == IdentityResult.Success){
                      return RedirectToAction("Index" , "Home");
                }else{
                    foreach(var error in resbool.Result.Errors){
                        ModelState.AddModelError("error", error.Description);
                    }
                }
                
            }

            return View(r);
        }

        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login log){
            if(ModelState.IsValid){
                var res = _SingInManager.PasswordSignInAsync(log.Usuario,log.Password,false,false);

                if(res.Result.Succeeded){
                     return RedirectToAction("Index" , "Home");
                }else{
                    ModelState.AddModelError("error","Usuario o contraseña incorrecta");
                }    
            }
            return View(log);
        }


        public IActionResult Logout(){

              _SingInManager.SignOutAsync();



            return RedirectToAction("Index", "Home");
        }
        
    }
}