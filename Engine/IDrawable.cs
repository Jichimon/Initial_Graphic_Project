using OpenTK.Mathematics;

namespace Initial_project.Engine
{
    interface IDrawable
    {
        public void Draw();
        public void Destroy();
        public void SetViewProjectionMatrix(Matrix4 ViewProjectionMatrix);
    }
}
