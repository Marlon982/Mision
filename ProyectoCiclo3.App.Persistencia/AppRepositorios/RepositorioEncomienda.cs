using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEncomienda
    {
        List<Encomienda> Encomienda;
 
    public RepositorioEncomienda()
        {
            Encomienda= new List<Encomienda>()
            {
                new Encomienda{id=1,descripcion="Elementos varios (accesorios, juguetes)",peso= 32,tipo= "Paquete",presentacion= "Caja (12cm x 5cm)"},
                new Encomienda{id=2,descripcion="Ropa y calzado",peso= 25,tipo= "Paquete",presentacion= "Bolsa (10cm x 10cm)"}
             };
        }
 
        public IEnumerable<Encomienda> GetAll()
        {
            return Encomienda;
        }
 
        public Encomienda GetEncomiendaWithId(int id){
            return Encomienda.SingleOrDefault(b => b.id == id);
        }
    }
}
