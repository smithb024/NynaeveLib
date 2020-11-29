namespace NynaeveLib.Types
{
    using System;
    using System.Linq;
    using NynaeveLib.ViewModel;

    public class DateType : ViewModelBase
    {
        /// <summary>
        /// Separator character used if none is defined.
        /// </summary>
        private const char DefaultSeparator = '-';

        /// <summary>
        /// Day field.
        /// </summary>
        private int day;

        /// <summary>
        /// Month field.
        /// </summary>
        private int month;

        /// <summary>
        /// Year field.
        /// </summary>
        private int year;

        /// <summary>
        /// Separator between the fields in the input or output string.
        /// </summary>
        private char separator;

        /// <summary>
        ///   Creates a new instance of the DateType class
        /// </summary>
        public DateType()
          : this(1, 1, 1970)
        {
        }

        /// <summary>
        ///   Creates a new instance of the DateType class
        /// </summary>
        /// <param name="day">day value</param>
        /// <param name="month">month value</param>
        /// <param name="year">year value</param>
        public DateType(
            int day,
            int month,
            int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            this.separator = DefaultSeparator;
        }

        /// <summary>
        ///   Creates a new instance of the DateType class
        /// </summary>
        /// <param name="date">date of the new object in standard english format</param>
        /// <param name="separator">character used to separate the day, month and year</param>
        public DateType(
            string date,
            char separator = DefaultSeparator)
        {
            this.separator = separator;
            string[] dateArray = date.Split(this.separator);
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
                            Day = day;
                            Month = month;
                            Year = year;
                        }
                    }
                }
            }

            this.day = day;
            this.month = month;
            this.year = year;
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
        /// Gets the character used to separate the date fields.
        /// </summary>
        public char Separator => this.separator;

        /// <summary>
        /// Return string of format "mm:ss"
        /// </summary>
        /// <returns>new string</returns>
        public override string ToString()
        {
            return Day.ToString() +
                   this.separator +
                   Month.ToString() +
                   this.separator +
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
            if ((Object)time == null)
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