using NUnit.Framework;
using NamedTrianglesProblem.API;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Numerics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using NamedTrianglesProblem.Exceptions;
using NamedTrianglesProblem.Models;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace NamedTrianglesProblem.API.Tests
{
  [TestFixture()]
  public class TriangleNameControllerTests
  {
    [Test()]
    public void Get_Returns_JsonResult_Test()
    {
      //Arrange
      var sut = new TriangleNameController(new TriangleFactory());

      var v1 = new Vertex(){X=0,Y=0};
      var v2 = new Vertex(){X=0,Y=10};
      var v3 = new Vertex(){X=10,Y=10};
      //Act
      var actual = sut.Get(v1, v2, v3);
      //Asert
      Assert.That(actual, Is.InstanceOf<JsonResult>());
    }

    [Test()]
    public void Get_Returns_Expected_Value_Test()
    {
      //Arrange
      var sut = new TriangleNameController(new TriangleFactory());

      var v1 = new Vertex() { X = 0, Y = 0 };
      var v2 = new Vertex() { X = 0, Y = 10 };
      var v3 = new Vertex() { X = 10, Y = 10 };

      var expected = "A1";
      //Act
      var actual = sut.Get(v1, v2, v3);
      //Assert
      if (actual is JsonResult asResult)
      {
        Assert.That(asResult.Value, Is.EqualTo(expected));
      }
      else
      {
        Assert.Fail("Get should return JsonResult");
      }
    }

    [Test()]
    public void Get_Returns_500Error_WhenUnexpectedErrorOccurs_Test()
    {
      //Arrange
      var mockFactory = Mock.Create<ITriangleFactory>();

      var sut = new TriangleNameController(mockFactory);

      var v1 = new Vertex() { X = 0, Y = 0 };
      var v2 = new Vertex() { X = 0, Y = 10 };
      var v3 = new Vertex() { X = 10, Y = 10 };
      Mock.Arrange(() => mockFactory.Create(Arg.IsAny<Vertex>(), Arg.IsAny<Vertex>(), Arg.IsAny<Vertex>()))
        .IgnoreArguments()
        .DoInstead(() => throw new NamedTriangleException());
      var expectedStatus = 500;
      //Act
      var actual = sut.Get(v1, v2, v3);
      //Assert
      if (actual is ObjectResult asResult)
      {
        Assert.That(asResult.StatusCode.HasValue, Is.True);
        Assert.That(asResult.StatusCode.Value, Is.EqualTo(expectedStatus));
      }
      else
      {
        Assert.Fail("Get should return ObjectResult");
      }
    }

    [Test()]
    public void Get_Returns_ErrorMessage_WhenUnexpectedErrorOccurs_Test()
    {
      //Arrange
      var mockFactory = Mock.Create<ITriangleFactory>();

      var sut = new TriangleNameController(mockFactory);

      var v1 = new Vertex() { X = 0, Y = 0 };
      var v2 = new Vertex() { X = 0, Y = 10 };
      var v3 = new Vertex() { X = 10, Y = 10 };
      Mock.Arrange(() => mockFactory.Create(Arg.IsAny<Vertex>(), Arg.IsAny<Vertex>(), Arg.IsAny<Vertex>()))
        .IgnoreArguments()
        .DoInstead(() => throw new NamedTriangleException());
      var expected = "Unanticipated exception, \"Exception of type 'NamedTrianglesProblem.Exceptions.NamedTriangleException' was thrown.\". \nContact your administrator";
      //Act
      var actual = sut.Get(v1, v2, v3);
      //Assert
      if (actual is ObjectResult asResult)
      {
        Assert.That(asResult.Value, Is.EqualTo(expected));
      }
      else
      {
        Assert.Fail("Get should return ObjectResult");
      }
    }
  }
}