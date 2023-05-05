using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Lab_6
{
    [XmlRoot("train")]
    public struct Train
    {
        [XmlElement] 
        public string _ziel;
        [XmlElement]
        public int _nummer;
        [XmlElement]
        public string _abfahrt;
        //public Train(string str)
        //{
        //    string[] train = Regex.Split(str,@"\s+");
        //    _ziel = train[0];
        //    _nummer = Convert.ToInt32(train[1]);
        //    _abfahrt = train[2];
        //}
        public override string ToString()
        {
            return $"{_ziel} {_nummer} {_abfahrt}";
        }
    }
}