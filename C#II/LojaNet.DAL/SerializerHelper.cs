using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace LojaNet.DAL
{
    public static class SerializerHelper
    {
        public static void Serializar(string arquivo, object dados)
        {
            using (var stream = new StreamWriter(arquivo))
            {
                var serializador = new XmlSerializer(dados.GetType());
                serializador.Serialize(stream, dados);
            }
        }
        public static object Deserializar(string arquivo, Type type)
        {
            object retorno = null;
            using (var stream = new StreamReader(arquivo))
            {
                var serializador = new XmlSerializer(type);
                retorno = serializador.Deserialize(stream);
            }
            return retorno;
        }
    }
}
