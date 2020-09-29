using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamedTrianglesProblem.Models
{
  public class SingleNameTriangle:Triangle
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
      var vertices = new List<Vertex>()
      {
        Vertex1, Vertex2, Vertex3
      };

      var upperLeftVertex = FindUpperLeftVertex(vertices);
      var otherVertices = vertices.Where(v => v != upperLeftVertex).ToArray();
      var alphaComponentOfName = CalculateAlphaComponent(upperLeftVertex);
      var numericComponentOfName = CalculateNumericComponent(upperLeftVertex, otherVertices);

      return $"{alphaComponentOfName}{numericComponentOfName}";
    }
  }
}
