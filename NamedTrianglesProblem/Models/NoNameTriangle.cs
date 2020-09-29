using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamedTrianglesProblem.Models
{
  public class NoNameTriangle : Triangle
  {
    /// <summary>
    /// Calculates the name of the triangle defined by the vertices of this triangle.
    /// If it is not a valid triangle or it is larger then a single named triangle
    /// a message is returned instead of the name.
    /// </summary>
    /// <returns>
    /// The name of the triangle or a message indicating why the name could not be returned.
    /// </returns>
    public override string CalculateName()
    {
      return
        $"Unnamed Triangle, the vertices describe a triangle that has no name: v1={Vertex1}, v2={Vertex2}, v3={Vertex3}";
    }

  }
}
