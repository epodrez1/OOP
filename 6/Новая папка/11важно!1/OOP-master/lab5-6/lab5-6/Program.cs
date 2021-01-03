using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace lab5_6
{
    interface ICloneable
    {
        void DoClone();
    }
    interface ICloneable1
    {
        void DoClone();
    }
    public abstract class BaseClone
    {
        abstract public void DoClone();
        public BaseClone()
        {

        }
    }
    public class Transport : BaseClone, ICloneable, ICloneable1
    {
        void ICloneable.DoClone()
        {
            Console.WriteLine("interface 1");
        }
        void ICloneable1.DoClone()
        {
            Console.WriteLine("interface 2");
        }
        public override void DoClone()
        {
            Console.WriteLine("Abstract");
        }
        public string type;
        public string Type { get; set; }
        public int volume;
        public int Volume { get; set; }
        public int price;
        public int Price { get; set; }
        public int min_speed;
        public int MinSpeed { get; set; }
        public int max_speed;
        public int MaxSpeed { get; set; }

        public enum Age
        {
            New,
            Old
        }
        public struct Structura
        {
            public string text;
            public int value;
            public Structura(string a, int b)
            {
                text = a;
                value = b;
            }
        }
        public Transport()
        {

        }
        public Transport(string a = "", int b = 0, int min = 0, int max = 0, int vol = 0)
        {
            type = a;
            price = b;
            min_speed = min;
            max_speed = max;
            volume = vol;
        }
        public override string ToString()
        {
            return $"Тип транспорта: {type}, цена: {price}, минимальная скорость: {min_speed}, максимальная скорость: {max_speed}, объём двигателя: {volume}";
        }
        public partial class Car : Transport
        {
            public string typeofcar;
            public string TypeOfCar { get; set; }
            public Car() : base()
            {

            }
            public Car(string a, int b, int c, int d, int e) : base(a,b,c,d,e)
            {
                this.TypeOfCar = a;
                this.Price = b;
                this.MinSpeed = c;
                this.MaxSpeed = d;
                this.Volume = e;
            }
            public class Motor : Car
            {
                public int volumeofmotor;
                public int VolumeOfMotor { get; set; }
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
        public class Train : Transport, ICloneable
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
            public new void DoClone()
            {
                Console.WriteLine($"Интерфейс {numberoftrain}");
            }
            public class Express : Train
            {
                public int priceexp;
                public int PriceExpress { get; set; }
                public Express()
                {

                }
                public Express(int a = 0)
                {
                    price = a;
                }
                public override string ToString()
                {
                    return $"{GetType()} {priceexp} ";
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
            sealed public class Carriage : Train, ICloneable
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
                public new void DoClone()
                {
                    Console.WriteLine($"Интерфейс {amountofplaces}");
                }
            }
        }

    }
    class Printer
    {
        public void IAmPrinting(Transport someobj)
        {
            Console.WriteLine($"Тип объекта - " + someobj.GetType());
            Console.WriteLine(someobj.ToString());
        }
    }
    public class TransportAgency
    {
        public string Name { get; set; }
        public Transport.Car car;
        public Transport tr;        
        public List<Transport> _container { get; set; }
        public TransportAgency()
        {
            _container = new List<Transport>();
        }

        public Transport this[int index]
        {
            get { return _container[index]; }
            set { _container[index] = value; }
        }
        public override string ToString()
        {
            return base.ToString() + $"\nName: {Name}";
        }
        public void AddItem(Transport transport) => _container.Add(transport);
        public void Delete(Transport transport) => _container.Remove(transport);
        public void Print()
        {
            for (int i = 0; i < _container.Count - 1; i++)
            {
                Console.WriteLine(_container[i]);
            }
        }
    }
    public static class TransportController
    {
        public static void Sum(List<Transport> list)
        {
            int sum = 0;
            foreach (Transport tr in list)
            {
                sum += tr.Price;
            }
            Console.WriteLine(sum);
        }
        public static void SortByFuel(List<Transport> list)
        {
            var linq = (from Transport.Car c in list
                        orderby c.Volume ascending
                        select c) as List<Transport>;
            var lambda = list.OrderBy(c => c.Volume).ToList();
            foreach (var el in lambda)
                Console.WriteLine(el);
        }
        public static void BySpeed(List<Transport> list)
        {
            Console.WriteLine("Введите минимальную скорость");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите максимальную скорость");
            int max = Convert.ToInt32(Console.ReadLine());
            foreach (var el in list)
            {
                if (el.min_speed == min && el.max_speed == max)
                    Console.WriteLine(el);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Transport transport = new Transport("transport", 10000, 60, 120, 8);
            transport.DoClone();
            ((ICloneable)transport).DoClone();
            ((ICloneable1)transport).DoClone();

            Transport.Car car = new Transport.Car("car", 20000, 55, 100, 8);
            Transport.Train train = new Transport.Train(222);
            Transport.Car.Motor motor = new Transport.Car.Motor(30);
            Transport.Train.Motor motor1 = new Transport.Train.Motor(40);
            Transport.Train.Express express = new Transport.Train.Express(555);
            Transport.Train.Carriage carriage = new Transport.Train.Carriage(60);

            if (train is Transport)
                Console.WriteLine("Train is transport");
            else
                Console.WriteLine("Train is not transport");
            Transport.Car car1 = transport as Transport.Car;
            if (car1 == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                Console.WriteLine("Преобразование прошло удачно");
            }

            dynamic[] arrayOfTransport = new dynamic[] { train, transport, carriage, car };
            Printer printer = new Printer();
            printer.IAmPrinting(train);
            printer.IAmPrinting(car);
            printer.IAmPrinting(carriage);

            Transport transport1 = new Transport("transport", 15000, 80, 120, 9);
            Transport transport2 = new Transport("transport", 17000, 80, 120, 7);

            Transport.Car car2 = new Transport.Car("car", 30000, 120, 200, 2);


            TransportAgency agency = new TransportAgency();
            agency.AddItem(car);
            agency.AddItem(transport1);
            agency.AddItem(transport2);
            agency.AddItem(car2);

            agency.Print();

            TransportController.Sum(agency._container);
            TransportController.SortByFuel(agency._container);
            TransportController.BySpeed(agency._container);

            Transport.Structura structura = new Transport.Structura("text", 5);
            Console.WriteLine(structura);

            Console.WriteLine(Transport.Age.Old);
        }
    }
}
