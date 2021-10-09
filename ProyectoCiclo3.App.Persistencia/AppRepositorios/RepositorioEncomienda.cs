using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEncomienda
    {
 
 private readonly AppContext _appContext = new AppContext();   

        public IEnumerable<Encomienda> GetAll()
        {
            return _appContext.Encomienda;
        }
 
        public Encomienda GetEncomiendaWithId(int id){
            return _appContext.Encomienda.Find(id);
        }

        public Encomienda Update(Encomienda newEncomienda){
            var encomien= _appContext.Encomienda.Find(newEncomienda.id);
            if(encomien != null){
                encomien.descripcion = newEncomienda.descripcion;
                encomien.peso = newEncomienda.peso;
                encomien.tipo = newEncomienda.tipo;
                encomien.presentacion = newEncomienda.presentacion;
                _appContext.SaveChanges();
            }
        return encomien;
        }

        public Encomienda Create(Encomienda newEncomienda)
        {
           var addEncomienda = _appContext.Encomienda.Add(newEncomienda);
            _appContext.SaveChanges();
            return addEncomienda.Entity;
        }

        public void Delete(int id)
        {
        var encomien= _appContext.Encomienda.Find(id);
        if (encomien == null)
            return;
        _appContext.Encomienda.Remove(encomien);
        _appContext.SaveChanges();
        }

    }
}