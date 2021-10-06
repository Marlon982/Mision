using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuarios
    {
        List<Usuarios> Usuarios;
 
        private readonly AppContext _appContext = new AppContext();   

        public IEnumerable<Usuarios> GetAll()
        {
           return _appContext.Usuarios;
        }

        public Usuarios GetUsuariosWithId(int id){
            return _appContext.Usuarios.Find(id);
        }

        public Usuarios Create(Usuarios newUsuarios)
        {
           var addUsuarios = _appContext.Usuarios.Add(newUsuarios);
            _appContext.SaveChanges();
            return addUsuarios.Entity;
        }

       public Usuarios Update(Usuarios newUsuarios){
            var usuario = _appContext.Usuarios.Find(newUsuarios.id);
            if(usuario != null){
                usuario.nombre = newUsuarios.nombre;
                usuario.apellidos = newUsuarios.apellidos;
                usuario.direccion = newUsuarios.direccion;
                usuario.ciudad = newUsuarios.ciudad;
                usuario.telefono = newUsuarios.telefono;
                _appContext.SaveChanges();
            }
        return usuario;
        }

        public void Delete(int id)
        {
        var user = _appContext.Usuarios.Find(id);
        if (user == null)
            return;
        _appContext.Usuarios.Remove(user);
        _appContext.SaveChanges();
        }

    }
}
