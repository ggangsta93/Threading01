using System;
using System.Threading;

namespace Threading01
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Instanciamos el objeto thread/hilo y colocamos el delegado que corresponde
            //Thread miHilo = new Thread(Saludos);

            ////Ahora lo inicializamos
            ////Ya que no arranca al momento de instanciarse
            //miHilo.Start();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Saludos desde main");

            //Forma de pasar datos al hilo
            Thread miHilo = new Thread(miMensaje);

            //Al iniciar el hilo mandamos el mensaje
            miHilo.Start(5);

        }

        static void Saludos()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saludos desde el hilo.");
        }

        static void miMensaje(object o)
        {
            int m = Convert.ToInt32(o);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Saludos desde el mensaje {0}, {1}", m, m*2);
        }


    }
}
