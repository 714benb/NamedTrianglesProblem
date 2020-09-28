using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace NamedTrianglesProblem
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var path = Environment.CurrentDirectory;
      Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File($"{path}\\logs\\log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit:3)
        .CreateLogger();

      try
      {
        Log.Information("Named Triangles Problem API Starting up");
        CreateHostBuilder(args).Build().Run();
      }
      catch (Exception e)
      {
        Log.Fatal(e, "Named Triangles Problem API Start-up failed");
      }
      finally
      {
        Log.Information("Named Triangles Problem API Shut down");
        Log.CloseAndFlush();
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
