using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCiclo3.App.Persistencia.AppRepositorios;
using ProyectoCiclo3.App.Dominio;
 
namespace ProyectoCiclo3.App.Frontend.Pages
{
    public class EditServiciosModel : PageModel
    {
       private readonly RepositorioServicio repositorioServicio;
       [BindProperty]
              public Servicios Servicios {get;set;}
 
        public EditServiciosModel(RepositorioServicio repositorioServicio)
       {
            this.repositorioServicio=repositorioServicio;
       }
 
        public IActionResult OnGet(int servicioId)
        {
                Servicios=repositorioServicio.GetServiciosWithId(servicioId);
                return Page();
 
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Servicios.id>0)
            {
            Servicios = repositorioServicio.Update(Servicios);
            }
            return RedirectToPage("./List");
        }
    }
}