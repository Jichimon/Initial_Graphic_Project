using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;
using OpenTK.Core;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Initial_project.Engine.Entities
{
    class GraphicObject : Entity, IDrawable
    {


        //properties
        public Dictionary<string, Part> Parts;

        public GraphicObject() : base()
        {
            Parts = new();
        }

        [JsonConstructor]
        public GraphicObject(Point relativePosition, Dictionary<string, Part> parts) : base(relativePosition)
        {
            Parts = parts;
        }
        
        public GraphicObject(Point relativePosition) : base(relativePosition)
        {
            Parts = new();
        }




        protected void AddPart(string name, Part part)
        {
            Parts.Add(name, part);
        }

        protected Part GetPart(string name)
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

        //-----------------------------------------------------------------------
        //------------------TRANSFORMATIONS--------------------------------------
        //-----------------------------------------------------------------------



        public void Move(Vector3 direction)
        {
            foreach (Part item in Parts.Values)
            {
                item.MoveWithObject(direction);
            }
        }

        public void Scale(Vector3 factor)
        {
            foreach (IDrawable item in Parts.Values)
            {
                item.Scale(factor);
            }
        }

        public void RotateX(float angle)
        {
            foreach (Part item in Parts.Values)
            {
                item.RotateXWithObject(angle);
            }
        }

        public void RotateY(float angle)
        {
            foreach (Part item in Parts.Values)
            {
                item.RotateYWithObject(angle);
            }
        }

        public void RotateZ(float angle)
        {
            foreach (Part item in Parts.Values)
            {
                item.RotateZWithObject(angle);
            }
        }

        public void RotateXOnItself(float angle)
        {
            foreach (Part item in Parts.Values)
            {
                item.RotateXWithObjectOnItself(angle);
            }
        }

        public void RotateYOnItself(float angle)
        {
            foreach (Part item in Parts.Values)
            {
                item.RotateYWithObjectOnItself(angle);
            }
        }

        public void RotateZOnItself(float angle)
        {
            foreach (Part item in Parts.Values)
            {
                item.RotateZWithObjectOnItself(angle);
            }
        }

    }
}
