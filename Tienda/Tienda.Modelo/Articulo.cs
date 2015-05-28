using System;

namespace Tienda.Modelo
{
    public class Articulo
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public override string ToString()
        {
            return String.Format("Nombre: {0}, Precio: {1}", Nombre, Precio);
        }
    }
}
