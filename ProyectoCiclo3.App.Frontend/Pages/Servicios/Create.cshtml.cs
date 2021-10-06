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
    public class FormServiciosModel : PageModel
    {
        private readonly RepositorioServicio repositorioServicio;
        [BindProperty]
        public Servicios Servicios {get;set;}
 
        public FormServiciosModel(RepositorioServicio repositorioServicio)
       {
            this.repositorioServicio=repositorioServicio;
       }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }            
            Servicios = repositorioServicio.Create(Servicios);            
            return RedirectToPage("./List");
        }

    }
}
