using System;

namespace lab5
{
    interface ICloneable
    {
        void DoClone();
    }
    abstract class BaseClone
    {
        public void DoClone()
        {
            Console.WriteLine("Абстрактный класс");
        }
    }
    class Transport : BaseClone
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
                    return $"Объём {volume} метров кубических" ;
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
    class Program
    {
        static void Main(string[] args)
        {
            Transport transport = new Transport("type", 111);
            transport.DoClone();
            Transport.Car car = new Transport.Car("name");
            car.DoClone();
            Transport.Train train = new Transport.Train(222);
            train.DoClone();
            Transport.Car.Motor motor = new Transport.Car.Motor(30);
            motor.DoClone();
            Transport.Train.Motor motor1 = new Transport.Train.Motor(40);
            Transport.Train.Express express = new Transport.Train.Express(555);
            express.DoClone();
            Transport.Train.Carriage carriage = new Transport.Train.Carriage(60);
            carriage.DoClone();
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
        }
    }
}
