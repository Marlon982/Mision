using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicios
    {
        List<Servicios> servicios;
 
    public RepositorioServicios()
        {
            servicios= new List<Servicios>()
            {
                new Servicios{id=1,origen="Armenia",destino= "Manizales",fecha= "10/14/2021",hora= "03:00pm",encomienda= 1},
                new Servicios{id=2,origen="Bogotá",destino= "Pereira",fecha= "10/15/2021", hora= "04:00pm",encomienda= 2},
                new Servicios{id=3,origen="Medellín",destino= "Cali",fecha= "10/10/2021",hora= "03:00pm",encomienda= 3}
 
            };
        }
 
        public IEnumerable<Servicios> GetAll()
        {
            return servicios;
        }
 
        public Servicios GetServicioWithId(int id){
            return servicios.SingleOrDefault(b => b.id == id);
        }
    }
}
