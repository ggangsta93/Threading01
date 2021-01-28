using System;

using System.Threading;

namespace Threading05
{
    class Program
    {
        //Join es utilizado para esperar la finalizacion de un hilo antes de que continue

        //Un hilo finaliza cuando termina de ejecutar el codigo del metodo
        //que le hemos pasado como delegado

        static void Main(string[] args)
        {
            int i = 0;
            Thread uno = new Thread(Imprime);
            uno.Start();

            //Al usar Join main, main tiene que esperar que termine uno
            //antes de poder continuar su propio hilo
            uno.Join();

            Thread dos = new Thread(Imprime);
            dos.Start();

            Console.ForegroundColor = ConsoleColor.Red;
            for (i=0; i<100;i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("main->{0}", i);
            }

            

        }

        static void Imprime()
        {
            int n = 0;
            for (n=0; n<100;n++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0}->{1}", Thread.CurrentThread.ManagedThreadId, n);
            }
        }
    }
}
