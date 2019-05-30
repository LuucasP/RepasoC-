
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using p.Models;
namespace p.Controllers
{
    public class ClienteController : Controller
    {

     private ProyContext _context {get;} 

     private ClienteController(ProyContext context){
            _context = context;
     }  


    public IActionResult Registrar(){
        return View();
    }

    [HttpPost]
    public IActionResult Registrar(Cliente c){
        if(ModelState.IsValid){
            _context.Cliente.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Listar");
            }

            return View(c);
    }



    }
}