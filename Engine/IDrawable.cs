﻿using OpenTK.Mathematics;

namespace Initial_project.Engine
{
    interface IDrawable
    {
        public void Draw();
        public void Destroy();
        public void SetViewProjectionMatrix(Matrix4 viewProjectionMatrix);
        public void Move(Vector3 direction);
        public void RotateX(float angle);
        public void RotateY(float angle);
        public void RotateZ(float angle);
        public void Scale(Vector3 factor);
    }
}
