using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacciones
{
    class Program
    {
        static void Main(string[] args)
        {
            var mov = new Movimiento(new Conexion().crearConexion());
            mov.crearTablas();
            mov.Transac();
            Console.ReadKey();
        }
    }
}
