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
        Door Door;
        Roof Roof;
        Wall Wall;

        string KeyWall = "wall";
        string KeyRoof = "roof";
        string KeyDoor = "door";

        Vector3 DoorInitialPosition = new Vector3(-0.1f, -0.4f,  0.51f);
        Vector3 RoofInitialPosition = new Vector3( 0.0f,  0.45f,  0.0f);
        Vector3 WallInitialPosition = new Vector3( 0.0f, -0.2f,  0.0f);



        //constructor
        public House() : base()
        {
            Init();
        }

        public House(Vector3 relativePosition) : base(relativePosition)
        {
            Init();
        }


        private void Init()
        {
            Wall = new Wall(WallInitialPosition + Origin);
            AddPart(KeyWall, Wall);

            Roof = new Roof(RoofInitialPosition + Origin);
            AddPart(KeyRoof, Roof);

            Door = new Door(DoorInitialPosition + Origin);
            AddPart(KeyDoor, Door);
        }


    }
}
