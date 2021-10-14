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

    public class EditUsuariosModel : PageModel
    {
       private readonly RepositorioUsuarios repositorioUsuarios;
              [BindProperty]
              public Usuarios Usuarios {get;set;}
  
        public EditUsuariosModel(RepositorioUsuarios repositorioUsuarios)
       {
            this.repositorioUsuarios=repositorioUsuarios;
       }
 
        public IActionResult OnGet(int UsuariosId)
        {
                Usuarios=repositorioUsuarios.GetUsuariosWithId(UsuariosId);
                return Page();
 
        }
        
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Usuarios.id>0)
            {
            Usuarios = repositorioUsuarios.Update(Usuarios);
            }
            return RedirectToPage("./List");
        }

    }
}
