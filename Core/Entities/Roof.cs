using Initial_project.Engine;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_project.Core.Entities
{
    class Roof : Part
    {

        //atributos
        private float[] VertexFloatArray = new float[]
        {
            //posiciones
           -0.5f,  -0.25f,  0.5f, // 0
            0.5f,  -0.25f,  0.5f, // 1 
            0.0f,   0.25f,  0.5f, // 2

           -0.5f,  -0.25f,  -0.5f, // 3
            0.5f,  -0.25f,  -0.5f, // 4 
            0.0f,   0.25f,  -0.5f  // 5

        };

        private uint[] IndexFloatArray = new uint[]
        {
            //cara delantera
            0, 1, 2,
            //cara derecha
            1, 4, 5,
            5, 2, 1,
            //cara de abajo
            1, 4, 3,
            3, 1, 0,
            //cara izquierda
            0, 3, 2,
            2, 3, 5,
            //cara de atras
            5, 3, 4
        };


        private Color4 ColorShape = new(207, 72, 43, 255);



        //constructor
        public Roof() : base()
        {
            Init(VertexFloatArray, IndexFloatArray, ColorShape);
        }

        public Roof(Vector3 relativePosition) : base(relativePosition)
        {
            Init(VertexFloatArray, IndexFloatArray, ColorShape);
        }

        public Roof(Vector3 relativePosition, Color4 color) : base(relativePosition)
        {
            ColorShape = color;
            Init(VertexFloatArray, IndexFloatArray, ColorShape);
        }

    }
}
