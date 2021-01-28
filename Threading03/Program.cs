using System;
using System.Threading;

namespace Threading03
{
    class Program
    {
        //Foreground threads son hilos que siguen existiendo, aún si la 
        //aplicación termina de ejecutar el main
        //pueden evitar que la aplicación termine

        //Background threads son hilos que se finalizan si la aplicación
        //termina de ejecutar el main

        private static bool ejecutar = true;
        static void Main(string[] args)
        {
            int m = 0;
            int x = 0;

            //Creamos el hilo y lo arrancamos
            //Con esta forma es de tipo foreground
            // Thread miHilo = new Thread(Mensaje);
            // miHilo.Start();

            //De esta forma creamos un hilo que es
            //Background thread
            Thread miHilo=new Thread(Mensaje);
            miHilo.IsBackground = true;
            miHilo.Start();

            while (ejecutar)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Saludos desde el hili principal {0}", m);
                m++;

                if (m == 25)
                    ejecutar = false;

            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Salimos de main");

        }

        static void Mensaje()
        {
            int n = 0;
            bool ejecutarMensaje = true;
            while (ejecutarMensaje)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Saludos desde el hilo {0}", n);
                n++;
                if (n > 2500)
                    ejecutarMensaje = false;
            }

        }

    }
}
