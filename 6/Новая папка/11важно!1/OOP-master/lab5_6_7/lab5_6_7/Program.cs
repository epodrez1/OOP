using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public int Price 
        {
            get { return price; }
            set
            {
                if (value <= 0)
                    throw new Exceptions.PriceException("Цена не может быть меньше 0");
                else
                    price = value;
            }
        }
        public int min_speed;
        public int MinSpeed { get; set; }
        public int max_speed;
        public int MaxSpeed
        {
            get
            {
                return max_speed;
            }
            set
            {
                if (value > 250)
                    throw new Exceptions.SpeedException("Скорость не может принимать такое значение", value);
                else
                    max_speed = value;
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
            public Car(string a, int b, int c, int d, int e) : base(a, b, c, d, e)
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
        public void AddItem(Transport transport)
        {
            _container.Add(transport);
        }
        public void Delete(Transport transport) => _container.Remove(transport);
        public void Print()
        {
            for (int i = 0; i < _container.Count - 1; i++)
            {
                Console.WriteLine(_container[i]);
            }
        }

        public void Add(Transport tra)
        {
            throw new Exceptions.NotImplement("Неправильное значение");
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
            Debug.Assert(list != null, "список не может быть пустым");
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
    class Exceptions
    {
        public class PriceException : Exception
        {
            public PriceException(string message) : base(message)
            {

            }
        }
        public class SpeedException : ArgumentException
        {
            public int Value { get; }
            public SpeedException(string message, int val) : base(message)
            {
                Value = val;
            }
        }
        public class NotImplement : NotImplementedException
        {
            public NotImplement(string message) : base(message)
            {

            }
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Transport transport3 = new Transport { Price = -15000};
            }
            catch (Exceptions.PriceException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Метод: " + ex.TargetSite);
                Console.WriteLine("Источник: " + ex.Source);
            }
            Console.Read();

            try
            {
                Transport transport = new Transport { MaxSpeed = 2500 };
            }
            catch (Exceptions.SpeedException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine($"Некорректное значение: {ex.Value}");
                Console.WriteLine("Метод: " + ex.TargetSite);
                Console.WriteLine("Источник: " + ex.Source);
            }
            Console.Read();

            Transport tr = new Transport();
            try
            {
                int res = tr.Volume / 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine("Метод: " + ex.TargetSite);
                Console.WriteLine("Источник: " + ex.Source);
            }
            Console.Read();

            Transport tra = new Transport();
            tra = null;
            TransportAgency ag = new TransportAgency();
            
            try
            {
                ag.Add(tra);
            }
            catch (Exceptions.NotImplement ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Метод: " + ex.TargetSite);
                Console.WriteLine("Источник: " + ex.Source);
            }
            Console.Read();

            try
            {
                Console.WriteLine(ag._container[3]);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Метод: " + ex.TargetSite);
                Console.WriteLine("Источник: " + ex.Source);
            }
            Console.Read();

            try
            {
                int n = 5;
                int r = n / 0;

                Console.WriteLine(ag._container[-7]);
            }
            catch
            {
                Console.WriteLine("Возникли некоторые ошибки");
            }

            finally
            {
                Console.WriteLine("Блок finally");
            }
        }
    }
}
