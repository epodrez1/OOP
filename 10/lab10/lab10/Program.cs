using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab10
{
    interface ISet<T>                                  //интерфейс iset
    {
        void AddEl(T el);
        void DelEl(T el);
        void Find(T el);
        void Print();
    }

    public class Computer : ISet<Computer>          //класс компьютер с интерфейсом iset
    {
        public int Memory { get; set; }
        public Computer()
        {

        }
        public Computer(int mem)
        {
            this.Memory = mem;
        }
        HashSet<Computer> list = new HashSet<Computer>();   //коллекция hashset
        public void Hash()
        {
            Console.WriteLine(GetHashCode()); //Метод GetHashCode позволяет возвратить некоторое числовое значение, которое будет соответствовать данному объекту или его хэш-код
        }
        public override string ToString() //Метод ToString() возвращает символьную строку
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
            Computer computer1 = new Computer(8);    //создаем объекты класса computer
            Computer computer2 = new Computer(10);
            Computer computer3 = new Computer(16);
            Computer computer4 = new Computer(20);

            HashSet<Computer> computers = new HashSet<Computer>();   //создаем коллекцию

            computers.Add(computer1);                               //добавляем в нее объекты класса
            computers.Add(computer2);
            computers.Add(computer3);
            computers.Add(computer4);

            computers.Remove(computer4);                    //удаляем из коллекции

            foreach (Computer value in computers)
            {
                Console.WriteLine(value);           //вывод коллекции
            }

            bool isFound = computers.Contains(computer4); //проверка есть ли такой объект в колеекции
            if (isFound)
                Console.WriteLine("Есть такой элемент");
            else
                Console.WriteLine("Нет такого элемента");
            bool isFound1 = computers.Contains(computer1);
            if (isFound1)
                Console.WriteLine("Есть такой элемент");
            else
                Console.WriteLine("Нет такого элемента");

            HashSet<int> coll = new HashSet<int>(); //новая коллекция
            coll.Add(1);
            coll.Add(2);
            coll.Add(3);
            coll.Add(4);
            coll.Add(5);
            coll.Add(6);

            foreach (int value in coll)
            {
                Console.WriteLine(value);           //вывод новой коллекции
            }
            
            for (int i = 1; i <= 3; i++)
            {
                coll.Remove(i);                     //удаляем 1,2,3
            }
            Console.WriteLine("новая коллекция");
            foreach (int value in coll)
            {
                Console.WriteLine(value);
            }

            Queue<int> vs = new Queue<int>();       //новая коллекция 3
            vs.Enqueue(1);
            vs.Enqueue(2);
            vs.Enqueue(3);
            vs.Enqueue(4);
            vs.Enqueue(5);
            vs.Enqueue(6);
            Console.WriteLine("третья коллекция");
            foreach (int value in vs)
            {
                Console.WriteLine(value);
            }

            bool Is = vs.Contains(5);
            if (Is)
                Console.WriteLine("Есть такой элемент");
            else
                Console.WriteLine("Нет такого элемента");

            void Method(object sender, NotifyCollectionChangedEventArgs e)    //метод наблюдаемой коллекции
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

            ObservableCollection<Computer> c = new ObservableCollection<Computer>();  //объект наблюд. коллекции
            c.CollectionChanged += Method;  //регистрируем метод на событие collectionchange

            c.Add(computer1);        //добавляем с помощью  метода
            c.Add(computer2);
            c.Add(computer3);
            c.Add(computer4);

            c.Remove(computer3);    // удаляем с помощью метода
        }

        
    }
}
