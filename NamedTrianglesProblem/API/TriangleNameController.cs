using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NamedTrianglesProblem.Models;

namespace NamedTrianglesProblem.API
{
  [Route("api/[controller]")]
  [ApiController]
  public class TriangleNameController : ControllerBase
  {
    // GET API/triangleName?v1.X=0&v1.Y=0&v2.X=10&v2.Y=10&v3.X=0&v3.Y=10
    [HttpGet()]
    public string Get([FromQuery] Vertex v1, [FromQuery] Vertex v2, [FromQuery] Vertex v3)
    {
      var triangle = Triangle.Create(v1, v2, v3);

      return triangle.CalculateName();
    }
  }
}
