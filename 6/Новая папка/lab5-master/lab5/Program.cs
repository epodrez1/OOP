using System;

namespace lab5
{
    interface ICloneable//интерфейс
    {
        void Method();
    }
    public abstract class BaseClass //абстрактный класс
    {
        public abstract void Method();
    }
    public class Land : BaseClass, ICloneable
    {
        public string type;
        public string Type { get; set; }
        public Land()
        {
            type = "land";
        }
        public override string ToString()
        {
            return $"{GetType()} {type}";
        }
        void ICloneable.Method()
        {
            Console.WriteLine("New method 1");
        }
        public override void Method()
        {
            Console.WriteLine("New method 2");
        }

    }
    public class Continent : Land
    {
        public string continentname;
        public string ContinentName { get; set; }
        public Continent(string b = "") : base()
        {
            continentname = b;
        }
        public override string ToString()
        {
            return $"{GetType()} {continentname} ";
        }


    }
    public class State : Continent
    {
        public string statename;
        public string StateName { get; set; }
        public State(string c = "")
        {
            statename = c;
        }
        public override string ToString()
        {
            return $"{GetType()} {statename}";
        }
        public new void DoClone()//реализация одноименного метода 2
        {
            Console.WriteLine("New Method 2 ");
        }
    }

    public class Water
    {
        public string type;
        public string Type { get; set; }
        public Water()
        {
            type = "Water";
        }
        public override string ToString()
        {
            return $"{GetType()} {type}";
        }
        public virtual void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
    public sealed class Sea : Water//запечатанный класс
    {
        public string seaname;
        public string SeaName { get; set; }
        public Sea(string b = "") : base()
        {
            seaname = b;
        }
        public override string ToString()
        {
            return $"{GetType()} {seaname}";
        }
        public override void SayHello()
        {
            Console.WriteLine("Hello 2");
        }

    }
    public class Island : Water
    {
        public string islandname;
        public string IslandName { get; set; }
        public int Square { get; set; }
        public Island(string b = "") : base()
        {
            islandname = b;
        }
        public override bool Equals(object obj)//переопределение методов от Object
        {
            return obj is Island someIsland &&
                   islandname == someIsland.islandname;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(islandname);
        }
        public override string ToString()
        {
            return $"{GetType()} {islandname}";
        }

    }
    class Printer
    {
        public void IAmPrinting(Land someobj)
        {
            Console.WriteLine("\nType of the object - " + someobj.GetType());
            Console.WriteLine(someobj.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Continent africa = new Continent("Africa");
            ((ICloneable)africa).Method();
            africa.Method();
            State belarus = new State("Belarus");
            belarus.DoClone();

            Island kipr = new Island("Madagaskar");
            Sea red = new Sea("ocen");
            Water water = new Water();
            water.SayHello();
            red.SayHello();


            Sea black = water as Sea; //оператор as
            if (black == null)
                Console.WriteLine("\nFail");
            else
                Console.WriteLine("\nSuccess");

            if (kipr is Island)   //оператор is
                Console.WriteLine("Madagaskar is an island");
            else
                Console.WriteLine("madagaskar is not anisland");

            dynamic[] arrayOfObjects = new dynamic[] { africa, belarus };// массив, содержащий ссылки на разнотипные объекты
            Printer printer = new Printer();
            printer.IAmPrinting(africa);
            printer.IAmPrinting(belarus);

        }
    }
}

