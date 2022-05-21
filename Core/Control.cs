using Initial_project.Engine.Entities;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_project.Core
{
    struct ObjectSelector
    {
        public int KeyNumber;
        public string ObjectName;
    }

    class Control
    {
        readonly MainScene Scene;
        List<ObjectSelector> GraphicObjects;
        int ObjectSelected = 0;


        private const float ROTATION_FACTOR = 0.2f;
        private const float TRANSLATION_FACTOR = 0.05f;
        private readonly Vector3 SCALE_POSITIVE_GROWTH_FACTOR = new(1.01f, 1.01f, 1.01f);
        private readonly Vector3 SCALE_NEGATIVE_GROWTH_FACTOR = new(0.99f, 0.99f, 0.99f);

        public Control(MainScene scene)
        {
            Scene = scene;
            LoadObjectSelectorList(Scene.GetListOfObjectNames());
        }


        private void LoadObjectSelectorList(List<string> stringList)
        {
            GraphicObjects = new();
            foreach (string item in stringList)
            {
                ObjectSelector o;
                o.KeyNumber = stringList.IndexOf(item) + 1;
                o.ObjectName = item;

                GraphicObjects.Add(o);
            }
        }


        public void DisplayObjectsList()
        {
            System.Console.WriteLine("_______________________________________");
            System.Console.WriteLine("Lista Disponible de Objetos: ");
            foreach (ObjectSelector item in GraphicObjects)
            {
                System.Console.WriteLine("  -  Tecla-Nro: " + item.KeyNumber + " |  Nombre: " + item.ObjectName );
            }
            System.Console.WriteLine("_______________________________________");
        }


        protected void SelectAnObject(KeyboardState inputKey)
        {
            if (inputKey.IsKeyDown(Keys.D1))
            {
                ObjectSelected = 1;
                Console.WriteLine("CONTROL: El Objeto Seleccionado es " + ObjectSelected);
            }
            if (inputKey.IsKeyDown(Keys.D2))
            {
                ObjectSelected = 2;
                Console.WriteLine("CONTROL: El Objeto Seleccionado es " + ObjectSelected);
            }
            if (inputKey.IsKeyDown(Keys.D3))
            {
                ObjectSelected = 3;
                Console.WriteLine("CONTROL: El Objeto Seleccionado es " + ObjectSelected);
            }
            if (inputKey.IsKeyDown(Keys.D4))
            {
                ObjectSelected = 4;
                Console.WriteLine("CONTROL: El Objeto Seleccionado es " + ObjectSelected);
            }
            if (inputKey.IsKeyDown(Keys.D5))
            {
                ObjectSelected = 5;
            }
            if (inputKey.IsKeyDown(Keys.D6))
            {
                ObjectSelected = 6;
            }
            if (inputKey.IsKeyDown(Keys.D7))
            {
                ObjectSelected = 7;
            }
            if (inputKey.IsKeyDown(Keys.D8))
            {
                ObjectSelected = 8;
            }
            if (inputKey.IsKeyDown(Keys.D9))
            {
                ObjectSelected = 9;
            }

        }


        protected void OneObjectActions(KeyboardState inputKey)
        {
            if (ObjectSelected == 0 || ObjectSelected > GraphicObjects.Count)
            {
                Console.WriteLine("CONTROL: No hay ningun objeto seleccionado. Por favor, seleccione un objeto.");
                return;
            }

            ObjectSelector graphicObject = GraphicObjects[ObjectSelected - 1];

            if (inputKey.IsKeyDown(Keys.S))
            {
                //hacia atrás
                Scene.MoveObject(graphicObject.ObjectName, new Vector3(0.0f, 0.0f, TRANSLATION_FACTOR));
            }

            if (inputKey.IsKeyDown(Keys.W))
            {
                //hacia adelante
                Scene.MoveObject(graphicObject.ObjectName, new Vector3(0.0f, 0.0f, -TRANSLATION_FACTOR));
            }

            if (inputKey.IsKeyDown(Keys.D))
            {
                //hacia derecha
                Scene.MoveObject(graphicObject.ObjectName, new Vector3(TRANSLATION_FACTOR, 0.0f, 0.0f));
            }

            if (inputKey.IsKeyDown(Keys.A))
            {
                //hacia izquierda
                Scene.MoveObject(graphicObject.ObjectName, new Vector3(-TRANSLATION_FACTOR, 0.0f, 0.0f));
            }

            if (inputKey.IsKeyDown(Keys.Space))
            {
                //hacia arriba
                Scene.MoveObject(graphicObject.ObjectName, new Vector3(0.0f, TRANSLATION_FACTOR, 0.0f));
            }

            if (inputKey.IsKeyDown(Keys.LeftControl))
            {
                //hacia abajo
                Scene.MoveObject(graphicObject.ObjectName, new Vector3(0.0f, -TRANSLATION_FACTOR, 0.0f));
            }

            if (inputKey.IsKeyDown(Keys.Q))
            {
                //mas grande
                Scene.ScaleObject(graphicObject.ObjectName, SCALE_POSITIVE_GROWTH_FACTOR);
            }

            if (inputKey.IsKeyDown(Keys.E))
            {
                //mas pequeño
                Scene.ScaleObject(graphicObject.ObjectName, SCALE_NEGATIVE_GROWTH_FACTOR);
            }

            if (inputKey.IsKeyDown(Keys.R))
            {
                Scene.RotateObjectOnItselfOverY(graphicObject.ObjectName, ROTATION_FACTOR);
            }

            if (inputKey.IsKeyDown(Keys.T))
            {
                Scene.RotateObjectOnItselfOverX(graphicObject.ObjectName, ROTATION_FACTOR);
            }

            if (inputKey.IsKeyDown(Keys.Y))
            {
                Scene.RotateObjectOnItselfOverZ(graphicObject.ObjectName, ROTATION_FACTOR);
            }

        }

        public void OnInputKey(KeyboardState inputKey)
        {
            SelectAnObject(inputKey);
            OneObjectActions(inputKey);
            

            //ROTATE ALL
            if (inputKey.IsKeyDown(Keys.F))
            {
                Scene.RotateY(ROTATION_FACTOR);
            }

            if (inputKey.IsKeyDown(Keys.G))
            {
                Scene.RotateX(ROTATION_FACTOR);
            }

            if (inputKey.IsKeyDown(Keys.H))
            {
                Scene.RotateZ(ROTATION_FACTOR);
            }

            if (inputKey.IsKeyDown(Keys.KeyPadAdd))
            {
                string name = "house" + Scene.ObjectCounter;
                Scene.CreateHouse(name);
                LoadObjectSelectorList(Scene.GetListOfObjectNames());
                DisplayObjectsList();
            }
            
        }
    }
}
