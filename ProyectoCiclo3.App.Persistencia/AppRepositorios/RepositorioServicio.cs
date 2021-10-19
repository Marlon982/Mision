using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {

        // List<Servicios> Servicios;
        private readonly AppContext _appContext = new AppContext();

        public IEnumerable<Servicios> GetAll()
        {
            return _appContext.Servicios.Include(u => u.origen)
                                        .Include(u => u.destino).
                                        Include(e => e.encomienda);
        }

        public Servicios GetServiciosWithId(int id)
        {
            return _appContext.Servicios.Find(id);
        }

        public Servicios Update(int id, int origen, int destino, string fecha, int encomienda)
        {
            var servicio = _appContext.Servicios.Find(id);
            if (servicio != null)
            {
                servicio.destino = _appContext.Usuarios.Find(destino);
                servicio.origen = _appContext.Usuarios.Find(origen);
                servicio.fecha = DateTime.Parse(fecha);
                // servicio.hora = hora;
                servicio.encomienda = _appContext.Encomienda.Find(encomienda);
                _appContext.SaveChanges();
            }
            return servicio;
        }

        public Servicios Create(int origen, int destino, string fecha, int encomienda)
        {
            var newServicios = new Servicios();
            newServicios.destino = _appContext.Usuarios.Find(destino);
            newServicios.origen = _appContext.Usuarios.Find(origen);
            newServicios.encomienda = _appContext.Encomienda.Find(encomienda);
            newServicios.fecha = DateTime.Parse(fecha);
            // newServicios.hora = hora;
            var addServicios = _appContext.Servicios.Add(newServicios);
            _appContext.SaveChanges();
            return addServicios.Entity;
        }

        public void Delete(int id)
        {
            var servic = _appContext.Servicios.Find(id);
            if (servic == null)
                return;
            _appContext.Servicios.Remove(servic);
            _appContext.SaveChanges();
        }

    }
}