using System;
using System.Collections.Generic;
using System.Linq;
using Tienda.Modelo;

namespace TiendaOriginal
{
    class Program
    {
        static void Main(string[] args)
        {
            var articulos = new List<Articulo>()
            {
                new Articulo() { Nombre = "Articulo Barato", Precio = 50 },
                new Articulo() { Nombre = "Articulo Caro", Precio = 1000 }
            };

            var tienda = new TiendaInteligente(articulos);
            var articuloSeleccionadoPorAvaro = tienda.SugerirArticulo("avaro");
            var articuloSeleccionadoPorPresumido = tienda.SugerirArticulo("presumido");

            Console.WriteLine("Seleccionado por avaro: {0}", articuloSeleccionadoPorAvaro);
            Console.WriteLine("Seleccionado por presumido: {0}", articuloSeleccionadoPorPresumido);

            Console.ReadLine();
        }
    }

    public class TiendaInteligente
    {
        private readonly IList<Articulo> _articulos;

        public TiendaInteligente(IList<Articulo> articulos)
        {
            _articulos = articulos;
        }

        public Articulo SugerirArticulo(string tipoComprador)
        {
            // Un comprador puede ser avaro (elige el artículo más barato) o presumido (elige el artículo más caro).

            if (tipoComprador == "avaro") // Es avaro.
            {
                var menorPrecio = _articulos.Min(a2 => a2.Precio);

                return _articulos.First(a1 => a1.Precio == menorPrecio);
            }
            else // Es presumido.
            {
                var mayorPrecio = _articulos.Max(a2 => a2.Precio);

                return _articulos.First(a1 => a1.Precio == mayorPrecio);
            }
        }
    }
}
