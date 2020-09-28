namespace NamedTrianglesProblem.Model
{
  //NOTE: depending on the actual requirements these could be moved
  //      to a configuration file to allow for
  //      larger arrays of triangles, different pixel widths etc.
  //      I considered it outside the scope of this project since these values
  //      are "fixed" by the problem definition.
  static internal class Const
  {
    public const int MAX_PIXELS = 60;
    public const int ZERO_BASE_ADJUST = 1;
    public const int NAMES_PER_SQUARE = 2;
    public const int WIDTH_IN_PIXELS = 10;
    public static readonly char[] AlphaMatrix = { 'A', 'B', 'C', 'D', 'E', 'F' };

  }
}