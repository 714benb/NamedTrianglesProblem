using System;
using System.Collections.Generic;
using System.Linq;
using NamedTrianglesProblem.Model;

namespace NamedTrianglesProblem.Models
{
  public class Triangle
  {
    public readonly char[] AlphaMatrix = {'A', 'B', 'C', 'D', 'E', 'F'};
    public Vertex Vertex1 { get; set; }
    public Vertex Vertex2 { get; set; }
    public Vertex Vertex3 { get; set; }

    /// <summary>
    /// Calculates the name of the triangle defined by the vertices of this triangle.
    /// If it is not a valid triangle or it is larger then a single named triangle
    /// a message is returned instead of the name.
    /// </summary>
    /// <returns>
    /// The name of the triangle or a message indicating why the name could not be returned.
    /// </returns>
    public string CalculateName()
    {
      if (this is InvalidTriangle)
        return ((InvalidTriangle) this).Message;

      var vertices = new List<Vertex>()
      {
        Vertex1, Vertex2, Vertex3
      };

      var upperLeftVertex = FindUpperLeftVertex(vertices);
      var otherVertices = vertices.Where(v => v != upperLeftVertex).ToArray();

      if (DoesTriangleContainMultipleNamedTriangles(otherVertices, upperLeftVertex))
      {
        return
          $"Unnamed Triangle, the vertices are more than {Const.WIDTH_IN_PIXELS} pixels apart: v1={Vertex1}, v2={Vertex2}, v3={Vertex3}";
        //NOTE: This is an area where we could enhance the model/business logic to return all the names of the
        //      multiple named triangles described by these vertices.
        //      But since that was not the current requirement it is considered an invalid triangle.
      }
      if (IsHypotenuseRightToLeft(otherVertices, upperLeftVertex))
      {
        return
          $"Unnamed Triangle, the vertices describe a triangle that has no name: v1={Vertex1}, v2={Vertex2}, v3={Vertex3}";
      }
      var alphaComponentOfName = CalculateAlphaComponent(upperLeftVertex);
      var numericComponentOfName = CalculateNumericComponent(upperLeftVertex, otherVertices);

      return $"{alphaComponentOfName}{numericComponentOfName}";
    }

    private static bool DoesTriangleContainMultipleNamedTriangles(Vertex[] otherVertices, Vertex upperLeftVertex)
    {
      return otherVertices.Any(v => Math.Abs(v.X - upperLeftVertex.X) > Const.WIDTH_IN_PIXELS ||
                                    Math.Abs(v.Y - upperLeftVertex.Y) > Const.WIDTH_IN_PIXELS);
    }

    private static bool IsHypotenuseRightToLeft(Vertex[] otherVertices, Vertex upperLeftVertex)
    {
      /*
       Both Right to Left hypotenuse triangles have no X10,Y10 vertex and thus do not have a name.
                           X,Y - upper rightmost
                           / |
                          /  | 
                X-10,Y10 -----  X0,Y10  - other vertices
      X0 or X1 is < X 

      OR

      upper rightmost - X,Y -----  X10,Y0 - other vertices
                            |  /
                            | /
                          X0,Y10  - other vertices
      X0 or X1 is = X  and the other is > X

     
      Both Left to Right hypotenuse triangles have an X10, Y10 vertex and thus have a name
          upper rightmost - X,Y 
                            | \
                            |  \
                       X0,Y10 ---- X10,Y10  - other vertices
      X0 and X1 are equal

      OR

      upper rightmost - X,Y ---- X10,Y0 - other vertices
                            \  | 
                             \ |
                              X10,Y10  - other vertices
      X0 or X1 is = X  and the other is > X

      */
      var x10 = upperLeftVertex.X + Const.WIDTH_IN_PIXELS;
      var y10 = upperLeftVertex.Y + Const.WIDTH_IN_PIXELS;
      return false == otherVertices.Any(v => v.X == x10 && v.Y == y10);
    }

    private int CalculateNumericComponent(Vertex upperLeftVertex, Vertex[] otherVertices)
    {
      var numericComponent = upperLeftVertex.X / Const.WIDTH_IN_PIXELS * Const.NAMES_PER_SQUARE + Const.ZERO_BASE_ADJUST;
      if (otherVertices[0].Y != otherVertices[1].Y)
      {
        numericComponent++;
      }

      return numericComponent;
    }

    private char CalculateAlphaComponent(Vertex upperLeftVertex)
    {
      var alphaIndex = upperLeftVertex.Y / Const.WIDTH_IN_PIXELS;
      return AlphaMatrix[alphaIndex];
    }

    private Vertex FindUpperLeftVertex(List<Vertex> vertexList)
    {
      /*
         Upper is defined by the lowest Y.  There are either one or two 
        vertices that are at this value of Y.   Of those the one with the
        lower X is the left most.

            upper left most - X,Y             There is only one
                             / |
                            /  | 
                  X-10,Y10 -----  X0,Y10  
        
        upper left most - X,Y -----  X10,Y0    X is left of X10
                              |  /
                              | /
                            X0,Y10  
       
       
            upper left most - X,Y             There is only one
                              | \
                              |  \
                         X0,Y10 ---- X10,Y10  
        
        upper left most - X,Y ---- X10,Y0     X is left of X10
                              \  | 
                               \ |
                                X10,Y10
      */
      var minY = vertexList.Select(v => v.Y).Prepend(int.MaxValue).Min();

      var upperVertices = vertexList.Where(v => v.Y == minY).ToArray();
      if (upperVertices.Length == 1)
      {
        return upperVertices[0];
      }
      else
      {
        return upperVertices[0].X < upperVertices[1].X ? upperVertices[0] : upperVertices[1];
      }
    }

    public override string ToString()
    {
      return $"({Vertex1.X},{Vertex1.Y})x({Vertex2.X},{Vertex2.Y})x({Vertex3.X},{Vertex3.Y})";
    }

    public static Triangle Create(Vertex v1, Vertex v2, Vertex v3)
    {
      var vertices = new List<Vertex>() {v1, v2, v3};
      if (CheckForNulls(vertices, out var verticesAreNulls)) return verticesAreNulls;

      if (CheckVerticesFormATriangle(v1, v2, v3, out var notATriangle)) return notATriangle;

      if (CheckVerticiesAreInTenPixelIncrements(v1, v2, v3, vertices, out var badDimensionsTriangle)) return badDimensionsTriangle;

      if (CheckTriangleMaxSize(v1, v2, v3, vertices, out var badSizeTriangle)) return badSizeTriangle;
      
      if (CheckTriangleMinSize(v1, v2, v3, vertices, out var negSizeTriangle)) return negSizeTriangle;

      return new Triangle() {Vertex1 = v1, Vertex2 = v2, Vertex3 = v3};
    }

    private static bool CheckTriangleMaxSize(Vertex v1, Vertex v2, Vertex v3, List<Vertex> vertices, out Triangle triangle)
    {
      if (vertices.Any(v => v.X > Const.MAX_PIXELS || v.Y > Const.MAX_PIXELS))
      {
        {
          triangle = new InvalidTriangle()
          {
            Vertex1 = vertices[0],
            Vertex2 = vertices[1],
            Vertex3 = vertices[2],
            Message = $"Invalid Triangle, exceeds max pixel size of {Const.MAX_PIXELS}: v1={vertices[0]}, v2={vertices[1]}, v3={vertices[2]}"
          };
          return true;
        }
      }

      triangle = null;
      return false;
    }

    private static bool CheckTriangleMinSize(Vertex v1, Vertex v2, Vertex v3, List<Vertex> vertices, out Triangle triangle)
    {
      if (vertices.Any(v => v.X < 0 || v.Y < 0))
      {
        {
          triangle = new InvalidTriangle()
          {
            Vertex1 = vertices[0],
            Vertex2 = vertices[1],
            Vertex3 = vertices[2],
            Message = $"Invalid Triangle, under min pixel size of {0}: v1={vertices[0]}, v2={vertices[1]}, v3={vertices[2]}"
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
            Message = $"Invalid Triangle, vertices do all fall on {Const.WIDTH_IN_PIXELS} px boundaries: v1=v1={vertices[0]}, v2={vertices[1]}, v3={vertices[2]}"
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
