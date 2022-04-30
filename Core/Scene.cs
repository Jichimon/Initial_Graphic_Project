using Initial_project.Engine;
using OpenTK.Mathematics;
using System.Collections.Generic;

namespace Initial_project.Core
{
    class Scene : Entity, IDrawable
    {

        //properties
        private Dictionary<string, Object> Objects;


        //constructor
        public Scene() : base()
        {
            Objects = new();
        }

        public Scene(Vector3 relativePosition) : base(relativePosition)
        {
            Objects = new();
        }




        public void AddObject(string name, Object obj)
        {
            Objects.Add(name, obj);
        }

        public Object Getpart(string name)
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
            foreach (Object item in Objects.Values)
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
    }
}
