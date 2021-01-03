using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab8
{
    public class Transport
    {
        public string type;
        public string Type { get; set; }
        public int number;
        public int Number { get; set; }
        public Transport()
        {

        }
        public Transport(string a = "", int b = 0)
        {
            type = a;
            number = b;
        }
        public override string ToString()
        {
            return $"{GetType()} {type} {number}";
        }
        public class Car : Transport
        {
            public string typeofcar;
            public string TypeOfCar { get; set; }
            public Car()
            {

            }
            public Car(string a = "")
            {
                typeofcar = a;
            }
            public class Motor : Car
            {
                public int volume;
                public int Volume { get; set; }
                public Motor()
                {

                }
                public Motor(int a = 0)
                {
                    volume = a;
                }
                public override bool Equals(object obj)
                {
                    if (obj.GetType() != this.GetType()) return false;

                    Motor motor = (Motor)obj;
                    return (this.volume == motor.volume);
                }
                public override int GetHashCode()
                {
                    return volume.GetHashCode();
                }
                public override string ToString()
                {
                    return $"Объём {volume} метров кубических";
                }
            }
        }
        public class Train : Transport
        {
            public int numberoftrain;
            public int NumberOfTrain { get; set; }
            public Train()
            {

            }
            public Train(int a = 0)
            {
                numberoftrain = a;
            }
            public override string ToString()
            {
                return $"{GetType()} {numberoftrain}";
            }
            public class Express : Train
            {
                public int price;
                public int Price { get; set; }
                public Express()
                {

                }
                public Express(int a = 0)
                {
                    price = a;
                }
                public override string ToString()
                {
                    return $"{GetType()} {price} ";
                }
            }
            public class Motor : Train
            {
                public int volofmotor;
                public int VolOfMotor { get; set; }
                public Motor()
                {

                }
                public Motor(int a = 0)
                {
                    volofmotor = a;
                }
                public override string ToString()
                {
                    return $"{GetType()} {volofmotor}";
                }
            }
            sealed public class Carriage : Train
            {
                public int amountofplaces;
                public int AmountOfPlaces { get; set; }
                public Carriage()
                {

                }
                public Carriage(int a = 0)
                {
                    amountofplaces = a;
                }
                public override string ToString()
                {
                    return $"{GetType()} {amountofplaces}";
                }
            }
        }
    }


    interface IOperations<T>
    {
        void AddItem(T element);
        void DeleteItem(int position);
        void Show();
    }

    class Owner
    {
        public static int id;
        public int ID { get; set; }
        public string name;
        public string Name { get; set; }
        public string organization;
        public string Organization { get; set; }
        public Owner()
        {
            id++;
            ID = id;
        }
        public Owner(string b, string c)
        {
            name = b;
            organization = c;
        }
        public override string ToString()
        {
            string st = $"{id} {name} {organization}";
            return st;
        }
    }

    public class MyList<T> : IEnumerable<T>, IOperations<T> where T : new()
    {
        public int Capasity;
        public string ItemOfList;
        public string itemoflist { get; set; }
        List<T> list = new List<T>();
        public void AddItem(T element)
        {
            list.Add(element);
        }
        public void DeleteItem(int position)
        {
            list.RemoveAt(position - 1);
        }
        public void Show()
        {
            foreach (T el in list)
            {
                Console.WriteLine(el + " ");
            }
        }
        public override string ToString()
        {
            string str = " ";
            foreach (T el in list)
            {
                str += $"{el} ";
            }
            return str;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)list).GetEnumerator();
        }

        Owner owner = new Owner("Dasha", "BSTU");

        class Date
        {
            public DateTime date = new DateTime();
            public Date()
            {
                date = DateTime.Now;
            }
        }
        Date date = new Date();

        public static MyList<T> operator +(MyList<T> list, MyList<T> Item)
        {
            MyList<T> result = new MyList<T>();
            foreach (T item in list) result.AddItem(item);
            foreach (T item in Item) result.AddItem(item);
            return result;
        }
        public static MyList<T> operator --(MyList<T> list)
        {
            int pos = list.Count() - 1;
            list.DeleteItem(pos);
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
            if (list.Capasity == 0)
                return true;
            else
                return false;
        }
        public static bool operator false(MyList<T> list)
        {
            if (list.Capasity != 0)
                return true;
            else
                return false;
        }

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyList<int> list1 = new MyList<int>();
                MyList<double> list2 = new MyList<double>();
                MyList<Transport> list3 = new MyList<Transport>();
                list1.AddItem(1);
                list1.AddItem(2);
                list1.AddItem(3);
                list1.DeleteItem(3);
                list1.Show();

                list2.AddItem(3.5);
                list2.AddItem(4.5);
                list2.AddItem(5.5);
                list2.DeleteItem(2);
                list2.Show();

                Transport tr1 = new Transport("car", 15);
                Transport tr2 = new Transport("car", 25);
                Transport tr3 = new Transport("car", 35);

                list3.AddItem(tr1);
                list3.AddItem(tr2);
                list3.AddItem(tr3);

                list3.DeleteItem(1);
                list3.Show();
                FileStream file = new FileStream("d:\\newtext.txt", FileMode.Create);
                StreamWriter writer = new StreamWriter(file);
                writer.Write(list1.ToString());
                writer.Write("\n");
                writer.Write(list2.ToString());
                writer.Write("\n");
                writer.Write(list3.ToString());
                writer.Close();
                FileStream file1 = new FileStream("d:\\newtext.txt", FileMode.Open);
                StreamReader reader = new StreamReader(file1);
                Console.WriteLine(reader.ReadToEnd());
                reader.Close();
            }
            finally
            {
                Console.WriteLine("Выполнено");
            }
        }
    }
}