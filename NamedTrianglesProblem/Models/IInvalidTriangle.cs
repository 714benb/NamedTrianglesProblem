namespace NamedTrianglesProblem.Models
{
  public interface IInvalidTriangle
  {
    /// <summary>
    /// A message indicating why this is an invalid triangle.
    /// </summary>
    string Message { get; set; }
  }
}