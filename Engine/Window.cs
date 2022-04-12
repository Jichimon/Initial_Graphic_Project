using System;
using Initial_project.Core.Entities;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Initial_project.Engine
{
    class Window : GameWindow
    {

        //atributos
        House Shape;


        //constructor
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
           : base(gameWindowSettings, nativeWindowSettings)
        {
            Init();
        }

        private void Init()
        {
            Shape = new House();
        }


        //para la primera vez que corremos el programa
        protected override void OnLoad()
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            //Inicializar Matriz de Proyeccion
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / Size.Y , 0.1f, 100.0f);

            //posicion de la camara
            Vector3 cameraPosition = new (3.0f, 1.0f, 3.0f);
            Vector3 target = new (0.0f, 0.0f, 0.0f);
            Vector3 up = new (0.0f, 1.0f, 0.0f);

            Matrix4 view = Matrix4.LookAt(cameraPosition, target, up);

            Shape.SetViewProjectionMatrix(view * projection);

            //---- Para Prueba de Posicion del Objeto en X,Y ----
            //Shape.SetViewProjectionMatrix(Matrix4.Identity);
            //---------------------------------------------------


            base.OnLoad();
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Shape.Draw();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }


        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }


        //para cerrar el programa
        protected override void OnUnload()
        {
            Shape.Destroy();

            base.OnUnload();
        }
    }
}
