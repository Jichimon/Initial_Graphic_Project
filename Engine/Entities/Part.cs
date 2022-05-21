using Initial_project.Engine.Shaders;
using Initial_project.Utilities;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Initial_project.Engine.Entities
{
    class Part : Entity, IDrawable
    {

        Vector3[] Vertices = Array.Empty<Vector3>();
        uint[] Indices;
        Color4 Color;

        int VertexBufferObject;
        int VertexArrayObject;
        int IndexBufferObject;
        ShaderEngine Shader;

        protected Vector3 LastPosition;

        protected Matrix4 ModelMatrix;
        protected Matrix4 MVPMatrix;
        protected Matrix4 ViewProjectionMatrix;

        protected Matrix4 Rotations;
        protected Matrix4 Translations;
        protected Matrix4 Scales;



        public Part() : base()
        {
            ModelMatrix = Matrix4.Identity;
            ViewProjectionMatrix = Matrix4.Identity;
            MVPMatrix = ModelMatrix;
        }


        public Part(Point relativePosition) : base(relativePosition)
        {
            ModelMatrix = Matrix4.Identity;
            MVPMatrix = ModelMatrix;
            ViewProjectionMatrix = Matrix4.Identity;
        }


        [JsonConstructor]
        public Part(float[] vertexArray, uint[] indices, Color4 color, Point relativePosition) : base(relativePosition)
        {
            ModelMatrix = Matrix4.Identity;
            MVPMatrix = ModelMatrix;
            ViewProjectionMatrix = Matrix4.Identity;
            Init(vertexArray, indices, color);
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
            CalculateMvpMatrix();
        }

        protected void CalculateMvpMatrix()
        {
            MVPMatrix = ModelMatrix * ViewProjectionMatrix;
        }



        public void Draw()
        {
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


        private void MultiplyByModelMatrix(Matrix4 matrix4)
        {
            ModelMatrix *= matrix4;
        }

        private void BackToOrigin()
        {
            LastPosition = Position;
            CalculateMove(-Position +Origin);
        }

        private void BackToZero()
        {
            LastPosition = Position;
            CalculateMove(-Position);
        }


        private void RecoveryLastPosition()
        {
            CalculateMove(-Origin +LastPosition);
        }

        //-----------------------------------------------------------------------
        //------------------TRANSFORMATIONS--------------------------------------
        //-----------------------------------------------------------------------


        public void Move(Vector3 direction)
        {
            BackToOrigin();
            CalculateMove(direction);
            RecoveryLastPosition();
            CalculateMvpMatrix();
        }


        public void MoveWithObject(Vector3 direction)
        {
            CalculateMove(direction);
            CalculateMvpMatrix();
        }


        public void Scale(Vector3 factor)
        {
            CalculateScale(factor);
            CalculateMvpMatrix();
        }


        //-----------ROTATIONS--------------------------------------
        //----------WITH OBJECT-------------------------------------

        public void RotateXWithObjectOnItself(float angle)
        {
            BackToOrigin();
            CalculateRotateX(angle);
            RecoveryLastPosition();
            CalculateMvpMatrix();
        }

        public void RotateYWithObjectOnItself(float angle)
        {
            BackToOrigin();
            CalculateRotateY(angle);
            RecoveryLastPosition();
            CalculateMvpMatrix();
        }

        public void RotateZWithObjectOnItself(float angle)
        {
            BackToOrigin();
            CalculateRotateZ(angle);
            RecoveryLastPosition();
            CalculateMvpMatrix();
        }


        public void RotateXWithObject(float angle)
        {
            CalculateRotateX(angle);
            CalculateMvpMatrix();
        }

        public void RotateYWithObject(float angle)
        {
            CalculateRotateY(angle);
            CalculateMvpMatrix();
        }

        public void RotateZWithObject(float angle)
        {
            CalculateRotateZ(angle);
            CalculateMvpMatrix();
        }

        //----------------------------------------------------------

        public void RotateX(float angle)
        {
            BackToZero();
            CalculateRotateX(angle);
            CalculateMove(LastPosition);
            CalculateMvpMatrix();
        }

        public void RotateY(float angle)
        {
            BackToZero();
            CalculateRotateY(angle);
            CalculateMove(LastPosition);
            CalculateMvpMatrix();
        }

        public void RotateZ(float angle)
        {
            BackToZero();
            CalculateRotateZ(angle);
            CalculateMove(LastPosition);
            CalculateMvpMatrix();
        }

        //----------------------------------------------------------
        //----------------------------------------------------------


        private void CalculateMove(Vector3 direction)
        {
            Position += direction;
            Translations = Matrix4.CreateTranslation(direction);
            MultiplyByModelMatrix(Translations);
        }

        private void CalculateScale(Vector3 factor)
        {
            Scales = Matrix4.CreateScale(factor);
            MultiplyByModelMatrix(Scales);
        }

        private void CalculateRotateX(float angle)
        {
            Rotations = Matrix4.CreateRotationX(angle);
            MultiplyByModelMatrix(Rotations);
        }

        private void CalculateRotateY(float angle)
        {
            Rotations = Matrix4.CreateRotationY(angle);
            MultiplyByModelMatrix(Rotations);
        }

        private void CalculateRotateZ(float angle)
        {
            Rotations = Matrix4.CreateRotationZ(angle);
            MultiplyByModelMatrix(Rotations);
        }


    }
}
