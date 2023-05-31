using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Lab_6
{
    [XmlRoot("train")]
    public struct Train: IComparable<Train>
    {
        [XmlElement] public string Destination { get; set; }
        [XmlAttribute] public int Nummer { get; set; }
        [XmlElement] public string DepartureTime { get; set; }

        public Train(string str)
        {
            string[] train = Regex.Split(str,@"\s+");
            Destination = train[0];
            Nummer = Convert.ToInt32(train[1]);
            DepartureTime = train[2];
        }
        public int CompareTo(Train other)
        {
            return Destination.CompareTo(other.Destination);
        }
        public override string ToString()
        {
            return $"{Destination} {Nummer} {DepartureTime}";
        }
    }
}