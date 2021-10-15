using System;
namespace ProyectoCiclo3.App.Dominio{
    public class Servicios{
        public int id {get;set;}
        public Usuarios origen {get;set;}
        public Usuarios destino {get;set;}
        public DateTime fecha {get;set;}
        public string hora {get;set;}
        public Encomienda encomienda {get;set;}
    }
}