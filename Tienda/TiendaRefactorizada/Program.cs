using System;
using System.Collections.Generic;
using System.Linq;
using Tienda.Modelo;

namespace TiendaRefactorizada
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
            var articuloSeleccionadoPorAvaro = tienda.SugerirArticulo(new CompradorAvaro());
            var articuloSeleccionadoPorPresumido = tienda.SugerirArticulo(new CompradorPresumido());

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

        public Articulo SugerirArticulo(IComprador comprador)
        {
            return comprador.ElegirArticulo(_articulos);
        }
    }

    public interface IComprador
    {
        Articulo ElegirArticulo(IList<Articulo> articulos);
    }

    public class CompradorAvaro : IComprador
    {
        public Articulo ElegirArticulo(IList<Articulo> articulos)
        {
            var menorPrecio = articulos.Min(a2 => a2.Precio);

            return articulos.First(a1 => a1.Precio == menorPrecio);
        }
    }

    public class CompradorPresumido : IComprador
    {
        public Articulo ElegirArticulo(IList<Articulo> articulos)
        {
            var mayorPrecio = articulos.Max(a2 => a2.Precio);

            return articulos.First(a1 => a1.Precio == mayorPrecio);
        }
    }
}
