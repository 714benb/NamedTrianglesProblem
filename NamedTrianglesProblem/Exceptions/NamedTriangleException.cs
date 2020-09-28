using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace NamedTrianglesProblem.Exceptions
{
  [Serializable]
  public class NamedTriangleException:Exception
  {
    public NamedTriangleException()
    {
    }

    public NamedTriangleException(string message)
      :base(message)
    {
    }

    public NamedTriangleException(string message, Exception innerException)
      :base(message, innerException)
    {
    }
    protected NamedTriangleException(SerializationInfo info, StreamingContext context)
      :base(info, context)
    {
    }
  }
}
