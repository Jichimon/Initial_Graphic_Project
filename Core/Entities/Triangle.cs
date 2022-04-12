using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_project.Engine.Entities
{
    class Triangle : DrawableObject
    {

        //atributos
        private float[] VertexFloatArray = new float[]
        {
            //posiciones
            -0.5f,  -0.5f,   0.0f,  // 0
             0.5f,  -0.5f,   0.0f,  // 1
             0.0f,   0.5f,   0.0f,  // 2

        };

        private uint[] IndexFloatArray = new uint[]
        {
            //líneas
            0, 1, 2    
        };


        private Color4 ColorShape = new(207, 72, 43, 255); 



        //constructor
        public Triangle() : base()
        {
            base.Init(VertexFloatArray, IndexFloatArray, ColorShape);
        }

        public Triangle(Vector3 relativePosition) : base(relativePosition)
        {
            base.Init(VertexFloatArray, IndexFloatArray, ColorShape);
        }

        public Triangle(Vector3 relativePosition, Color4 color) : base(relativePosition)
        {
            ColorShape = color;
            base.Init(VertexFloatArray, IndexFloatArray, ColorShape);
        }

    }
}
