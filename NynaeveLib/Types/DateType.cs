namespace NynaeveLib.Types
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using NynaeveLib.ViewModel;

  public class DateType : ViewModelBase
  {
    private int  day;
    private int  month;
    private int  year;
    private char separator = '-';

    /// <summary>
    ///   Creates a new instance of the DateType class
    /// </summary>
    public DateType()
      :this (1, 1, 1970)
    {
    }

    /// <summary>
    ///   Creates a new instance of the DateType class
    /// </summary>
    /// <param name="day">day value</param>
    /// <param name="month">month value</param>
    /// <param name="year">year value</param>
    public DateType(int day,
                    int month,
                    int year)
    {
      this.day   = day;
      this.month = month;
      this.year  = year;
    }

    /// <summary>
    ///   Creates a new instance of the DateType class
    /// </summary>
    /// <param name="day">day value</param>
    /// <param name="month">month value</param>
    /// <param name="year">year value</param>
    public DateType(string date)
    {
      string[] dateArray = date.Split(separator);
      int day = 0;
      int month = 0;
      int year = 0;

      if (dateArray.Count() == 3)
      {
       if (int.TryParse(dateArray[0], out day))
       {
         if (int.TryParse(dateArray[1], out month))
         {
           if (int.TryParse(dateArray[2], out year))
           {
             Day   = day;
             Month = month;
             Year  = year;
           }
         }
       }
      }

      this.day   = day;
      this.month = month;
      this.year  = year;
    }

    /// <summary>
    /// Gets and sets the day
    /// </summary>
    public int Day
    {
      get
      {
        return day;
      }

      set
      {
        day = value;
        RaisePropertyChangedEvent("Day");
      }
    }

    /// <summary>
    /// Gets and sets the year
    /// </summary>
    public int Month
    {
      get
      {
        return month;
      }

      set
      {
        month = value;
        RaisePropertyChangedEvent("Month");
      }
    }

    /// <summary>
    /// Gets and sets the year
    /// </summary>
    public int Year
    {
      get
      {
        return year;
      }

      set
      {
        year = value;
        RaisePropertyChangedEvent("Year");
      }
    }

    /// <summary>
    /// Return string of format "mm:ss"
    /// </summary>
    /// <returns>new string</returns>
    public override string ToString()
    {
      return Day.ToString() + 
             separator +
             Month.ToString() +
             separator +
             Year.ToString();
    }

    /// <summary>
    /// Equals operator.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
      if (obj == null)
      {
        return false;
      }

      // Ensure that the obj can be cast to time type.
      DateType time = obj as DateType;
      if ((System.Object)time == null)
      {
        return false;
      }

      return (time.Year == Year && time.Month == Month && time.Day == Day);
    }

    /// <summary>
    /// Equality operator
    /// </summary>
    /// <param name="lhs">left hand side</param>
    /// <param name="rhs">right hand side</param>
    /// <returns>returns a flag indicating if the two sides are equal</returns>
    public static bool operator ==(DateType lhs, DateType rhs)
    {
      if (object.ReferenceEquals(lhs, null))
      {
        return object.ReferenceEquals(rhs, null);
      }

      if (object.ReferenceEquals(rhs, null))
      {
        return false;
      }

      return (lhs.Year == rhs.Year && lhs.Month == rhs.Month && lhs.Day == rhs.Day);
    }

    /// <summary>
    /// Equality operator
    /// </summary>
    /// <param name="lhs">left hand side</param>
    /// <param name="rhs">right hand side</param>
    /// <returns>returns a flag indicating if the two sides are not equal</returns>
    public static bool operator !=(DateType lhs, DateType rhs)
    {
      if (object.ReferenceEquals(lhs, null))
      {
        return !object.ReferenceEquals(rhs, null);
      }

      if (object.ReferenceEquals(rhs, null))
      {
        return true;
      }

      return (lhs.Year != rhs.Year && lhs.Month != rhs.Month && lhs.Day != rhs.Day);
    }

    /// <summary>
    /// Overrides the get hash code method
    /// </summary>
    /// <returns>hash code</returns>
    public override int GetHashCode()
    {
      return Year ^ Month ^ Day;
    }
  }
}
