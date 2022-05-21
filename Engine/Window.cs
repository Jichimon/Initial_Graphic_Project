using System;
using Initial_project.Core;
using Initial_project.Engine.Entities;
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
        MainScene Scene1;
        Control Control;


        //constructor
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
           : base(gameWindowSettings, nativeWindowSettings)
        {
            Init();
        }

        private void Init()
        {
            Scene1 = new MainScene();
            Control = new Control(Scene1);
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

            Scene1.SetViewProjectionMatrix(view * projection);
            Control.DisplayObjectsList();

            base.OnLoad();
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);

            Scene1.Draw();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }


        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            KeyboardState inputKey = KeyboardState.GetSnapshot();

            if (IsFocused)
            {

                Control.OnInputKey(inputKey);

            }
            base.OnKeyDown(e);
        }



        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }


        //para cerrar el programa
        protected override void OnUnload()
        {
            Scene1.Destroy();


            base.OnUnload();
        }
    }
}
