using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles.Model
{
    public class Profesor
    {
        public string Nombre { get; set; }
        // Puedes agregar más propiedades según sea necesario

        public Profesor(string nombre)
        {
            Nombre = nombre;
        }
    }

    public class Nodo
    {
        private Nodo[] nodos;

        public Profesor Profesor { get; set; } 
        public Nodo Izq { get; set; }
        public Nodo Der { get; set; }

        public Nodo(Profesor profesor, Nodo izq = null, Nodo der = null)
        {
            Profesor = profesor;
            Izq = izq;
            Der = der;
        }

        public Nodo(Profesor profesor, Nodo[] nodos)
        {
            Profesor = profesor;
            this.nodos = nodos;
        }
    }
}

