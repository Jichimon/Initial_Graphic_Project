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
        private List<Part> ListOfParts;


        public Object() : base()
        {
            ListOfParts = new();
        }

        public Object(Vector3 relativePosition) : base(relativePosition)
        {
            ListOfParts = new();
        }




        protected void AddPart(Part part)
        {
            ListOfParts.Add(part);
        }

        protected Part Getpart(int id)
        {
            return ListOfParts.Find((p) => p.Id == id);
        }


        public void Draw()
        {
            foreach (IDrawable item in ListOfParts)
            {
                item.Draw();
            }
        }

        public void SetViewProjectionMatrix(Matrix4 ViewProjectionMatrix)
        {
            foreach (Part item in ListOfParts)
            {
                item.SetViewProjectionMatrix(ViewProjectionMatrix);
            }
        }

        public void Destroy()
        {
            foreach (IDrawable item in ListOfParts)
            {
                item.Destroy();
            }
        }

    }
}
