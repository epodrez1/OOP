using System;

namespace lab
{
    public class Train
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
        private readonly int ID;
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
        static string info = "Класс, для представления информации о поездах и их маршрутах";
        public static string GetInfo()
        {
            return info;
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
       
    }
    class Program
    {
        static void Main(string[] args)
        {
            Train tr = new Train("Питер");
            Console.WriteLine(tr);
            Train tr1 = new Train("Питер", 12345, 17.15, 25, 40, 35);
            Train tr2 = new Train("Москва", 22345, 17.45, 43, 27, 30);
            Train tr3 = new Train("Минск", 32345, 17.30, 19, 30, 51);
            Console.WriteLine(tr1.GetType());
            Train[] trains = new Train[] { tr1, tr2, tr3};
            string dista = Console.ReadLine();
            double time = Convert.ToDouble(Console.ReadLine());
            for (int i = 0; i < trains.Length; i++)
            {
                if (trains[i].destination == dista)
                    Console.WriteLine(trains[i]);
            }
            for (int i = 0; i < trains.Length; i++)
            {
                if (trains[i].destination == dista && trains[i].Time > time)
                    Console.WriteLine(trains[i]);
            }
            var train = new { destination = "smth", Number = 84527, Time = 03.15};
            Console.WriteLine($"{train.destination} {train.Number} {train.Time}");
        }
    }
}
