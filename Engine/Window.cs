using System;
using Initial_project.Core.Entities;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

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
            Vector3 initialPosition = new Vector3(-1.4f, 0.5f, -0.3f);
            Shape = new House();
        }


        //para la primera vez que corremos el programa
        protected override void OnLoad()
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            //Inicializar Matriz de Proyeccion
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / Size.Y , 0.1f, 100.0f);

            //posicion de la camara
            Vector3 cameraPosition = new (0.0f, 1.5f, 4.0f);
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
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);

            Shape.Draw();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }


        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            KeyboardState inputKey = KeyboardState.GetSnapshot();

            if (this.IsFocused)
            {

                if (inputKey.IsKeyDown(Keys.S))
                {
                    //hacia atrást
                    Shape.Move(new Vector3(0.0f, 0.0f, 0.05f));
                }

                if (inputKey.IsKeyDown(Keys.W))
                {
                    //hacia adelante
                    Shape.Move(new Vector3(0.0f, 0.0f, -0.05f));
                }

                if (inputKey.IsKeyDown(Keys.D))
                {
                    //hacia derecha
                    Shape.Move(new Vector3(0.05f, 0.0f, 0.0f));
                }

                if (inputKey.IsKeyDown(Keys.A))
                {
                    //hacia izquierda
                    Shape.Move(new Vector3(-0.05f, 0.0f, 0.0f));
                }

                if (inputKey.IsKeyDown(Keys.Space))
                {
                    //hacia arriba
                    Shape.Move(new Vector3(0.0f, 0.05f, 0.0f));
                }

                if (inputKey.IsKeyDown(Keys.LeftControl))
                {
                    //hacia abajo
                    Shape.Move(new Vector3(0.0f, -0.05f, 0.0f));
                }

                if (inputKey.IsKeyDown(Keys.Q))
                {
                    //mas grande
                    Shape.Scale(new Vector3(1.01f, 1.01f, 1.01f));
                }

                if (inputKey.IsKeyDown(Keys.E))
                {
                    //mas pequeño
                    Shape.Scale(new Vector3(0.99f, 0.99f, 0.99f));
                }

                if (inputKey.IsKeyDown(Keys.R))
                {
                    Shape.RotateY(0.02f);
                }

                if (inputKey.IsKeyDown(Keys.T))
                {
                    Shape.RotateX(0.02f);
                }

                if (inputKey.IsKeyDown(Keys.Y))
                {
                    Shape.RotateZ(0.02f);
                }

            }
            base.OnKeyDown(e);
        }


        protected override void OnUpdateFrame(FrameEventArgs args)
        {

            base.OnUpdateFrame(args);
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
