using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab10
{
    interface ISet<T>
    {
        void AddEl(T el);
        void DelEl(T el);
        void Find(T el);
        void Print();
    }

    public class Computer : ISet<Computer>
    {
        public int Memory { get; set; }
        public Computer()
        {

        }
        public Computer(int mem)
        {
            this.Memory = mem;
        }
        HashSet<Computer> list = new HashSet<Computer>();
        public void Hash()
        {
            Console.WriteLine(GetHashCode());
        }
        public override string ToString()
        {
            return $"Компьютер с памятью {Memory} Гб";
        }

        public void AddEl(Computer el)
        {
            list.Add(el);
        }

        public void DelEl(Computer el)
        {
            list.Remove(el);
        }

        public void Find(Computer el)
        {
            bool isFound = list.Contains(el);
            if (isFound)
                Console.WriteLine("Есть такой элемент");
            else
                Console.WriteLine("Нет такого элемента");
        }

        public void Print()
        {
            foreach (Computer value in list)
            {
                Console.WriteLine(value);
            }
        }

        

    }
    class Program
    {
        static void Main(string[] args)
        {
            Computer computer1 = new Computer(8);
            Computer computer2 = new Computer(10);
            Computer computer3 = new Computer(16);
            Computer computer4 = new Computer(20);

            HashSet<Computer> computers = new HashSet<Computer>();

            computers.Add(computer2);
            computers.Add(computer2);
            computers.Add(computer3);
            computers.Add(computer4);

            computers.Remove(computer4);

            foreach (Computer value in computers)
            {
                Console.WriteLine(value);
            }

            bool isFound = computers.Contains(computer4);
            if (isFound)
                Console.WriteLine("Есть такой элемент");
            else
                Console.WriteLine("Нет такого элемента");
            bool isFound1 = computers.Contains(computer1);
            if (isFound1)
                Console.WriteLine("Есть такой элемент");
            else
                Console.WriteLine("Нет такого элемента");

            HashSet<int> coll = new HashSet<int>();
            coll.Add(1);
            coll.Add(2);
            coll.Add(3);
            coll.Add(4);
            coll.Add(5);
            coll.Add(6);

            foreach (int value in coll)
            {
                Console.WriteLine(value);
            }
            
            for (int i = 1; i <= 3; i++)
            {
                coll.Remove(i);
            }

            foreach (int value in coll)
            {
                Console.WriteLine(value);
            }

            Queue<int> vs = new Queue<int>();
            vs.Enqueue(1);
            vs.Enqueue(2);
            vs.Enqueue(3);
            vs.Enqueue(4);
            vs.Enqueue(5);
            vs.Enqueue(6);

            foreach(int value in vs)
            {
                Console.WriteLine(value);
            }

            bool Is = vs.Contains(5);
            if (Is)
                Console.WriteLine("Есть такой элемент");
            else
                Console.WriteLine("Нет такого элемента");

            void Method(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Computer newComp = e.NewItems[0] as Computer;
                        Console.WriteLine($"Добавлен новый объект: {newComp.Memory}");
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Computer oldComp = e.OldItems[0] as Computer;
                        Console.WriteLine($"Удалён объект: {oldComp.Memory}");
                        break;
                }
            }

            ObservableCollection<Computer> c = new ObservableCollection<Computer>();
            c.CollectionChanged += Method;

            c.Add(computer1);
            c.Add(computer2);
            c.Add(computer3);
            c.Add(computer4);

            c.Remove(computer3);
        }

        
    }
}
