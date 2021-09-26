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
    public class DetailsUsuariosModel : PageModel
    {
       private readonly RepositorioUsuarios repositorioUsuarios;
              public Usuarios Usuarios {get;set;}
  
        public DetailsUsuariosModel(RepositorioUsuarios repositorioUsuarios)
       {
            this.repositorioUsuarios=repositorioUsuarios;
       }
 
        public IActionResult OnGet(int UsuariosId)
        {
                Usuarios=repositorioUsuarios.GetUsuariosWithId(UsuariosId);
                return Page();
 
        }
    }
}
