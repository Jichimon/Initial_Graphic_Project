using System;
using Initial_project.Engine.Entities;
using Initial_project.Engine.Shaders;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Initial_project.Engine
{
    class Window : GameWindow
    {

        //atributos
        int VertexBufferObject;
        int VertexArrayObject;
        int IndexBufferObject;
        Triangle triangle = new Triangle();
        ShaderEngine shader;


        //constructor
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
           : base(gameWindowSettings, nativeWindowSettings)
        {
            init();
        }

        private void init()
        {
            VertexArrayObject = GL.GenVertexArray(); //generamos el VAO
            VertexBufferObject = GL.GenBuffer(); //generamos el VBO
            IndexBufferObject = GL.GenBuffer(); //generamos el IBO

            GL.BindVertexArray(VertexArrayObject); //habilitamos el VAO 

            //enlazamos el VBO con un buffer de openGL y lo inicializamos
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, triangle.verticesCount() * sizeof(float), triangle.getVertices(), BufferUsageHint.StaticDraw);

            //enlazamos el IBO con un buffer de openGL y lo inicializamos
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, triangle.indexCount() * sizeof(uint), triangle.getIndices(), BufferUsageHint.StaticDraw);

            //creamos y usamos el program shader
            string vertexPath = "Resources/Shaders/VertexShader.glsl";
            string fragmentPath = "Resources/Shaders/FragmentShader.glsl";

            shader = new ShaderEngine(vertexPath, fragmentPath);
        }


        //para la primera vez que corremos el programa
        protected override void OnLoad()
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);


            //configuramos los atributos del vertexbuffer y lo habilitamos
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(float) * 3, 0);
            GL.EnableVertexAttribArray(0);

            shader.use();

            base.OnLoad();
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            shader.use();
            GL.BindVertexArray(VertexArrayObject);
            //Dibuja mi casa
            GL.DrawElements(PrimitiveType.Lines, triangle.indexCount(), DrawElementsType.UnsignedInt, 0);

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
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0); //anulamos el ArrayBuffer
            GL.DeleteBuffer(VertexBufferObject); //y borramos el VBO
            shader.Dispose(); //eliminamos el shader
            base.OnUnload();
        }
    }
}
