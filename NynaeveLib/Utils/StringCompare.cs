namespace NynaeveLib.Utils
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// Set of string comparison methods
  /// </summary>
  public static class StringCompare
  {
    /// <summary>
    /// Standard comparison
    /// </summary>
    /// <param name="lhs">left hand side</param>
    /// <param name="rhs">right hand side</param>
    /// <returns>true if equal</returns>
    public static bool SimpleCompare(string lhs, string rhs)
    {
      return string.Compare(lhs, rhs, StringComparison.Ordinal) == 0;
    }

    /// <summary>
    /// Compare ignoring case
    /// </summary>
    /// <param name="lhs">left hand side</param>
    /// <param name="rhs">right hand side</param>
    /// <returns>true if equal</returns>
    public static bool CompareIgnoreCase(string lhs, string rhs)
    {
      return string.Compare(lhs, rhs, StringComparison.OrdinalIgnoreCase) == 0;
    }

    /// <summary>
    /// Compare string with empty.
    /// </summary>
    /// <param name="lhs">left hand side</param>
    /// <returns>true if empty</returns>
    public static bool CompareEmpty(string lhs)
    {
      return string.Compare(lhs, string.Empty) == 0;
    }

    /// <summary>
    /// Compare string with null or empty.
    /// </summary>
    /// <param name="lhs">left hand side</param>
    /// <returns>true if null or empty</returns>
    public static bool CompareNullOrEmpty(string lhs)
    {
      return string.Compare(lhs, null) == 0 || string.Compare(lhs, string.Empty) == 0;
    }
  }
}