using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Lab_6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Train[] trains = new Train[1];
            for (int i = 0; i < trains.Length; i++)
            {
                trains[i]._ziel = Console.ReadLine();
                trains[i]._nummer = Convert.ToInt32(Console.ReadLine());
                trains[i]._abfahrt = Console.ReadLine();
            }
            SaveInTxtFile(trains);
        }
        public static void SaveInTxtFile(Train[] trains)
        {
            FileStream fileName = File.Open(@"trains.txt", FileMode.Open);
            using (var StringWriter = new StreamWriter(fileName))
                {
                    foreach (Train train in trains)
                    {
                        StringWriter.WriteLine($"{train._ziel} {train._nummer} {train._abfahrt}");
                    }
                }

        }
    }
}