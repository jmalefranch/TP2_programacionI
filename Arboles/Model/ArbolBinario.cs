using System;
using System.Linq;

namespace Arboles.Model
{
    public class ArbolBinario
    {
        public Nodo Raiz { get; set; }

        public ArbolBinario(string raizNombre, params object[] hijos)
        {
            Raiz = new Nodo(new Profesor(raizNombre), hijos.Cast<object>().Select(obj =>
            {
                if (obj is Profesor professorObj)
                {
                    return new Nodo(professorObj);
                }
                else
                {
                    // Manejar el caso en que obj no es un Profesor, por ejemplo, lanzar una excepción
                    throw new ArgumentException("Todos los elementos del array deben ser instancias de Profesor.");
                }
            }).ToArray());
        }

        public void RecorridoPreOrden(Nodo nodo)
        {
            if (nodo != null)
            {
                RecorridoPreOrden(nodo.Izq);
                RecorridoPreOrden(nodo.Der);
            }
        }

        

    }
}
