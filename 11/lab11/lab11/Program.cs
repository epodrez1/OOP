using System;
using System.Collections.Generic;
using System.Linq;

namespace lab11
{
    public class Train // класс Train
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
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Train tr = obj as Train;
            if (tr as Train == null)
                return false;

            return tr.number == this.number;
        }
        public override int GetHashCode() //Метод GetHashCode позволяет возвратить некоторое числовое значение, которое будет соответствовать данному объекту или его хэш-код
        {
            int Dest;
            if (destination == "Питер")
                Dest = 1;
            else Dest = 2;
            return (int)amount + Dest;
        }
        public override string ToString()
        {
            return $" {number} {destination} {time} {amount_kupe}";
        }
    }
        class Program
    {
        static void Main(string[] args)
        {                                   //массив типа string содержащий 12 месяцев
            string[] months = {"June", "July", "May", "December", "January", "February", "March", "April", "August", "September", "October", "November"};

            var selected = from m in months
                           where (m.Length <= 5)    //с определ. длиной строки
                           select m;
            Console.WriteLine("с определ. длиной строки");
            foreach (string s in selected)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("_____________________");
            var selected1 = from m in months
                            where (m.ToUpper().StartsWith("D") || m.ToUpper().StartsWith("J") || m.ToUpper().StartsWith("F") || m.ToUpper().StartsWith("M") || m.ToUpper().StartsWith("A"))
                            select m;    
            
            foreach (string s in selected1)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("_____________________");

            var selected2 = from m in months        //алфавитный порядок
                            orderby m
                            select m;
            Console.WriteLine("алфавитный порядок");

            foreach (string s in selected2)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("_____________________");
            Console.WriteLine("содерж букву u и длиной имени не мен 4-х");

            var selected3 = from m in months
                            where (m.Contains("u") && m.Length >= 4)  //содерж букву u и длиной имени не мен 4-х
                            select m;                                    
            foreach (string s in selected3)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("_____________________");


            List<Train> trains = new List<Train>(); //коллекция параметризир классом

            Train train1 = new Train("Питер", 1, 07.15, 15, 7, 8);
            Train train2 = new Train("Москва", 2, 17.20, 30, 28, 2);
            Train train3 = new Train("Москва", 3, 08.50, 15, 7, 8);
            Train train4 = new Train("Минск", 4, 18.53, 45, 27, 28);
            Train train5 = new Train("Витебск", 5, 06.50, 13, 7, 6);
            Train train6 = new Train("Питер", 6, 08.20, 15, 7, 8);
            Train train7 = new Train("Гомель", 7, 11.15, 19, 11, 8);
            Train train8 = new Train("Гомель", 8, 19.50, 15, 6, 9);

            trains.Add(train1);
            trains.Add(train2);
            trains.Add(train3);
            trains.Add(train4);
            trains.Add(train5);
            trains.Add(train6);
            trains.Add(train7);
            trains.Add(train8);

            Console.WriteLine("вывести список следующий до заданного пункта назначения");
            var select1 = from tr in trains
                          where tr.destination == "Питер"    // вывести список следующий до заданного пункта назначения
                          select tr;

            foreach (Train train in select1)
            {
                Console.WriteLine(train);
            }
            Console.WriteLine("_____________________");

            Console.WriteLine("до заданного пункта назначения и отправл после 5.15");
            var select2 = from tr in trains
                          where (tr.destination == "Москва" && tr.Time > 5.15)// вывести список следующий до заданного пункта назначения
                          select tr;                                    // и отправл после 5.15

            foreach (Train train in select2)
            {
                Console.WriteLine(train);
            }
            Console.WriteLine("_____________________");

            Console.WriteLine("макс поезд по кол-ву мест");
            int max = trains.Max(a => a.amount_kupe);       // макс поезд по кол-ву мест
            var select3 = from tr in trains
                          where tr.amount_kupe == max
                          select tr;
            foreach (Train train in select3)
            {
                Console.WriteLine(train);
            }
            Console.WriteLine("_____________________");

            Console.WriteLine("по пункту назнач ");
            var select4 = trains.Take(5).OrderByDescending(t => t.destination);
            foreach (Train train in select4)
            {
                Console.WriteLine(train);
            }
            Console.WriteLine("_____________________");

            var select5 = trains.OrderBy(t => t.destination); // по пункту назнач в алфав порядке
            foreach (Train train in select5)
            {
                Console.WriteLine(train);
            }


            var myselect = trains.Where(tr => tr.amount_kupe > 10).OrderBy(tr => tr.Time).TakeWhile(tr => tr.Number != 4).Take(3).Select(tr => tr);


            var Select = from tr in trains
                         join m in months on tr.amount_kupe equals m.Length     // свобств запрос с join
                         select tr;

        }
    }
}
