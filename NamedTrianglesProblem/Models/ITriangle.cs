namespace NamedTrianglesProblem.Models
{
  public interface ITriangle
  {
    Vertex Vertex1 { get; set; }
    Vertex Vertex2 { get; set; }
    Vertex Vertex3 { get; set; }

    /// <summary>
    /// Calculates the name of the triangle defined by the vertices of this triangle.
    /// If it is not a valid triangle or it is larger then a single named triangle
    /// a message is returned instead of the name.
    /// </summary>
    /// <returns>
    /// The name of the triangle or a message indicating why the name could not be returned.
    /// </returns>
    string CalculateName();

    string ToString();
  }
}