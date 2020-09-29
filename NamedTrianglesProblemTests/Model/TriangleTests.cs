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
      var actual = new TriangleFactory().Create(v1, v2, v3);
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
      var actual = new TriangleFactory().Create(v1, v2, v3);
      //Assert
      Assert.IsInstanceOf<Triangle>(actual);
      Assert.IsNotInstanceOf<InvalidTriangle>(actual);
    }


    private static object[] VertexWithNamesCases =
    {
      //upper left most 10x10 square
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 0}, new Vertex() {X = 0, Y = 10},  "has no name"},
      new object[] {new Vertex() {X = 0, Y = 10}, new Vertex() {X = 10, Y = 0}, new Vertex() {X = 10, Y = 10},  "has no name"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 0}, new Vertex() {X = 10, Y = 10},  "A2"},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 10, Y = 10}, new Vertex() {X = 0, Y = 10},  "A1"},
      //lower right most 10x10 square
      new object[] {new Vertex() {X = 50, Y = 50}, new Vertex() {X = 60, Y = 50}, new Vertex() {X = 50, Y = 60},  "has no name"},
      new object[] {new Vertex() {X = 50, Y = 60}, new Vertex() {X = 60, Y = 50}, new Vertex() {X = 60, Y = 60},  "has no name"},
      new object[] {new Vertex() {X = 50, Y = 50}, new Vertex() {X = 60, Y = 50}, new Vertex() {X = 60, Y = 60},  "F12"},
      new object[] {new Vertex() {X = 50, Y = 50}, new Vertex() {X = 60, Y = 60}, new Vertex() {X = 50, Y = 60},  "F11"},
      //central 10x10 square
      new object[] {new Vertex() {X = 30, Y = 30}, new Vertex() {X = 40, Y = 30}, new Vertex() {X = 30, Y = 40},  "has no name"},
      new object[] {new Vertex() {X = 30, Y = 40}, new Vertex() {X = 40, Y = 30}, new Vertex() {X = 40, Y = 40},  "has no name"},
      new object[] {new Vertex() {X = 30, Y = 30}, new Vertex() {X = 40, Y = 30}, new Vertex() {X = 40, Y = 40},  "D8"},
      new object[] {new Vertex() {X = 30, Y = 30}, new Vertex() {X = 40, Y = 40}, new Vertex() {X = 30, Y = 40},  "D7"},
      //NOTE: this describes more than a single named triangle.  But it is still a valid triangle in that it
      //      could return the multiple named triangles described by the vertices.
      new object[] { new Vertex() {X = 0, Y = 0}, new Vertex() {X = 60, Y = 60}, new Vertex() {X = 0, Y = 60},  "more than 10 pixels apart"},
      new object[] { new Vertex() {X = 0, Y = 0}, new Vertex() {X = 60, Y = 60}, new Vertex() {X = 60, Y = 0},  "more than 10 pixels apart"},

      //Invalid Triangles
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
    [Test, TestCaseSource("VertexWithNamesCases")]
    public void CalculateName_Should_Return_Correct_Name_Tests(Vertex v1, Vertex v2, Vertex v3, string expected)
    {
      //Arrange
      var triangle = new TriangleFactory().Create(v1, v2, v3);
      //Act
      var actual = triangle.CalculateName();
      //Assert
      Assert.That(actual, Does.Contain(expected));
    }

    [Test, TestCaseSource("VertexWithNamesCases")]
    public void DiscriminatingTriangleFactory_CalculateName_Should_Return_Correct_Name_Tests(Vertex v1, Vertex v2, Vertex v3, string expected)
    {
      //Arrange
      var triangle = new DiscriminatingTriangleFactory().Create(v1, v2, v3);
      //Act
      var actual = triangle.CalculateName();
      //Assert
      Assert.That(actual, Does.Contain(expected));
    }

    [Test, TestCaseSource("VertexWithNamesCases")]
    public void CalculateName_Should_Return_Correct_Name_RegardlessOfOrder_Tests(Vertex v1, Vertex v2, Vertex v3, string expected)
    {
      //Arrange
      var triangle = new TriangleFactory().Create(v1, v2, v3);
      //Act
      var actual = triangle.CalculateName();
      //Assert
      Assert.That(actual.Contains(expected), "v1, v2, v3");

      //Arrange
      triangle = new TriangleFactory().Create(v1, v3, v2);
      //Act
      actual = triangle.CalculateName();
      //Assert
      Assert.That(actual.Contains(expected), "v1, v3, v2");

      //Arrange
      triangle = new TriangleFactory().Create(v2, v3, v1);
      //Act
      actual = triangle.CalculateName();
      //Assert
      Assert.That(actual.Contains(expected), "v2, v3, v1");

      //Arrange
      triangle = new TriangleFactory().Create(v2, v1, v3);
      //Act
      actual = triangle.CalculateName();
      //Assert
      Assert.That(actual.Contains(expected), "v2, v1, v3");

      //Arrange
      triangle = new TriangleFactory().Create(v3, v2, v1);
      //Act
      actual = triangle.CalculateName();
      //Assert
      Assert.That(actual.Contains(expected), "v3, v2, v1");

      //Arrange
      triangle = new TriangleFactory().Create(v3, v1, v2);
      //Act
      actual = triangle.CalculateName();
      //Assert
      Assert.That(actual.Contains(expected), "v3, v1, v2");

    }
  }
}