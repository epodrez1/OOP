using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

namespace lab14
{
    [Serializable]                  //атрибут который показывает что класс может быть сериализован
    public class Transport            //класс для сериализации
    {
       
        public string type;
        public string Type { get; set; }
        [NonSerialized]                 //показывает что поле класса не должно сериализоваться
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
            Type = a;
            price = b;
            Price = b;
            min_speed = min;
            MinSpeed = min;
            max_speed = max;
            MaxSpeed = max;
            volume = vol;
            Volume = vol;
        }
        public override string ToString()
        {
            return $"Тип транспорта: {type}, цена: {price}, минимальная скорость: {min_speed}, максимальная скорость: {max_speed}, объём двигателя: {volume}";
        }
        
        
        
            
        

    }

    class Program
    {
        static void Main(string[] args)
        {
            Transport transport = new Transport("str", 1, 2,3,4);    //объект класса транспорт
            Console.WriteLine("Объект создан");

            BinaryFormatter bf = new BinaryFormatter();             //объект класса BinaryFormatter

            using (FileStream fs = new FileStream("transport.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, transport);               //используем метод для того чтобы сериализовать

                Console.WriteLine("Объект сериализован в формате Binary");
            }

            using (FileStream fs = new FileStream("transport.dat", FileMode.OpenOrCreate))
            {
                Transport newtransport = (Transport)bf.Deserialize(fs); // дисериализация объекта

                Console.WriteLine("Объект дисериализован");
                Console.WriteLine($"Транспорт {newtransport.type}, {newtransport.volume}");
            }

            Console.ReadLine();

            string json = JsonSerializer.Serialize<Transport>(transport);           //  сериализуем объект типа транспорт с помощью метода класса jsonSerializer
            Console.WriteLine(json);
            Transport restoredTransport = JsonSerializer.Deserialize<Transport>(json);  //  десериализуем объект типа транспорт с помощью метода класса jsonSerializer
            Console.WriteLine(restoredTransport.Type, restoredTransport.Volume);

            Console.ReadLine();

            XmlSerializer xml = new XmlSerializer(typeof(Transport));

            using (FileStream fs = new FileStream("transport.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, transport);
                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("transport.xml", FileMode.OpenOrCreate))
            {
                Transport newTransport = (Transport)xml.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine(newTransport.type, newTransport.volume);
            }

            Console.ReadLine();

            Transport transport1 = new Transport("str1", 2, 3, 4, 5);
            Transport[] transports = new Transport[] { transport, transport1 };

            using (FileStream fs = new FileStream("transport.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, transports);

                Console.WriteLine("Объект сериализован в формате Binary");
            }

            using (FileStream fs = new FileStream("transport.dat", FileMode.OpenOrCreate))
            {
                Transport[] newtransport = (Transport[])bf.Deserialize(fs);

                Console.WriteLine("Объект дисериализован");
                foreach (Transport tr in transports)
                {
                    Console.WriteLine($"Транспорт {tr.type}, {tr.volume}");
                }
            }

            Console.ReadLine();
            XmlSerializer xml1 = new XmlSerializer(typeof(Transport[]));
            using (FileStream fs = new FileStream("transport1.xml", FileMode.OpenOrCreate))
            {
                xml1.Serialize(fs, transports);
                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("transport1.xml", FileMode.OpenOrCreate))
            {
                Transport[] newTransport = (Transport[])xml1.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                foreach (Transport tr in transports)
                {
                    Console.WriteLine(tr.type, tr.volume);
                }
            }

            Console.ReadLine();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("transport1.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlNode child = xRoot.SelectSingleNode("Transport[Type='str']");    //селектор для xml выбирает первый узел xml который совпадает с выражением XPath
            if (child != null)
                Console.WriteLine(child.OuterXml);

            XmlNodeList list = xRoot.SelectNodes("//Transport/min_speed");      //селектор для xml выбирает список узлов min_speed
            foreach (XmlNode node in list)
                Console.WriteLine(node.InnerText);

            Console.ReadLine();

            XDocument xdoc = XDocument.Load("transport1.xml");
            var items = from xe in xdoc.Element("ArrayOfTransport").Elements("Transport")
                        where xe.Element("Type").Value == "str"
                        select new Transport
                        {
                            Type = xe.Element("type").Value
                        };

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Type}");
            }
        }

    }
}
