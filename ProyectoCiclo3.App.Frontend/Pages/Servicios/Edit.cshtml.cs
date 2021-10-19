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

    public class EditServiciosModel : PageModel
    {
        private readonly RepositorioServicio repositorioServicio;
        private readonly RepositorioUsuarios repositorioUsuarios;
        private readonly RepositorioEncomienda repositorioEncomienda;
        [BindProperty]
        public Servicios Servicios { get; set; }
        public IEnumerable<Usuarios> Users { get; set; }
        public IEnumerable<Encomienda> Encomiendas { get; set; }

        public EditServiciosModel(RepositorioServicio repositorioServicio, RepositorioUsuarios repositorioUsuarios, RepositorioEncomienda repositorioEncomienda)
        {
            this.repositorioServicio = repositorioServicio;
            this.repositorioUsuarios = repositorioUsuarios;
            this.repositorioEncomienda = repositorioEncomienda;
        }

        public IActionResult OnGet(int servicioId)
        {
            Servicios = repositorioServicio.GetServiciosWithId(servicioId);
            Users = repositorioUsuarios.GetAll();
            Encomiendas = repositorioEncomienda.GetAll();
            return Page();

        }

        public IActionResult OnPost(int id, int origen, int destino, string fecha, int encomienda)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Servicios.id > 0)
            {
                Servicios = repositorioServicio.Update(id, origen, destino, fecha, encomienda);
            }
            return RedirectToPage("./List");
        }
    }
}