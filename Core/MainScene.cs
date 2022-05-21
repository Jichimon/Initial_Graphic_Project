using Initial_project.Engine;
using Initial_project.Engine.Entities;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_project.Core
{
    class MainScene : Scene
    {

        //atributos
        public int ObjectCounter = 0;

        //constructor
        public MainScene() : base()
        {
            Init();
        }

        public MainScene(Point relativePosition) : base(relativePosition)
        {
            Init();
        }


        private void Init()
        {
            int res = CreateHouse("house0");
            if (res == 1)
            {
                Console.WriteLine("MAIN_SCENE: Primera casa creada correctamente");
            }
            else
            {
                Console.WriteLine("MAIN_SCENE: Error al crear la primera casa");
            }
        }


        public int CreateHouse(string houseName)
        {
            if (ObjectCounter > 3)
            {
                return -1;
            }
            string jsonFile = "../../../Resources/House.json";
            GraphicObject house = ObjectBuilder.BuildFromJson(jsonFile);
            AddObject(houseName, house);
            ObjectCounter++;
            return 1;
        }
    }
}
