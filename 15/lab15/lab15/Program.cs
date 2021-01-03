using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Threading;

namespace lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            Procc();
            Console.ReadLine();
            Dom();
            Console.ReadLine();
            NewThr();
            Console.ReadLine();
            NewThr2();
            Console.ReadLine();
            NewThr21();
            Console.ReadLine();
            int num = 0;
            TimerCallback timer = new TimerCallback(Countt);
            Timer tm = new Timer(timer, num, 0, 2000);
        }

        static public void Procc()          //все запущенные процессы
        {
            foreach (Process process in Process.GetProcesses())
            {
                Console.WriteLine($"ID {process.Id}, имя {process.ProcessName}, приоритет {process.BasePriority}");
            }
        }
        static public void Dom()            //текущий домен приложения
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Имя {domain.FriendlyName}, детали конфигурации {domain.SetupInformation}");
            Console.WriteLine("сборки");
            foreach (Assembly i in domain.GetAssemblies())
            {
                Console.WriteLine(i);
            }
        }
        static public void NewThr() // новый поток
        {
            Console.Write("Введите число: ");
            int n = int.Parse(Console.ReadLine());
            Thread thread = new Thread(new ParameterizedThreadStart(Count));
            thread.Start(n);            
            Console.WriteLine(thread.ThreadState);
            Console.WriteLine(thread.Name);
            Console.WriteLine(thread.Priority);
            Console.WriteLine(thread.ManagedThreadId);
        }
        static public void Count(object n)          //подсчет чисел и задержка в конце
        {
            int num = (int)n;
            for (int i = 1; i <= num; i++)
            {
                Console.Write(i + " ");
                Thread.Sleep(500);
            }
        }

        static public void NewThr2() // второй поток
        {
            Thread FirstThread = new Thread(new ParameterizedThreadStart(Even));
            Thread SecondThread = new Thread(new ParameterizedThreadStart(NotEven));
            Console.Write("Введите число: ");
            int n = int.Parse(Console.ReadLine());
            
            SecondThread.Priority = ThreadPriority.Highest;
            SecondThread.Start(n);
            FirstThread.Start(n);
        }

        static public void NewThr21()
        {
            Thread FirstThread = new Thread(new ParameterizedThreadStart(Even1));
            Thread SecondThread = new Thread(new ParameterizedThreadStart(NotEven1));
            Console.Write("Введите число: ");
            int n = int.Parse(Console.ReadLine());
            
            FirstThread.Start(n);
            SecondThread.Start(n);
        }

        static object locker = new object();

        static public void Even(object n)
        {
            int num = (int)n;
            lock (locker)
            {
                for (int i = 1; i <= num; i = i + 2)
                {
                    Console.Write(i + " ");
                    Thread.Sleep(200);
                }
            }
        }

        static public void NotEven(object n)
        {
            
            lock (locker)
            {
                int num = (int)n;
                Thread.Sleep(100);
                for (int i = 2; i <= num; i = i + 2)
                {
                    Console.Write(i + " ");
                    Thread.Sleep(200);
                }
            }
        }

        static public void Even1(object n)
        {
            int num = (int)n;
            for (int i = 1; i <= num; i = i + 2)
            {
                Console.Write(i + " ");
                Thread.Sleep(500);
            }
        }

        static public void NotEven1(object n)
        {
            int num = (int)n;
            for (int i = 2; i <= num; i = i + 2)
            {
                Console.Write(i + " ");
                Thread.Sleep(500);
            }
        }

        public static void Countt(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine($"{x * i}");
            }
        }
    }
}
