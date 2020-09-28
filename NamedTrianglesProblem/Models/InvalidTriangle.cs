namespace NamedTrianglesProblem.Models
{
  public class InvalidTriangle : Triangle
  {
    /// <summary>
    /// A message indicating why this is an invalid triangle.
    /// </summary>
    public string Message { get; set; }
  }
}