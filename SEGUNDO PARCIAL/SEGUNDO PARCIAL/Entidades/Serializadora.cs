using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Entidades
{
    public class Serializadora : IGuardar<List<Serie>>
    {
        public void Guardar(List<Serie> items, string ruta)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Serie>));
            using (TextWriter writer = new StreamWriter(ruta))
            {
                serializer.Serialize(writer, items);
            }
        }

        void IGuardar<List<Serie>>.Guardar(List<Serie> items, string ruta)
        {
            string json = JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented); 
            File.WriteAllText(ruta, json);
        }
    }
}
