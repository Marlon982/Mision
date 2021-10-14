using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCiclo3.App.Persistencia.AppRepositorios;
using ProyectoCiclo3.App.Dominio;
using Microsoft.AspNetCore.Authorization;
 
namespace ProyectoCiclo3.App.Frontend.Pages
{
    [Authorize]
    
    public class ListServiciosModel : PageModel
    {
       
        private readonly RepositorioServicio repositorioServicio;
        [BindProperty]
        public Servicios Servic {get;set;}
        public IEnumerable<Servicios> Servicios {get;set;}
 
    public ListServiciosModel(RepositorioServicio repositorioServicio)
    {
        this.repositorioServicio=repositorioServicio;
     }
 
    public void OnGet()
    {
        Servicios=repositorioServicio.GetAll();
    }
    public IActionResult OnPost()
    {
        if(Servic.id>0)
        {
        repositorioServicio.Delete(Servic.id);
        }
        return RedirectToPage("./List");
    }
    
    }
}

