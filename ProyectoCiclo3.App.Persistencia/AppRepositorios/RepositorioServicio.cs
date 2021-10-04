using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        List<Servicios> servicios;
 
    public RepositorioServicio()
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
 
        public Servicios GetServiciosWithId(int id){
            return servicios.SingleOrDefault(b => b.id == id);
        }

        public Servicios Update(Servicios newServicios){

            var servicio= servicios.SingleOrDefault(b => b.id == newServicios.id);

            if(servicio != null){
                servicio.origen = newServicios.origen;
                servicio.destino = newServicios.destino;
                servicio.fecha = newServicios.fecha;
                servicio.hora = newServicios.hora;
                servicio.encomienda = newServicios.encomienda;
                
            }
        return servicio;
        }
        public Servicios Create(Servicios newServicios)
        {
           if(servicios.Count > 0){
           newServicios.id=servicios.Max(r => r.id) +1; 
            }else{
               newServicios.id = 1; 
            }
           servicios.Add(newServicios);
           return newServicios;
        }

           public void Delete(int id)
        {
        var servic= servicios.SingleOrDefault(b => b.id == id);
        servicios.Remove(servic);
        return;
        }

    }
}