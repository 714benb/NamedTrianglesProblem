namespace NamedTrianglesProblem.Models
{
  public interface ITriangleFactory
  {
    ITriangle Create(Vertex v1, Vertex v2, Vertex v3);
  }
}