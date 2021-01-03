using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(() =>                  //задача на основе task
            {
                Console.WriteLine("Введите n");
                int n = int.Parse(Console.ReadLine());
                int[] arr = new int[n];


                for (int i = 0; i < n; i++)
                {
                    arr[i] = 1;
                }

                for (int i = 2; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (j % i == 0)
                            arr[j] = 0;
                        else
                            continue;
                    }
                }
                Console.WriteLine("Напротив простых чисел - 1, напротив остальных - 0");
                for (int h = 1; h < n; h++)
                    Console.WriteLine($"{h}   {arr[h]}");
            });

            Stopwatch watch = new Stopwatch();
            watch.Start();
            task.Start();
            watch.Stop();

            TimeSpan time = watch.Elapsed;

            Console.WriteLine($"Task {task.Id}: {task.Status}\n");          //идентификатор текущей задачи и статус
            Console.WriteLine("RunTime " + time);                           //время выполнения
            Console.ReadKey();
            Console.Clear();

            CancellationTokenSource cancellation = new CancellationTokenSource();
            CancellationToken token = cancellation.Token;

            Task task1 = new Task(() =>
            {
                Console.WriteLine("Введите число n");
                int n = int.Parse(Console.ReadLine());
                int[] arr = new int[n];


                for (int i = 0; i < n; i++)
                {
                    arr[i] = 1;
                }

                for (int i = 2; i < n; i++)
                {
                    
                    for (int j = i + 1; j < n; j++)
                    {
                        
                        if (j % i == 0)
                            arr[j] = 0;
                        else
                            continue;
                    }
                }
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана");
                }
                else
                {
                    Console.WriteLine("Напротив простых чисел - 1, напротив остальных - 0");
                    for (int h = 1; h < n; h++)
                        Console.WriteLine($"{h}   {arr[h]}");
                }
                
            });

            task1.Start();

            Console.WriteLine("Введите Q для отмены операции или другой символ для её продолжения: ");
            string str = Console.ReadLine();
            if (str == "Q")
                cancellation.Cancel();              //токен отмены

            Console.ReadLine(); 
            
            Task<int> Task1 = new Task<int>(() => Multi(3, 5));
            Task1.Start();

            Task<int> Task2 = new Task<int>(() => Divide(4, 2));
            Task2.Start();

            Task<int> Task3 = new Task<int>(() => Minus(10, 8));
            Task3.Start();

            Task<int> Task4 = new Task<int>(() => Task1.Result + Task2.Result + Task3.Result);
            Task4.Start();

            Console.WriteLine(Task1.Result);
            Console.WriteLine(Task2.Result);
            Console.WriteLine(Task3.Result);
            Console.WriteLine(Task4.Result);

            Task<int> tasK1 = new Task<int>(() => Multi(7, 8));

            Task tasK2 = tasK1.ContinueWith(mul => Show(mul.Result));           //планировка на основе завершения множества предшествующих задач

            tasK1.Start();

            tasK2.Wait();
            Console.ReadLine();

            Random rand = new Random();

            Task<int> what = Task.Run(() => rand.Next(10) * rand.Next(10));

            var awaiter = what.GetAwaiter();            //получаем объект типа awaiter, используемый для данного объекта Task

            awaiter.OnCompleted(() =>                   //задаем действие выполн. когда awaiter перестает ждать завершения  задачи
            {
                Console.WriteLine("Result: " + awaiter.GetResult());
            });

            Console.ReadLine();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, 5, BigArr);             //распараллеливаем вычисления для for
            stopwatch.Stop();
            TimeSpan span = stopwatch.Elapsed;
            Console.WriteLine($"Время: {span}");

            Console.ReadLine();

            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            ParallelLoopResult result = Parallel.ForEach<int>(list, BigArr);    //результат параллельных вычисления для foreach
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            Parallel.For(0, 5, BigArr);
            stopwatch1.Stop();
            TimeSpan span1 = stopwatch.Elapsed;
            Console.WriteLine($"Время: {span1}");

            Console.ReadLine();

            Parallel.Invoke(CurTask,                        //распараллелить выполнение блоков операторов
                () =>
                {
                },
                () => Multi(5, 19));

            Console.ReadLine();

            ArrAsynk();
        }


        static int Multi(int x, int y)
        {
            int result;
            result = x * y;
            return result;
        }
        
        static int Divide(int x, int y)
        {
            int result;
            result = x / y;
            return result;
        }

        static int Minus(int x, int y)
        {
            int result;
            result = x - y;
            return result;
        }

        static void Show(int r)
        {
            Console.WriteLine($"Результат: {r}");
        }

        static public void BigArr(int x)
        {

            Random rand = new Random();
            int[] arr = new int[1000000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(10);
            }
            Thread.Sleep(8000);
        }

        static void CurTask()
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
        }

        static async void ArrAsynk()                //асинхронное выполнение метода
        {
            Console.WriteLine("Начало метода");
            await Task.Run(() => BigArr(5));
            Console.WriteLine("Конец метода");
        }
            
    }

    
}
