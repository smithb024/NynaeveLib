namespace NynaeveLib.Enumerations.Converters
{
  using NynaeveLib.Enumerations;

  /// <summary>
  /// Static class, used to read the sex type from a string.
  /// </summary>
  public static class StringToSexType
  {
    /// <summary>
    /// Converts the incoming string to an integer.
    /// </summary>
    /// <param name="inputString">input string</param>
    /// <returns>integer number</returns>
    public static SexType ConvertStringToSexType(string inputString)
    {
      if (inputString == null)
      {
        return SexType.Default;
      }

      if (inputString == SexType.Male.ToString())
      {
        return SexType.Male;
      }
      else if (inputString == SexType.Female.ToString())
      {
        return SexType.Female;
      }
      else
      {
        return SexType.Default;
      }
    }
  }
}