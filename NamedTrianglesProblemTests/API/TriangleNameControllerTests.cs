using NUnit.Framework;
using NamedTrianglesProblem.API;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using NamedTrianglesProblem.Models;

namespace NamedTrianglesProblem.API.Tests
{
  [TestFixture()]
  public class TriangleNameControllerTests
  {
    [Test()]
    public void Get_Returns_JsonResult_Test()
    {
      //Arrange
      var sut = new TriangleNameController();

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
      var sut = new TriangleNameController();

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
  }
}