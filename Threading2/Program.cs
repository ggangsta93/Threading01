using System;
using System.Threading;

namespace Threading2
{
    class Program
    {
        private static bool ejecutar = true;
        static void Main(string[] args)
        {
            int m = 0;
            int x = 0;

            //Creamos el hilo y lo arrancamos
            //Thread miHilo = new Thread(Mensaje);
            //miHilo.Start();

            //Aquí estamos creando multiples hilos
            for (x=0; x< 8 ;x++)
            {
                Thread miHilo = new Thread(MensajeM);
                miHilo.Start(x);
            }

            while (ejecutar)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Saludos desde el hilo principal {0}", m);
                m++;
                if (m == 250000)                  
                    ejecutar = false;
                
            }
        }

        static void Mensaje()
        {
            int n = 0;
            while (ejecutar)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Saludos desde el hilo {0}", n);
                n++;
            }
            
        }

        static void MensajeM(Object o)
        {
            int n = 0;
            while (ejecutar)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Saludos desde el hilo {0} - {1}", o, n);
                n++;
            }

        }

    }
}
