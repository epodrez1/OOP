using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace lab12
{
    public interface INum
    {
        void Num();
    }
    class Transport : INum
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
        public override string ToString() //override переопределяет поведение свойства
        {
            return $"{GetType()} {type} {number}";
        }
        public void GetInfo(string str) //метод GetInfo выводит все данные на консоль
        {
            Console.WriteLine(str);
        }

        public void Num()
        {
            int i = 0;
            i++;
        }
    }
        public class Train : INum
    {
        public string destination;


        public string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }

        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        private double time;
        public double Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        public const int amount = 100;
        public int amount_kupe;
        public int Amount_kupe
        {
            get
            {
                return amount_kupe;
            }
            set
            {
                amount_kupe = value;
            }
        }
        public int amount_plackart;
        public int Amount_plackart
        {
            get
            {
                return amount_plackart;
            }
            set
            {
                amount_plackart = value;
            }
        }
        public int amount_lux;
        public int Amount_lux
        {
            get
            {
                return amount_lux;
            }
            set
            {
                amount_lux = value;
            }
        }
        static int kolichestvo;

        public Train()
        {
            destination = "";
            number = 100000;
            time = 0.00;
            amount_kupe = 0;
            amount_plackart = 0;
            amount_lux = 0;
            kolichestvo++;
        }
        public Train(string a)
        {
            destination = a;
        }
        public Train(string a, int b, double c, int e, int f, int g)
        {
            destination = a;
            number = b;
            time = c;
            amount_kupe = e;
            amount_plackart = f;
            amount_lux = g;
            kolichestvo++;
        }

        public Train(string a = "", int b = 10000, double c = 0.00, int e = 0, int f = 0)
        {
            destination = a;
            number = b;
            time = c;
            amount_kupe = e;
            amount_plackart = f;
            kolichestvo++;
        }

        static Train()
        {
            Console.WriteLine("Добавлен первый поезд");
            kolichestvo++;
        }
        public int AmountOut(ref int amount, out int Output)
        {
            return Output = amount;
        }
        public void GetInfo(string str)
        {
            Console.WriteLine(str);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Train tr = obj as Train;
            if (tr as Train == null)
                return false;

            return tr.number == this.number;
        }
        public override int GetHashCode()
        {
            int Dest;
            if (destination == "Питер")
                Dest = 1;
            else Dest = 2;
            return (int)amount + Dest;
        }
        public override string ToString()
        {
            return $" {number} {destination} {time}";
        }

        public void Num()
        {
            int i = 0;
            i++;
        }
    }
    static class Reflector                                  //класс рефлектор 
        {
        static public void Build(object obj)                //определение имени сборки 
        {        
            StreamWriter sw = new StreamWriter(@"info.txt", true);
            sw.WriteLine("Имя сборки");
            Type type = obj.GetType();
            sw.WriteLine(type.Assembly.GetName().Name);
            sw.WriteLine("\n");
            sw.Close();
        }
        static public void Constructors(object obj)        //есть ли публичн конструкторы
        {
            StreamWriter sw = new StreamWriter(@"info.txt", true);
            sw.WriteLine("Имена конструкторов");
            Type type = obj.GetType();
            foreach (ConstructorInfo el in type.GetConstructors())
            {
                sw.WriteLine(el.ReflectedType.Name);
            }
            sw.WriteLine("\n");
            sw.Close();
        }
        static public void Methods(object obj)              //ИЗВЛЕКАЕТ общедост МЕТОДЫ ИЗкласса
        {
            StreamWriter sw = new StreamWriter(@"info.txt", true);
            sw.WriteLine("Имена методов");
            Type type = obj.GetType();
            foreach (MethodInfo el in type.GetMethods())
            {
                sw.WriteLine(el.Name);
            }
            sw.WriteLine("\n");
            sw.Close();
        }
        static public void FieldsAndProperties(object obj)  //инфа о полях и свойтсвах класса
        {
            StreamWriter sw = new StreamWriter(@"info.txt", true);
            sw.WriteLine("Имена полей и свойств");
            Type type = obj.GetType();
            foreach (FieldInfo el in type.GetFields())  //поля
            {
                 sw.WriteLine(el.Name);
            }
            sw.WriteLine();
            foreach (PropertyInfo el in type.GetProperties()) //свойства
            {
                 sw.WriteLine(el.Name);
            }
            sw.WriteLine("\n");
            sw.Close();
        }
        static public void Interfaces(object obj)  //получ все реализованные интерфейсы
        {
            StreamWriter sw = new StreamWriter(@"info.txt", true);
            sw.WriteLine("Имена интерфейсов");
            Type type = obj.GetType();
            foreach (Type el in type.GetInterfaces())
            {
                sw.WriteLine(el.Name);
            }
            sw.WriteLine("\n");
            sw.Close();
        }
        static public void MethodsWithParam(object obj, string str)
        {
            StreamWriter sw = new StreamWriter(@"info.txt", true);
            Type type = obj.GetType();
            sw.WriteLine("Метод с параметром");
            foreach (MethodInfo el in type.GetMethods())
            {
                foreach (ParameterInfo elem in el.GetParameters())
                {
                    if (elem.Name.Contains(str))
                    {
                        sw.WriteLine(el.Name);
                    }
                }
            }
            sw.WriteLine("\n");
            sw.Close();
        }
        static public void RunMethod<T>(object obj, string str) where T: class
        {
            StreamReader sr = new StreamReader(@"params.txt");
            string par = sr.ReadLine();
            Type type = obj.GetType();
            MethodInfo info = type.GetMethod(str);
            object obbj = Activator.CreateInstance(typeof(T));
            info.Invoke(obbj, new object[] { par });
        }
        static public T Create<T>(object obj) where T: class     //обобщ метод create
        {
            var constr = obj.GetType().GetConstructor(new Type[] { });
            if (constr != null)
            {
                return (T)constr.Invoke(new object[] { });
            }
            return default(T);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train("Питер", 10000, 13.23, 10, 5, 5);
            Reflector.Build(train);
            Reflector.Constructors(train);
            Reflector.Methods(train);
            Reflector.FieldsAndProperties(train);
            Reflector.Interfaces(train);
            Reflector.MethodsWithParam(train, "str");
            Reflector.RunMethod<Train>(train, "GetInfo");
            Reflector.Create<Train>(train);

            Transport transport = new Transport();
            Reflector.Build(transport);
            Reflector.Constructors(transport);
            Reflector.Methods(transport);
            Reflector.FieldsAndProperties(transport);
            Reflector.Interfaces(transport);
            Reflector.MethodsWithParam(transport, "str");
            Reflector.RunMethod<Transport>(transport, "GetInfo");
            Reflector.Create<Transport>(transport);
        }
    }
}
