using Initial_project.Engine;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_project.Core.Entities
{
    class Wall : Part
    {

        //atributos
        private float[] VertexFloatArray = new float[]
        {
             //posiciones
           -0.4f, -0.4f,  0.5f, // 0
            0.4f, -0.4f,  0.5f, // 1 
            0.4f,  0.4f,  0.5f, // 2
           -0.4f,  0.4f,  0.5f, // 3

           -0.4f, -0.4f,  -0.5f, // 4 
            0.4f, -0.4f,  -0.5f, // 5
            0.4f,  0.4f,  -0.5f, // 6 
           -0.4f,  0.4f,  -0.5f  // 7

        };

        private uint[] IndexFloatArray = new uint[]
        {
            //cara delantera
            0, 1, 2,
            2, 3, 0,
            //cara de abajo
            0, 4, 1,
            1, 5, 4,
            //cara izquierda
            4, 7, 0,
            0, 3, 7,
            //cara de arriba
            7, 3, 2,
            2, 6, 7,
            //cara de atras
            7, 6, 4,
            4, 5, 6,
            //cara derecha
            6, 2, 1,
            1, 5, 6
        };


        private Color4 ColorShape = new(22, 112, 139, 255);



        //constructor
        public Wall() : base()
        {
            Init(VertexFloatArray, IndexFloatArray, ColorShape);
        }

        public Wall(Vector3 relativePosition) : base(relativePosition)
        {
            Init(VertexFloatArray, IndexFloatArray, ColorShape);
        }

        public Wall(Vector3 relativePosition, Color4 color) : base(relativePosition)
        {
            ColorShape = color;
            Init(VertexFloatArray, IndexFloatArray, ColorShape);
        }

    }
}
