using System;
using System.Threading;

/*Existe internamente el Thread Scheduler, el cual se encarga de que los diferentes hilso
reciban un tiempo de execucion, Tambien se encarga de que los hilos que estan bloqueados
o en espera no consuman tiempo del CPU

Cuando se tiene solo procesaodr se hace lo que se conoce como time-slicing. Cada thread recibe 
un pedazo de tiempo del CPU y se va cambiando el thread que le corresponde la ejecucion de forma 
rapida

Cuando se tiene vatios procesadores hay una mezcla entre time-slicing y concurrencia real. Los hilos
se ejecutan simultaneamente entre los diferentes CPU, Aun asi debemos de esperar encontrar time-slicing 
porque el sistema operativo ejecuta sus propios hilos y otras aplicaciones tambien pueden estar ejecutando

No hay que confunfir los hilos con los procesos del sistema operativo
Los procesos se ejecutan en paralelo en la computadorea
Los hilos se ejecutan en paralelo en un proceso
Los hilos tienen cierto grado de separacion unicamente
Los hilos comparten memoria con otros hilos que se ejecutan en la misma aplicacion,
esto es algo bueno y deseable.

Los hilos nos dan grandes ventajas pero debemos de ser cuidadosos al usarlos
La programacion multihilos aumenta la complejidad, sobre todo por la interaccion
entre ellos. Hay que tener cuidado con los bugs, pues cuestan mucho trabajo replicarlos y corregisrlos. 
Por eso debemos de cuidar la interaccion entre los hilos sea los minimo posible.

Una buena practica es encapsular en clases la logica para facilitar el testing y la ejecucion de los hilos

El usar hilos no es garantia de que la aplicacion ejecuta mas rapido, Si muchos
accesos a discos son utilizados por varios hilos, incluso puede ser mas lento que 
una aplicacion de un solo hilo.
*/

namespace Threading04
{
    class Program
    {
        private static int conteo = 0;
        private static bool ejecutar = true;

        //Usamos este objeto para crear el lock
        private static object control = new object();
        private static int id1 = 0;
        private static int id2 = 0;
        static void Main(string[] args)
        {
            Thread hilo1 = new Thread(Incremento);
            hilo1.Start();

            //Obtenemos el ID del hilo
            id1 = hilo1.ManagedThreadId;

            Thread hilo2 = new Thread(Incremento);
            hilo2.Start();

            //Obtenemos el ID del hilo
            id2 = hilo2.ManagedThreadId;


            while (ejecutar)
            {
                if (conteo > 100)
                    ejecutar = false;
            }
        }

        static void Incremento()
        {
            while (ejecutar) {

                //Aqui creamos una seccion critica
                //lock asegura que solo un hilo puede estar en la seccion critica a la vez
                lock(control)
                {
                    if (Thread.CurrentThread.ManagedThreadId == id1)
                        Console.ForegroundColor = ConsoleColor.White;
                    if (Thread.CurrentThread.ManagedThreadId == id2)
                        Console.ForegroundColor = ConsoleColor.Green;

                    conteo++;
                    //Ponemos el hilo a dormir 1000 milisegundos
                    //Thread.Sleep(1000);
                    Console.WriteLine("---");
                    Console.Write(Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("-> {0}", conteo);
                } 
            }


        }


    }
}









