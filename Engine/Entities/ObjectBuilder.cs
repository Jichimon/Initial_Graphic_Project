using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Initial_project.Engine.Entities;
using System;
using System.Threading.Tasks;
using System.Reflection;

namespace Initial_project.Engine
{
    class ObjectBuilder
    {
        public static GraphicObject BuildFromJson(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            GraphicObject objeto = JsonConvert.DeserializeObject<GraphicObject>(jsonString);
            Console.WriteLine(objeto);
            return objeto;
        }


        private static string GetJsonFileFromResources(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Initial_project.Properties.Resources." + fileName;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string jsonFile = reader.ReadToEnd(); //Make string equal to full file
                return jsonFile;
            }
        }
    }
}
