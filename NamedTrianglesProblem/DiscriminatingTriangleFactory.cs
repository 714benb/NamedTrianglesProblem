using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NamedTrianglesProblem.Models;

namespace NamedTrianglesProblem
{
  public class DiscriminatingTriangleFactory : TriangleFactory
  {
    public override ITriangle Create(Vertex v1, Vertex v2, Vertex v3)
    {
      var possibleInvalidTriangle = base.Create(v1, v2, v3);
      if (possibleInvalidTriangle is IInvalidTriangle)
        return possibleInvalidTriangle;

      var vertices = new List<Vertex>()
      {
        v1, v2, v3
      };

      var upperLeftVertex = FindUpperLeftVertex(vertices);
      var otherVertices = vertices.Where(v => v != upperLeftVertex).ToArray();
      if (DoesTriangleContainMultipleNamedTriangles(otherVertices, upperLeftVertex))
      {
        return new MultipleNamedTriangle() { Vertex1 = v1, Vertex2 = v2, Vertex3 = v3 };
      }
      if (IsHypotenuseRightToLeft(otherVertices, upperLeftVertex))
      {
        return new NoNameTriangle() { Vertex1 = v1, Vertex2 = v2, Vertex3 = v3 };
      }

      return new SingleNameTriangle() {Vertex1 = v1, Vertex2 = v2, Vertex3 = v3};
    }

    protected virtual Vertex FindUpperLeftVertex(List<Vertex> vertexList)
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

  }
}
