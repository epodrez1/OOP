using System;
using System.Collections.Generic;

namespace lab3
{
    public class MyList<T> : List<T>
    {
        internal class Owner
        {
            public int id;
            public int ID { get; set; }
            public string name;
            public string Name { get; set; }
            public string organization;
            public string Organization { get; set; }
            public Owner()
            {

            }
            public Owner(int a, string b, string c)
            {
                id = a;
                name = b;
                organization = c;
            }
            public override string ToString()
            {
                string st = $"{id} {name} {organization}";
                return st;
            }
        }
        public class Data
        {
            public string date;
            public string DatE { get; set; }
            public Data(string a)
            {
                date = a;
            }
            public Data()
            {

            }
        }
        public int Capasity;
        public string ItemOfList;
        public string itemoflist { get; set; }
        public static MyList<T> operator +(MyList<T> list, MyList<T> Item)
        {
            MyList<T> result = new MyList<T>();
            foreach (T item in list) result.Add(item);
            foreach (T item in Item) result.Add(item);
            return result;
        }
        public static MyList<T> operator --(MyList<T> list)
        {
            list.RemoveAt(list.Count - 1);
            return list;
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as MyList<T>);
        }
        public bool Equals(MyList<T> list)
        {
            if (object.ReferenceEquals(list, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, list))
            {
                return true;
            }
            if (this.GetType() != list.GetType())
            {
                return false;
            }
            return object.ReferenceEquals(this, list);        
        }
        public static bool operator ==(MyList<T> list1, MyList<T> list2)
        {
            return !(list1 != list2);
        }
        public static bool operator !=(MyList<T> list1, MyList<T> list2)
        {
            if (list1.ItemOfList == list2.ItemOfList)
                return false;
            else
                return true;
        }
        public static bool operator true(MyList<T> list)
        {
            if (list.Capacity == 0)
                return true;
            else
                return false;
        }
        public static bool operator false(MyList<T> list)
        {
            if (list.Capacity != 0)
                return true;
            else
                return false;
        }

         
    }
    static public class StaticticOperation
    {
        public static void CountWords(this MyList<string> list)
        {
            int Counter = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                Counter++;
            }
            Console.WriteLine($"Количество слов: {Counter}");
        }

        static public void NullElements(this MyList<string> list)
        {
            int cnt = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list.ItemOfList[i] == null)
                    cnt++;
            }
            if (cnt == 0)
                Console.WriteLine("Нет нулевых элементов");
            else
                Console.WriteLine("Есть нулевые элементы");
        }
        static public void Sum(MyList<string> list)
        {
            string res = "";
            for (int i = 0; i < list.Count - 1; i++)
            {
                res = res + list;
            }
        }
        static public void Diff(MyList<int> list)
        {
            int max = list[0], min = list[0];
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > max)
                    max = list[i];
                if (list[i] < min)
                    min = list[i];
            }
            Console.WriteLine(max - min);
        }
        static public void Amount(MyList<int> list)
        {
            int Counter = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                Counter++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> list = new MyList<string> { "1", "2"};
            MyList<string> item = new MyList<string> { "3"};
            MyList<string> list3 = new MyList<string> { "1", "2"};
            MyList<string> list4 = new MyList<string> { "1"};
            Console.WriteLine("Первый список");
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Элемент для добавления");
            foreach(var i in item)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Добавляем элемент в конец");
            list = list + item;
            foreach (var i in list) 
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Первый список");
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Удаление последнего элемента");
            foreach (var i in list--)
            {
                Console.WriteLine(i);
            }

            if (list4 != list3)
                Console.WriteLine("Разные списки");
            else
                Console.WriteLine("Одинаковые списки");

            MyList<dynamic>.Owner owner = new MyList<dynamic>.Owner(1, "ggrtr", "ergrg");
            Console.WriteLine(owner);

            MyList<string>.Data data = new MyList<string>.Data("01.01.2020");
            Console.WriteLine(data.date);
        }
    }
}
