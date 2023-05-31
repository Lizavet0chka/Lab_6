using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace Lab_6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Введіть кількість поїздів: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Train[] trains = new Train[n];
            for (int i = 0; i < trains.Length; i++)
            {
                trains[i].Destination = Console.ReadLine();
                trains[i].Nummer = Convert.ToInt32(Console.ReadLine());
                trains[i].DepartureTime = Console.ReadLine();
            }
            Array.Sort(trains);
            SaveInTxt(trains);
            SaveInXml(trains);
            Console.Write("Введіть час (через \":\"): ");
            string[] time = Console.ReadLine().Trim().Split(':');
            int hour = Convert.ToInt32(time[0]);
            int minutes = Convert.ToInt32(time[1]);
            Train[] txt = ReadTxt();
            Train[] xml = ReadXml();
            Console.WriteLine("Прочитані з txt");
            TrainFromTxt(ref txt, hour, minutes);
            Console.WriteLine("Прочитані з xml");
            TrainFromXml(ref xml, hour, minutes);
        }
        public static void TrainFromXml(ref Train[] xml, int hour, int minutes)
        {
            
            for (int i = 0; i < xml.Length; i++)
            {
                string time = xml[i].DepartureTime;
                string[] HandM = time.Split(':');
                int h = Convert.ToInt32(HandM[0]);
                int m = Convert.ToInt32(HandM[1]);
                if (h>=hour && m>minutes || h>hour)
                {
                    Console.WriteLine(xml[i]);
                }
            }
        }
        public static void TrainFromTxt(ref Train[] txt, int hour, int minutes)
        {
            
            for (int i = 0; i < txt.Length; i++)
            {
                string time = txt[i].DepartureTime;
                string[] HandM = time.Split(':');
                int h = Convert.ToInt32(HandM[0]);
                int m = Convert.ToInt32(HandM[1]);
                if (h>=hour && m>minutes || h>hour)
                {
                    Console.WriteLine(txt[i]);
                }
            }
        }
        public static void SaveInTxt(Train[] trains)
        {
            FileStream fileName = File.Open(@"trains.txt", FileMode.Open);
            using (var StringWriter = new StreamWriter(fileName))
                {
                    foreach (Train train in trains)
                    {
                        StringWriter.WriteLine($"{train.Destination} {train.Nummer} {train.DepartureTime}");
                    }
                }
        }
        public static void SaveInXml(Train[] trains)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Train[]));
            using (var x = File.OpenWrite("trains.xml"))
            {
                xml.Serialize(x,trains);
            }
        }

        public static Train[] ReadTxt()
        {
            string[] lines = File.ReadAllLines("trains.txt");
            Train[] train = new Train[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {                                
                train[i] = new Train(lines[i]);
            }
            return train;
        }
        public static Train[] ReadXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Train[]));
            using (FileStream fs = new FileStream("trains.xml", FileMode.OpenOrCreate))
            {
                Train[] train = xmlSerializer.Deserialize(fs) as Train[];
                return train;
            }
        }
    }
}