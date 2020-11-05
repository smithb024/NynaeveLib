namespace NynaeveLib.Decoders
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// Static class used to determine sections of strings
  /// </summary>
  public static class SplitStringDecoder
  {
    /// <summary>
    /// Split the incoming string using the delimiter. Return the contents of the requested cell
    /// if present.
    /// </summary>
    /// <param name="inputString">string to split</param>
    /// <param name="delimiter">delimiter character</param>
    /// <param name="cell">section number to return</param>
    /// <returns>section indicated by the cell</returns>
    public static string ReturnSectionOfString(string inputString,
                                               char delimiter,
                                               int cell)
    {
      // Consistency check
      if (
        cell <= 0 ||
        string.IsNullOrEmpty(inputString))
      {
        return string.Empty;
      }

      string[] cells = null;

      // Ensure that the input contains the delimiter and that the cell exists.
      if (inputString.Contains(delimiter))
      {
        cells = inputString.Split(delimiter);

        return cells.Count() >= cell ?
          cells[cell - 1] :
          string.Empty;
      }

      // No delimiter present, only return full string if first cell is requested.
      return cell == 1 ? inputString : string.Empty;
    }
  }
}