using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Datos;

namespace Negocio
{
    public class NCategoria
    {

        public List<Category> ListarPorNombre(string nombre)
        {
            var categorias = new DCategoria().listar();
            var categoriaspornombre= categorias.Where(c => c.Name.Contains(nombre)).ToList();

            return categoriaspornombre;
        }

        public void Insertar(string name, string description)
        {
            new DCategoria().Insertar(name, description);
        }
      
    }
}
