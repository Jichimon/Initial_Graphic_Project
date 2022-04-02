using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_project.Engine.Entities
{
    class Triangle
    {

        //atributos
        float[] vertices = new float[]
        {
            //posiciones
            -0.5f,  -0.5f, 0.0f,  // 0
             0.5f,  -0.5f, 0.0f,  // 1
             0.0f,   0.5f, 0.0f,  // 2

        };

        uint[] indices = new uint[]
        {
            //líneas
            0, 1, 2    
        };



        //constructor
        public Triangle()
        {
        }

        //getters
        public float[] getVertices()
        {
            return vertices;
        }

        public int verticesCount()
        {
            return vertices.Length;
        }

        public uint[] getIndices()
        {
            return indices;
        }

        public int indexCount()
        {
            return indices.Length;
        }

    }
}
