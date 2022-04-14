﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Initial_project.Engine.Shaders;
using Initial_project.Utilities;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Initial_project.Engine
{
    abstract class DrawableObject : Object, IDrawable
    {
        Vector3[] Vertices = Array.Empty<Vector3>();
        uint[] Indices;
        Color4 Color;

        int VertexBufferObject;
        int VertexArrayObject;
        int IndexBufferObject;
        ShaderEngine Shader;


        protected Matrix4 ModelMatrix;
        protected Matrix4 MVPMatrix;
        protected Matrix4 ViewProjectionMatrix;

        protected Matrix4 Rotations;
        protected Matrix4 Translations;
        protected Matrix4 Scales;


        public DrawableObject() : base()
        {
            ModelMatrix = Matrix4.Identity;
            ViewProjectionMatrix = Matrix4.Identity;
            MVPMatrix = ModelMatrix;
            Translations = Matrix4.Identity;
        }


        public DrawableObject(Vector3 relativePosition) : base(relativePosition)
        {
            ModelMatrix = Matrix4.Identity;
            MVPMatrix = ModelMatrix;
            ViewProjectionMatrix = Matrix4.Identity;
            Translations = Matrix4.Identity;
        }

        protected void Init(float[] vertexArray, uint[] indices, Color4 color)
        {
            Vector3[] vertices = Converter.ParseToVector3Array(vertexArray);
            SetVerticesInitialPosition(vertices);
            Indices = indices;
            Color = color;
            VertexArrayObject = GL.GenVertexArray(); //generamos el VAO
            VertexBufferObject = GL.GenBuffer(); //generamos el VBO
            IndexBufferObject = GL.GenBuffer(); //generamos el IBO

            GL.BindVertexArray(VertexArrayObject); //habilitamos el VAO 

            //enlazamos el VBO con un buffer de openGL y lo inicializamos
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, GetLength(Vertices) * sizeof(float), Vertices, BufferUsageHint.StaticDraw);

            //enlazamos el IBO con un buffer de openGL y lo inicializamos
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, Indices.Length * sizeof(uint), Indices, BufferUsageHint.StaticDraw);

            //configuramos los atributos del vertexbuffer y lo habilitamos (el primer 0 indica el location en el vertexShader)
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(float) * 3, 0);

            SetShaders();
        }



        //metodos principales

        public void SetShaders()
        {
            BuildShader();

            Shader.SetUniformColor4("u_Color", Color);
        }


        public void SetViewProjectionMatrix(Matrix4 viewProjectionMatrix)
        {
            ViewProjectionMatrix = viewProjectionMatrix;
        }

        protected void CalculateMvpMatrix()
        {
            MVPMatrix = ModelMatrix * ViewProjectionMatrix;
        }



        public void Draw()
        {
            CalculateMvpMatrix();
            //habilitamos todo
            Shader.Use();
            BindMatrix();
            GL.BindVertexArray(VertexArrayObject);

            //Dibujamos
            GL.DrawElements(PrimitiveType.Triangles, Indices.Length, DrawElementsType.UnsignedInt, 0);
        }


        public void Destroy()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0); //anulamos el ArrayBuffer
            GL.DeleteBuffer(VertexBufferObject); //y borramos el VBO
            Shader.Dispose(); //eliminamos el shader
        }




        private void BuildShader()
        {
            //creamos y usamos el program shader
            Shader = new ShaderEngine();
            Shader.Use();
        }

        private void SetVerticesInitialPosition(Vector3[] vertices)
        {
            List<Vector3> vertexlist = new();
            foreach (Vector3 vertex in vertices)
            {
                Vector3 newPosition = vertex + Origin;
                vertexlist.Add(newPosition);
            }
            this.Vertices = vertexlist.ToArray();
        }

        private void BindMatrix()
        {
            Shader.SetUniformMatrix4("mvp", MVPMatrix);
        }

        private static int GetLength(Vector3[] array)
        {
            return array.Length * 3;
        }


        //-----------------------------------------------------------------------
        //------------------TRANSFORMATIONS--------------------------------------
        //-----------------------------------------------------------------------

        public void Move(Vector3 direction)
        {
            Position = Position + direction;
            Translations = Matrix4.CreateTranslation(direction);
            ModelMatrix = ModelMatrix * Translations;
        }

        public void Scale(Vector3 factor)
        {
            Scales = Matrix4.CreateScale(factor);
            ModelMatrix = ModelMatrix * Scales;
        }

        public void RotateX(float angle)
        {
            Rotations = Matrix4.CreateRotationX(angle);
            ModelMatrix = ModelMatrix * Rotations;
        }

        public void RotateY(float angle)
        {
            Rotations = Matrix4.CreateRotationY(angle);
            ModelMatrix = ModelMatrix * Rotations;
        }

        public void RotateZ(float angle)
        {
            Rotations = Matrix4.CreateRotationZ(angle);
            ModelMatrix = ModelMatrix * Rotations;
        }
    }
}
