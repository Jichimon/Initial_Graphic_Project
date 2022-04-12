using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;
using OpenTK.Core;

namespace Initial_project.Engine
{
    abstract class Object
    {
        protected Vector3 Position; //guarda la posicion del centro de gravedad actual del objeto
        protected Vector3 Origin;   //guarda la posicion del centro de gravedad inicial del objeto

        protected Matrix4 ModelMatrix;
        protected Matrix4 MVPMatrix;


        /// <summary>
        /// Constructor básico que crea un objeto en el centro de la ventana
        /// </summary>
        public Object() 
        {
            Origin = Vector3.Zero;
            Position = Vector3.Zero;
            ModelMatrix = Matrix4.Identity;
            MVPMatrix = ModelMatrix;
        }

        /// <summary>
        /// Crea un objeto cuyo origen, está en base al origen de otro objeto.
        /// </summary>
        /// <param name="relativePosition"> origen del otro objeto </param>
        public Object(Vector3 relativePosition)
        {
            SetInitialPosition(relativePosition);
        }


        protected void SetInitialPosition(Vector3 initialPosition)
        {
            Origin = initialPosition;
            Position = Origin;
            ModelMatrix = Matrix4.Identity;
            MVPMatrix = ModelMatrix;
        }

    }
}
