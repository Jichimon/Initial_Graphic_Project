using OpenTK.Mathematics;


namespace Initial_project.Engine
{
    abstract class Entity
    {

        protected Vector3 Position; //guarda la posicion del centro de gravedad actual del objeto
        protected Vector3 Origin;   //guarda la posicion del centro de gravedad inicial del objeto


        /// <summary>
        /// Constructor básico que crea un objeto en el centro de la ventana
        /// </summary>
        public Entity()
        {
            SetInitialPosition(Vector3.Zero);
        }

        /// <summary>
        /// Crea un objeto cuyo origen, está en base al origen de otro objeto.
        /// </summary>
        /// <param name="relativePosition"> origen del otro objeto </param>
        public Entity(Vector3 relativePosition)
        {
            SetInitialPosition(relativePosition);
        }


        private void SetInitialPosition(Vector3 initialPosition)
        {
            Origin = initialPosition;
            Position = Origin;
        }


    }
}
