using System.Collections.Generic;
using System.Linq;
using NamedTrianglesProblem.Models;

namespace NamedTrianglesProblem.Models
{
  public class TriangleFactory : ITriangleFactory
  {
    public Triangle Create(Vertex v1, Vertex v2, Vertex v3)
    {
      var vertices = new List<Vertex>() {v1, v2, v3};
      if (CheckForNulls(vertices, out var verticesAreNulls)) return verticesAreNulls;

      if (CheckVerticesFormATriangle(v1, v2, v3, out var notATriangle)) return notATriangle;

      if (CheckVerticiesAreInTenPixelIncrements(v1, v2, v3, vertices, out var badDimensionsTriangle))
        return badDimensionsTriangle;

      if (CheckTriangleMaxSize(v1, v2, v3, vertices, out var badSizeTriangle)) return badSizeTriangle;

      if (CheckTriangleMinSize(v1, v2, v3, vertices, out var negSizeTriangle)) return negSizeTriangle;

      return new Triangle() {Vertex1 = v1, Vertex2 = v2, Vertex3 = v3};
    }

    private static bool CheckTriangleMaxSize(Vertex v1, Vertex v2, Vertex v3, List<Vertex> vertices,
      out Triangle triangle)
    {
      if (vertices.Any(v => v.X > Const.MAX_PIXELS || v.Y > Const.MAX_PIXELS))
      {
        {
          triangle = new InvalidTriangle()
          {
            Vertex1 = vertices[0],
            Vertex2 = vertices[1],
            Vertex3 = vertices[2],
            Message =
              $"Invalid Triangle, exceeds max pixel size of {Const.MAX_PIXELS}: v1={vertices[0]}, v2={vertices[1]}, v3={vertices[2]}"
          };
          return true;
        }
      }

      triangle = null;
      return false;
    }

    private static bool CheckTriangleMinSize(Vertex v1, Vertex v2, Vertex v3, List<Vertex> vertices,
      out Triangle triangle)
    {
      if (vertices.Any(v => v.X < 0 || v.Y < 0))
      {
        {
          triangle = new InvalidTriangle()
          {
            Vertex1 = vertices[0],
            Vertex2 = vertices[1],
            Vertex3 = vertices[2],
            Message =
              $"Invalid Triangle, under min pixel size of {0}: v1={vertices[0]}, v2={vertices[1]}, v3={vertices[2]}"
          };
          return true;
        }
      }

      triangle = null;
      return false;
    }

    private static bool CheckVerticiesAreInTenPixelIncrements(Vertex v1, Vertex v2, Vertex v3, List<Vertex> vertices,
      out Triangle triangle)
    {
      if (vertices.Any(v => v.X % Const.WIDTH_IN_PIXELS != 0 || v.Y % Const.WIDTH_IN_PIXELS != 0))
      {
        {
          triangle = new InvalidTriangle()
          {
            Vertex1 = vertices[0],
            Vertex2 = vertices[1],
            Vertex3 = vertices[2],
            Message =
              $"Invalid Triangle, vertices do all fall on {Const.WIDTH_IN_PIXELS} px boundaries: v1=v1={vertices[0]}, v2={vertices[1]}, v3={vertices[2]}"
          };
          return true;
        }
      }

      triangle = null;
      return false;
    }

    private static bool CheckVerticesFormATriangle(Vertex v1, Vertex v2, Vertex v3, out Triangle triangle)
    {
      if (v1.Equals(v2) || v1.Equals(v3) || v2.Equals(v3))
      {
        {
          triangle = new InvalidTriangle()
          {
            Vertex1 = v1,
            Vertex2 = v2,
            Vertex3 = v3,
            Message = $"Invalid Triangle, vertices do not form a triangle v1={v1}, v2={v2}, v3={v3}"
          };
          return true;
        }
      }

      triangle = null;
      return false;
    }

    private static bool CheckForNulls(List<Vertex> vertices, out Triangle triangle)
    {

      if (vertices.Any(v => v is null))
      {
        {
          triangle = new InvalidTriangle()
          {
            Vertex1 = vertices[0],
            Vertex2 = vertices[1],
            Vertex3 = vertices[2],
            Message = $"Invalid Triangle, vertices cannot be null, v1={vertices[0]}, v2={vertices[1]}, v3={vertices[2]}"
          };
          return true;
        }
      }

      triangle = null;
      return false;
    }
  }
}