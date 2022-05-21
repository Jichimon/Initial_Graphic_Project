using Initial_project.Engine.Entities;
using OpenTK.Mathematics;
using System.Collections.Generic;

namespace Initial_project.Engine.Entities
{
    abstract class Scene : Entity, IDrawable
    {

        //properties
        private Dictionary<string, GraphicObject> Objects;


        //constructor
        public Scene() : base()
        {
            Objects = new();
        }

        public Scene(Point relativePosition) : base(relativePosition)
        {
            Objects = new();
        }




        public void AddObject(string name, GraphicObject obj)
        {
            Objects.Add(name, obj);
        }

        public GraphicObject GetGraphicObject(string name)
        {
            if (!Objects.ContainsKey(name))
            {
                return null;
            }
            return Objects[name];
        }


        public void Draw()
        {
            foreach (IDrawable item in Objects.Values)
            {
                item.Draw();
            }
        }

        public void SetViewProjectionMatrix(Matrix4 ViewProjectionMatrix)
        {
            foreach (GraphicObject item in Objects.Values)
            {
                item.SetViewProjectionMatrix(ViewProjectionMatrix);
            }
        }

        public void Destroy()
        {
            foreach (IDrawable item in Objects.Values)
            {
                item.Destroy();
            }
        }



        public List<string> GetListOfObjectNames()
        {
            List<string> list = new();
            foreach (string item in Objects.Keys)
            {
                list.Add(item);
            }
            return list;
        }


        //-----------------------------------------------------------------------
        //------------------TRANSFORMATIONS--------------------------------------
        //-----------------------------------------------------------------------



        public void Move(Vector3 direction)
        {
            foreach (IDrawable item in Objects.Values)
            {
                item.Move(direction);
            }
        }


        public void MoveObject(string objectName, Vector3 direction)
        {
            GraphicObject graphicObject = GetGraphicObject(objectName);
            if (graphicObject == null)
            {
                System.Console.WriteLine("SCENE: [MOVE_OBJECT] No se encontró el objeto especificado, asegurarse que el nombre es el correcto.");
                return;
            }

            graphicObject.Move(direction);
        }



        public void Scale(Vector3 factor)
        {
            foreach (IDrawable item in Objects.Values)
            {
                item.Scale(factor);
            }
        }


        public void ScaleObject(string objectName, Vector3 factor)
        {
            GraphicObject graphicObject = GetGraphicObject(objectName);
            if (graphicObject == null)
            {
                System.Console.WriteLine("SCENE: [SCALE_OBJECT] No se encontró el objeto especificado, asegurarse que el nombre es el correcto.");
                return;
            }

            graphicObject.Scale(factor);
        }



        public void RotateX(float angle)
        {
            foreach (IDrawable item in Objects.Values)
            {
                item.RotateX(angle);
            }
        }

        public void RotateY(float angle)
        {
            foreach (IDrawable item in Objects.Values)
            {
                item.RotateY(angle);
            }
        }

        public void RotateZ(float angle)
        {
            foreach (IDrawable item in Objects.Values)
            {
                item.RotateZ(angle);
            }
        }

        
        public void RotateObjectOnItselfOverX(string objectName, float angle)
        {
            GraphicObject graphicObject = GetGraphicObject(objectName);
            if (graphicObject == null)
            {
                System.Console.WriteLine("SCENE: [ROTATE_X] No se encontró el objeto especificado, asegurarse que el nombre es el correcto.");
                return;
            }

            graphicObject.RotateXOnItself(angle);
        }

        public void RotateObjectOnItselfOverY(string objectName, float angle)
        {
            GraphicObject graphicObject = GetGraphicObject(objectName);
            if (graphicObject == null)
            {
                System.Console.WriteLine("SCENE: [ROTATE_Y] No se encontró el objeto especificado, asegurarse que el nombre es el correcto.");
                return;
            }

            graphicObject.RotateYOnItself(angle);
        }

        public void RotateObjectOnItselfOverZ(string objectName, float angle)
        {
            GraphicObject graphicObject = GetGraphicObject(objectName);
            if (graphicObject == null)
            {
                System.Console.WriteLine("SCENE: [ROTATE_Z] No se encontró el objeto especificado, asegurarse que el nombre es el correcto.");
                return;
            }

            graphicObject.RotateZOnItself(angle);
        }

    }
}
