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
    
    public class ListUsuariosModel : PageModel
    {
       
        private readonly RepositorioUsuarios repositorioUsuarios;
        [BindProperty]
        public Usuarios User {get;set;}
        public IEnumerable<Usuarios> Usuarios {get;set;}
 
    public ListUsuariosModel(RepositorioUsuarios repositorioUsuarios)
    {
        this.repositorioUsuarios=repositorioUsuarios;
     }
 
    public void OnGet()
    {
        Usuarios=repositorioUsuarios.GetAll();
    }

    public IActionResult OnPost()
    {
        if(User.id>0)
        {
        repositorioUsuarios.Delete(User.id);
        }
        return RedirectToPage("./List");
    }
    }
}
