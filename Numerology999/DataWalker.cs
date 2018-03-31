using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace Numerology999
{
    class DataWalker
    {
        public Numerology999.Table localTable = null;

        public DataWalker(Stream xmlFile)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Table));

            StreamReader reader = new StreamReader(xmlFile);
            localTable = (Table)serializer.Deserialize(reader);
            reader.Close();

        }
    }
}