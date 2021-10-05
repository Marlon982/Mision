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
        
        public Encomienda Create(Encomienda newEncomienda)
        {
           if(Encomienda.Count > 0){
           newEncomienda.id=Encomienda.Max(r => r.id) +1; 
            }else{
               newEncomienda.id = 1; 
            }
           Encomienda.Add(newEncomienda);
           return newEncomienda;
        }
        
        public Encomienda Update(Encomienda newEncomienda){
            var orden= Encomienda.SingleOrDefault(b => b.id == newEncomienda.id);
            if(orden != null){
                orden.descripcion = newEncomienda.descripcion;
                orden.peso = newEncomienda.peso;
                orden.tipo = newEncomienda.tipo;
                orden.presentacion = newEncomienda.presentacion;
            }
        return orden;
        }

        public void Delete(int id)
        {
        var orden= Encomienda.SingleOrDefault(b => b.id == id);
        Encomienda.Remove(orden);
        return;
        }

    }
}
