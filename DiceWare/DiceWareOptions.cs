using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DiceWare
{
    [Serializable()]
    public class DiceWareOptions
    {
        public int WordCount { get; set; }

        public DiceWareOptions()
        {
            Default();
        }

        public DiceWareOptions(string opt)
            : this()
        {
            this.Load(opt);
        }

        public void Load(string opt)
        {
            if (opt == "")
            {
                Default();
                return;
            }

            try
            {
                using (var s = new MemoryStream(Convert.FromBase64String(opt)))
                {
                    XmlSerializer b = new XmlSerializer(typeof(DiceWareOptions));
                    var a = (DiceWareOptions)b.Deserialize(XmlReader.Create(s));

                    WordCount = a.WordCount;

                }

            }
            catch (Exception e)
            {
                KeePassLib.Utility.MessageService.ShowFatal(e.ToString());
            }
        }

        public string Save()
        {
            try
            {
                using (var s = new MemoryStream())
                {
                    //BinaryFormatter b = new BinaryFormatter();
                    XmlSerializer b = new XmlSerializer(typeof(DiceWareOptions));

                    b.Serialize(XmlWriter.Create(s), this);

                    return Convert.ToBase64String(s.ToArray());
                }

            }
            catch (Exception e)
            {
                KeePassLib.Utility.MessageService.ShowFatal(e.ToString());
                return "";
            }
        }

        public void Default()
        {
            WordCount = 5;
        }

    }
}
