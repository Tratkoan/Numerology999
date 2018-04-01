﻿using System;
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
        public Numerology999.Root localTable = null;

        public DataWalker(Stream xmlFile)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Root));

            StreamReader reader = new StreamReader(xmlFile);
            localTable = (Root)serializer.Deserialize(reader);
            reader.Close();

        }

        public bool NumberExists(string i)
        {
            return localTable.Row.Any(v => v.Number.Equals(i));
        }

        public bool NumbersExists_(string i)
        {
            return localTable.Row.Any(v => v.Number.Replace(" ","").Split(',').Contains(i));
        }

        public string GetText(string i)
        {
            string result = (from v in localTable.Row
                             where v.Number.Replace(" ", "").Split(',').Contains(i)
                             select v.Text).SingleOrDefault();
            return result;
        }
    }
}