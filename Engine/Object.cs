using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;
using OpenTK.Core;
using System.Collections.Generic;

namespace Initial_project.Engine
{
    abstract class Object : Entity, IDrawable
    {


        //properties
        protected Dictionary<string, Part> Parts;


        public Object() : base()
        {
            Parts = new();
        }

        public Object(Vector3 relativePosition) : base(relativePosition)
        {
            Parts = new();
        }




        protected void AddPart(string name, Part part)
        {
            Parts.Add(name, part);
        }

        protected Part Getpart(string name)
        {
            if (!Parts.ContainsKey(name))
            {
                return null;
            }
            return Parts[name];
        }


        public void Draw()
        {
            foreach (IDrawable item in Parts.Values)
            {
                item.Draw();
            }
        }

        public void SetViewProjectionMatrix(Matrix4 ViewProjectionMatrix)
        {
            foreach (Part item in Parts.Values)
            {
                item.SetViewProjectionMatrix(ViewProjectionMatrix);
            }
        }

        public void Destroy()
        {
            foreach (IDrawable item in Parts.Values)
            {
                item.Destroy();
            }
        }

    }
}
