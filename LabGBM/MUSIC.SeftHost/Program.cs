using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace MUSIC.SeftHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(MUSIC.SERVICES.SongService));
            host.Open();
            Console.Write("Presione cualquier tecla para terminar");
            Console.ReadKey();
            host.Close();
        }
    }
}
