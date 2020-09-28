using System;
using System.Collections.Generic;

namespace NamedTrianglesProblem.Models
{
  public class Vertex : IEquatable<Vertex>, IEqualityComparer<Vertex>
  {
    /// <summary>
    /// The X coordinate of the Vertex
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// The Y coordinate of the Vertex
    /// </summary>
    public int Y { get; set; }

    /// <summary>Returns a string that represents the vertex as a (x,y) pair.</summary>
    /// <returns>A string for the (x,y) coordinates of the Vertex.</returns>
    /// <remarks>Overriding the ToString makes debugging and interpolation much easier.</remarks>
    public override string ToString()
    {
      return $"({X},{Y})";
    }

    #region IEquatable<Vertex> implementation

    /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>
    /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
    public bool Equals(Vertex other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return X == other.X && Y == other.Y;
    }

    /// <summary>Determines whether the specified object is equal to the current object.</summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>
    /// <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((Vertex) obj);
    }

    /// <summary>Serves as the default hash function.</summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
      return HashCode.Combine(X, Y);
    }
    #endregion IEquatable<Vertex> implementation

    #region  IEqualityComparer<Vertex> implementation
    /// <summary>
    /// Equals comparer for two Vertex objects 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool Equals(Vertex x, Vertex y)
    {
      if (ReferenceEquals(x, y)) return true;
      if (ReferenceEquals(x, null)) return false;
      if (ReferenceEquals(y, null)) return false;
      if (x.GetType() != y.GetType()) return false;
      return x.X == y.X && x.Y == y.Y;
    }

    /// <summary>
    /// Get the hash code of a Vertex object
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>

    public int GetHashCode(Vertex obj)
    {
      return obj.GetHashCode();
    }
    #endregion  IEqualityComparer<Vertex>
    public static bool operator == (Vertex v1, Vertex v2)
    {
      return (v1?.Equals(v2)??false);
    }

    public static bool operator != (Vertex v1, Vertex v2)
    {
      return (v1?.Equals(v2) ?? false) == false;
    }


  }
}