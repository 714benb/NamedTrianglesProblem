using NUnit.Framework;

namespace NamedTrianglesProblem.Models.Tests
{
  [TestFixture()]
  public class TriangleTests
  {
    private static object[] BadVertexCases =
    {
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 0}, "do not form"},
      new object[] {new Vertex() {X = 0, Y = 1}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 0}, "do not form"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 1}, new Vertex() {X = 0, Y = 0}, "do not form"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 1}, "do not form"},
      new object[] {new Vertex() {X = 1, Y = 0}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 0}, "do not form"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 1, Y = 0}, new Vertex() {X = 0, Y = 0}, "do not form"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 1, Y = 0}, "do not form"},
      new object[] {null, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 0}, "cannot be null"},
      new object[] {new Vertex() {X = 0, Y = 0}, null, new Vertex() {X = 0, Y = 0}, "cannot be null"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 0}, null, "cannot be null"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 10}, new Vertex() {X = 0, Y = 1}, "10 px boundaries"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 10}, new Vertex() {X = 0, Y = 11}, "10 px boundaries"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 1}, new Vertex() {X = 0, Y = -10}, "10 px boundaries"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 11}, new Vertex() {X = 0, Y = -10}, "10 px boundaries"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 1, Y = 0}, new Vertex() {X = 0, Y = -10}, "10 px boundaries"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 11, Y = 0}, new Vertex() {X = 0, Y = -10}, "10 px boundaries"},
      new object[] {new Vertex() {X = 0, Y = 1}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = -10}, "10 px boundaries"},
      new object[] {new Vertex() {X = 0, Y = 11}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = -10}, "10 px boundaries"},
      new object[] {new Vertex() {X = 1, Y = 0}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = -10}, "10 px boundaries"},
      new object[] {new Vertex() {X = 11, Y = 0}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = -10}, "10 px boundaries"},
      new object[] {new Vertex() {X = 10, Y = 0}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 70}, "max pixel size"},
      new object[] {new Vertex() {X = 10, Y = 0}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 70, Y = 10 }, "max pixel size"},
      new object[] {new Vertex() {X = 10, Y = 0}, new Vertex() {X = 0, Y = 70}, new Vertex() {X = 10, Y = 10 }, "max pixel size"},
      new object[] {new Vertex() {X = 10, Y = 0}, new Vertex() {X = 70, Y = 0}, new Vertex() {X = 10, Y = 10 }, "max pixel size"},
      new object[] {new Vertex() {X = 70, Y = 70}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 10 }, "max pixel size"},
      new object[] {new Vertex() {X = 10, Y = 0}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = -10 }, "min pixel size"},
      new object[] {new Vertex() {X = 10, Y = 0}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = -10, Y = 10 }, "min pixel size"},
      new object[] {new Vertex() {X = 10, Y = 0}, new Vertex() {X = 0, Y = -10}, new Vertex() {X = 10, Y = 10 }, "min pixel size"},
      new object[] {new Vertex() {X = 10, Y = 0}, new Vertex() {X = -10, Y = 0}, new Vertex() {X = 10, Y = 10 }, "min pixel size"},
      new object[] {new Vertex() {X = 10, Y = -10}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 10 }, "min pixel size"},
      new object[] {new Vertex() {X = -10, Y = 0}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 10 }, "min pixel size"},

    };

    [Test, TestCaseSource("BadVertexCases")]
    public void Create_Should_Return_InvalidTriangle_Tests(Vertex v1, Vertex v2, Vertex v3, string messageIncludes)
    {
      //Arrange

      //Act
      var actual = Triangle.Create(v1, v2, v3);
      //Assert
      Assert.IsInstanceOf<InvalidTriangle>(actual);
      var invalidTraiangle = actual as InvalidTriangle;
      Assert.That(invalidTraiangle.Message, Does.Contain(messageIncludes));

    }

    private static object[] GoodVertexCases =
{
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 0}, new Vertex() {X = 0, Y = 10}},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 0}, new Vertex() {X = 10, Y = 10}},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 10}, new Vertex() {X = 0, Y = 10}},
      new object[] {new Vertex() {X = 0, Y = 10}, new Vertex() {X = 10, Y = 0}, new Vertex() {X = 10, Y = 10}},
      new object[] {new Vertex() {X = 10, Y = 0}, new Vertex() {X = 10, Y = 10}, new Vertex() {X = 0, Y = 10}},
      new object[] { new Vertex() {X = 60, Y = 50}, new Vertex() {X = 60, Y = 60}, new Vertex() {X = 50, Y = 60}},
      //NOTE: this describes more than a single named triangle.  But it is still a valid triangle in that it
      //      could return the multiple named triangles described by the vertices.  This was a design decision
      //      in the absence of a stakeholder to provide feedback.
      new object[] { new Vertex() {X = 0, Y = 0}, new Vertex() {X = 60, Y = 60}, new Vertex() {X = 0, Y = 60}},
      new object[] { new Vertex() {X = 0, Y = 0}, new Vertex() {X = 60, Y = 60}, new Vertex() {X = 60, Y = 0}},
    };


    [Test, TestCaseSource("GoodVertexCases")]
    public void Create_Should_Return_Triangle_Tests(Vertex v1, Vertex v2, Vertex v3)
    {
      //Arrange

      //Act
      var actual = Triangle.Create(v1, v2, v3);
      //Assert
      Assert.IsInstanceOf<Triangle>(actual);
      Assert.IsNotInstanceOf<InvalidTriangle>(actual);
    }


    private static object[] GoodVertexWithNamesCases =
    {
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 0}, new Vertex() {X = 0, Y = 10},  "has no name"},
      new object[] { new Vertex() {X = 0, Y = 10}, new Vertex() {X = 10, Y = 0}, new Vertex() {X = 10, Y = 10},  "has no name"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 0}, new Vertex() {X = 10, Y = 10},  "A2"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 10}, new Vertex() {X = 0, Y = 10},  "A1"},

      new object[] {new Vertex() {X = 10, Y = 0}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 10},  "has no name"},
      new object[] { new Vertex() {X = 10, Y = 0}, new Vertex() { X = 0, Y = 10 }, new Vertex() {X = 10, Y = 10},  "has no name"},
      new object[] {new Vertex() {X = 10, Y = 0}, new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 10},  "A2"},
      new object[] {new Vertex() {X = 10, Y = 10}, new Vertex() { X = 0, Y = 0 }, new Vertex() {X = 0, Y = 10},  "A1"},

      new object[] {new Vertex() {X = 10, Y = 0}, new Vertex() {X = 0, Y = 10}, new Vertex() {X = 0, Y = 0},     "has no name"},
      new object[] { new Vertex() {X = 0, Y = 10},  new Vertex() {X = 10, Y = 10}, new Vertex() { X = 10, Y = 0 }, "has no name" },
      new object[] { new Vertex() {X = 10, Y = 0}, new Vertex() {X = 10, Y = 10}, new Vertex() {X = 0, Y = 0},      "A2"},
      new object[] {new Vertex() {X = 10, Y = 10}, new Vertex() { X = 0, Y = 10 }, new Vertex() { X = 0, Y = 0 },  "A1"},


      new object[] { new Vertex() {X = 50, Y = 50}, new Vertex() {X = 60, Y = 60}, new Vertex() {X = 50, Y = 60},  "F11"},
      //NOTE: this describes more than a single named triangle.  But it is still a valid triangle in that it
      //      could return the multiple named triangles described by the vertices.
      new object[] { new Vertex() {X = 0, Y = 0}, new Vertex() {X = 60, Y = 60}, new Vertex() {X = 0, Y = 60},  "more than 10 pixels apart"},
      new object[] { new Vertex() {X = 0, Y = 0}, new Vertex() {X = 60, Y = 60}, new Vertex() {X = 60, Y = 0},  "more than 10 pixels apart"},
    };
    [Test, TestCaseSource("GoodVertexWithNamesCases")]
    public void CalculateName_Should_Return_Correct_Name_Tests(Vertex v1, Vertex v2, Vertex v3, string expected)
    {
      //Arrange
      var triangle = Triangle.Create(v1, v2, v3);
      //Act
      var actual = triangle.CalculateName();
      //Assert
      if (expected.Length == 2)
      {
        Assert.That(actual, Is.EqualTo(expected));
      }
      else
      {
        Assert.That(actual, Does.Contain(expected));

      }
    }

  }
}