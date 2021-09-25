using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuarios
    {
        List<Usuarios> Usuarios;
 
    public RepositorioUsuarios()
        {
            Usuarios= new List<Usuarios>()
            {
                new Usuarios{id=1,nombre="Carlos",apellidos= "Bustamante Castro",direccion= "Calle 5 # 24-44",ciudad= "Bogotá",telefono= "(1)444-4444"},
                new Usuarios{id=2,nombre="Maria",apellidos= "Ramirez Roa",direccion= "Carrera 24 # 120A-12",ciudad= "Bogotá",telefono= "(1)123-4567"},
                new Usuarios{id=3,nombre="Alberto",apellidos= "Molina Herrera",direccion= "Transversal 78I #12G-56",ciudad= "Medellin",telefono= "(7)666-9876"}
 
            };
        }
 
        public IEnumerable<Usuarios> GetAll()
        {
            return Usuarios;
        }
 
        public Usuarios GetUsuariosWithId(int id){
            return Usuarios.SingleOrDefault(b => b.id == id);
        }
    }
}
