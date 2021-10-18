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

        public Servicios Update(Servicios newServicios)
        {
            var servicio = _appContext.Servicios.Find(newServicios.id);
            if (servicio != null)
            {
                servicio.origen = newServicios.origen;
                servicio.destino = newServicios.destino;
                servicio.fecha = newServicios.fecha;
                servicio.hora = newServicios.hora;
                servicio.encomienda = newServicios.encomienda;
                _appContext.SaveChanges();
            }
            return servicio;
        }

        public Servicios Create(int origen, int destino, string fecha, string hora, int encomienda)
        {
            var newServicios = new Servicios();
            newServicios.destino = _appContext.Usuarios.Find(destino);
            newServicios.origen = _appContext.Usuarios.Find(origen);
            newServicios.encomienda = _appContext.Encomienda.Find(encomienda);
            newServicios.fecha = fecha;
            newServicios.hora = hora;
            var addServicios = _appContext.Servicios.Add(newServicios);
            _appContext.SaveChanges();
            return addServicios.Entity;

            //    var addServicios = _appContext.Servicios.Add(newServicios);
            //     _appContext.SaveChanges();
            //     return addServicios.Entity;
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