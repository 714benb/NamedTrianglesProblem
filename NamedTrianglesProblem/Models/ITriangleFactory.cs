namespace NamedTrianglesProblem.Models
{
  public interface ITriangleFactory
  {
    Triangle Create(Vertex v1, Vertex v2, Vertex v3);
  }
}