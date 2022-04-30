using Initial_project.Engine;
using OpenTK.Mathematics;


namespace Initial_project.Core.Entities
{
    class Door : Part
    {

        //atributos
        private float[] VertexFloatArray = new float[]
        {
            //posiciones
            0.0f,  -0.2f,   0f,  // 0
            0.2f,  -0.2f,   0f,  // 1 
            0.2f,   0.2f,   0f,  // 2
            0.0f,   0.2f,   0f,  // 3

        };

        private uint[] IndexFloatArray = new uint[]
        {
            //líneas
            0, 1, 2,
            2, 3, 0
        };


        private Color4 ColorShape = new(119, 7, 9, 255);



        //constructor
        public Door() : base()
        {
            base.Init(VertexFloatArray, IndexFloatArray, ColorShape);
        }

        public Door(Vector3 relativePosition) : base(relativePosition)
        {
            base.Init(VertexFloatArray, IndexFloatArray, ColorShape);
        }

        public Door(Vector3 relativePosition, Color4 color) : base(relativePosition)
        { 
            ColorShape = color;
            base.Init(VertexFloatArray, IndexFloatArray, ColorShape);
        }

    }
}
