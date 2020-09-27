using NUnit.Framework;
using NamedTrianglesProblem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NamedTrianglesProblem.Models.Tests
{
  [TestFixture()]
  public class VertexTests
  {

    //Note:  These are trivial tests that I wouldn't normally write but I want to
    //       demonstrate my process which is to create simple tests then create
    //       data driven tests or even integration tests driven from the unit test runner.
    [Test()]
    public void Equals_ReturnsTrueWhen_PropertiesAreEqual_Test()
    {
      //Arrange
      var v1 = new Vertex() {X=1, Y=1};
      var v2 = new Vertex() {X=1, Y=1};
      //Act
      var actual = v1.Equals(v2);
      //Assert
      Assert.That(actual, Is.True);
    }

    [Test()]
    public void Equals_ReturnsFalseWhen_PropertiesAreNotEqual_Test()
    {
      //Arrange
      var v1 = new Vertex() { X = 1, Y = 2 };
      var v2 = new Vertex() { X = 1, Y = 1 };
      //Act
      var actual = v1.Equals(v2);
      //Assert
      Assert.That(actual, Is.False);
    }

    //NOTE: I wrote the operator definitions as opposed to using Resharper to generate
    //      the IEquatable<Vertex> and IEqualityComparer<Vertex> implementations.  They
    //      are more deserving of tests, though they are still trivial.
    [Test()]
    public void EqualsOperator_ReturnsTrueWhen_PropertiesAreEqual_Test()
    {
      //Arrange
      var v1 = new Vertex() { X = 1, Y = 1 };
      var v2 = new Vertex() { X = 1, Y = 1 };
      //Act
      var actual = v1 == v2;
      //Assert
      Assert.That(actual, Is.True);
    }

    [Test()]
    public void EqualsOperator_ReturnsFalseWhen_PropertiesAreNotEqual_Test()
    {
      //Arrange
      var v1 = new Vertex() { X = 1, Y = 2 };
      var v2 = new Vertex() { X = 1, Y = 1 };
      //Act
      var actual = v1 == v2;
      //Assert
      Assert.That(actual, Is.False);
    }

    private static object[] VertexPairs =
    {
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 0}, true},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 1, Y = 0}, false},
      new object[] {new Vertex() {X = 0, Y = 0}, new Vertex() {X = 0, Y = 1}, false},
      new object[] {new Vertex() {X = 1, Y = 0}, new Vertex() {X = 0, Y = 0}, false},
      new object[] {new Vertex() {X = 0, Y = 1}, new Vertex() {X = 0, Y = 0}, false},
    };

    [Test, TestCaseSource("VertexPairs")]
    public void EqualsOperator_ReturnsExpectedValue_Test(Vertex v1, Vertex v2,bool expected)
    {
      //Arrange
      //Act
      var actual = v1 == v2;
      //Assert
      Assert.That(actual, Is.EqualTo(expected));
    }

    //NOTE: It may not be advisable to use this "notExpected" pattern unless the team/company
    //      agrees the shortcut (i.e. not needing to create a new list of values) is worth the
    //      added confusion.   It does, however have the added benefit of testing the same values
    //      which could help mitigate typo testing errors (particularly if the list is long or 
    //      complicated.

    [Test, TestCaseSource("VertexPairs")]
    public void NotEqualsOperator_ReturnsExpectedValue_Test(Vertex v1, Vertex v2, bool notExpected)
    {
      //Arrange
      //Act
      var actual = v1 != v2;
      //Assert
      Assert.That(actual, Is.Not.EqualTo(notExpected));
    }
  }
}