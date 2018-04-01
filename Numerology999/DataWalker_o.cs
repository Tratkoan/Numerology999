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
        private enum ColumnIndex : int
        {
            Number,
            Text
        }

        public DataWalker(Stream xmlFile)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Table));

            StreamReader reader = new StreamReader(xmlFile);
            localTable = (Table)serializer.Deserialize(reader);
            reader.Close();

        }

        public bool NumberExists(string i)
        {
            return localTable.Row.Any(v => v.Cell[0].Data.Text.Equals(i));
        }

        public string GetText(string i)
        {
            string result = (from v in localTable.Row
                            where v.GetValue((int) ColumnIndex.Number).Equals(i)
                            select v.GetValue((int) ColumnIndex.Text)).SingleOrDefault();

            return result;
        }
    }
}