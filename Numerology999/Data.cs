using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Numerology999
{
    [XmlRoot(ElementName = "Data")]
    public class Data
    {
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Cell")]
    public class Cell
    {
        [XmlElement(ElementName = "Data")]
        public Data Data { get; set; }
        [XmlAttribute(AttributeName = "StyleID")]
        public string StyleID { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class Row
    {
        [XmlElement(ElementName = "Cell")]
        public List<Cell> Cell { get; set; }
        [XmlAttribute(AttributeName = "Height")]
        public string Height { get; set; }
        [XmlAttribute(AttributeName = "AutoFitHeight")]
        public string AutoFitHeight { get; set; }
    }

    [XmlRoot(ElementName = "Table")]
    public class Table
    {
        [XmlElement(ElementName = "Row")]
        public List<Row> Row { get; set; }
    }
}