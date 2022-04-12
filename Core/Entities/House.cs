using Initial_project.Engine;
using OpenTK.Mathematics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_project.Core.Entities
{
    class House : Object, IDrawable
    {

        //atributos
        List<IDrawable> Drawables = new List<IDrawable>();
        Door Door;
        Roof Roof;
        Wall Wall;

        Vector3 DoorInitialPosition = new Vector3(-0.1f, -0.4f,  0.51f);
        Vector3 RoofInitialPosition = new Vector3( 0.0f,  0.45f,  0.0f);
        Vector3 WallInitialPosition = new Vector3( 0.0f, -0.2f,  0.0f);



        //constructor
        public House() : base()
        {
         
            Wall = new Wall(WallInitialPosition);
            Drawables.Add(Wall);

            Roof = new Roof(RoofInitialPosition);
            Drawables.Add(Roof);

            Door = new Door(DoorInitialPosition);
            Drawables.Add(Door);
        }

        public House(Vector3 relativePosition) : base(relativePosition)
        {
        }

        public void Draw()
        {
            foreach (IDrawable item in Drawables)
            {
                item.Draw();
            }
        }

        public void SetViewProjectionMatrix(Matrix4 ViewProjectionMatrix)
        {
            foreach (IDrawable item in Drawables)
            {
                item.SetViewProjectionMatrix(ViewProjectionMatrix);
            }
        }

        public void Destroy()
        {
            foreach (IDrawable item in Drawables)
            {
                item.Destroy();
            }
        }
    }
}
