﻿namespace NynaeveLib.Types
{
    using System;
    using System.Linq;
    using NynaeveLib.ViewModel;

    public class TimeType : ViewModelBase
    {
        private int minutes = 59;
        private int seconds = 59;
        protected char separator = ':';
        protected char alternativeSeparator = '.';

        /// <summary>
        ///   Creates a new instance of the TimeType class
        /// </summary>
        /// <param name="minutes">minutes</param>
        /// <param name="seconds">seconds</param>
        public TimeType(int minutes,
                        int seconds)
        {
            this.minutes = minutes;
            this.seconds = seconds;
        }

        /// <summary>
        ///   Creates a new instance of the TimeType class
        /// </summary>
        /// <param name="time">time</param>
        public TimeType(string time)
        {
            Update(time);
        }

        /// <summary>
        ///   Creates a new instance of the TimeType class
        /// </summary>
        /// <param name="time">time</param>
        public TimeType() : this(59, 59)
        {
        }

        /// <summary>
        /// Gets the minutes.
        /// </summary>
        public int Minutes
        {
            get => minutes;

            private set
            {
                minutes = value;
                this.OnPropertyChanged(nameof(this.Minutes));
            }
        }

        /// <summary>
        /// Gets the seconds.
        /// </summary>
        public int Seconds
        {
            get => seconds;

            private set
            {
                seconds = value;
                this.OnPropertyChanged(nameof(this.Seconds));
            }
        }

        /// <summary>
        /// Add time, if seconds role over to the next  minute increase 
        /// minute by one and reset seconds.
        /// </summary>
        /// <param name="lhs">time to add (left)</param>
        /// <param name="rhs">time to add (right)</param>
        /// <returns>new time</returns>
        public static TimeType operator +(TimeType lhs,
                                          TimeType rhs)
        {
            int productMinutes = lhs.Minutes + rhs.Minutes;
            int productSeconds = lhs.Seconds + rhs.Seconds;

            if (productSeconds >= 60)
            {
                ++productMinutes;
                productSeconds = productSeconds - 60;
            }

            return new TimeType(productMinutes, productSeconds);
        }

        /// <summary>
        /// Subtract time, if seconds role over to the next minute decrease
        /// minute by one and reset seconds.
        /// </summary>
        /// <param name="lhs">distance to add (left)</param>
        /// <param name="rhs">distance to add (right)</param>
        /// <returns>new distance</returns>
        public static TimeType operator -(TimeType lhs,
                                          TimeType rhs)
        {
            if (rhs.Minutes > lhs.Minutes ||
              (rhs.Minutes == lhs.Minutes && rhs.Seconds > lhs.Seconds))
            {
                // TODO Need to raise an exception.

                return new TimeType(0, 0);
            }
            else
            {
                int productMinutes = lhs.Minutes - rhs.Minutes;
                int productSeconds = lhs.Seconds - rhs.Seconds;

                if (productSeconds < 0)
                {
                    --productMinutes;
                    productSeconds = productSeconds + 60;
                }

                return new TimeType(productMinutes, productSeconds);
            }
        }

        /// <summary>
        /// Overrides the equals operator to check the minutes and seconds match
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            // Ensure that the obj can be cast to time type.
            TimeType time = obj as TimeType;
            if ((System.Object)time == null)
            {
                return false;
            }

            return time.Minutes == Minutes && time.Seconds == Seconds;
        }

        /// <summary>
        /// Overrides the get hash code method
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return Minutes ^ Seconds;
        }

        /// <summary>
        /// equality operator
        /// </summary>
        /// <param name="lhs">left hand side</param>
        /// <param name="rhs">right hand side</param>
        /// <returns>equality flag</returns>
        public static bool operator ==(TimeType lhs,
                                       TimeType rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }

            if (object.ReferenceEquals(rhs, null))
            {
                return false;
            }

            return (lhs.Minutes == rhs.Minutes && lhs.Seconds == rhs.Seconds);
        }

        /// <summary>
        /// inequality operator
        /// </summary>
        /// <param name="lhs">left hand side</param>
        /// <param name="rhs">right hand side</param>
        /// <returns>inequality flag</returns>
        public static bool operator !=(TimeType lhs,
                                       TimeType rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return !object.ReferenceEquals(rhs, null);
            }

            if (object.ReferenceEquals(rhs, null))
            {
                return true;
            }

            return (lhs.Minutes != rhs.Minutes || lhs.Seconds != rhs.Seconds);
        }

        /// <summary>
        /// Greater than operator.
        /// </summary>
        /// <param name="lhs">left hand side</param>
        /// <param name="rhs">right hand side</param>
        /// <returns>
        /// returns flag showing if the left hand side is greater than the right
        /// </returns>
        public static bool operator >(TimeType lhs,
                                      TimeType rhs)
        {
            if (lhs.Minutes > rhs.Minutes)
            {
                return true;
            }
            else if (lhs.Minutes == rhs.Minutes && lhs.Seconds > rhs.Seconds)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Less than operator.
        /// </summary>
        /// <param name="lhs">left hand side</param>
        /// <param name="rhs">right hand side</param>
        /// <returns>
        /// returns flag showing if the left hand side is less than the right
        /// </returns>
        public static bool operator <(TimeType lhs,
                                      TimeType rhs)
        {
            if (lhs.Minutes < rhs.Minutes)
            {
                return true;
            }
            else if (lhs.Minutes == rhs.Minutes && lhs.Seconds < rhs.Seconds)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Subtract time, if seconds role over to the next minute decrease
        /// minute by one and reset seconds.
        /// </summary>
        /// <param name="lhs">distance to add (left)</param>
        /// <param name="rhs">distance to add (right)</param>
        /// <returns>new distance</returns>
        public static TimeType operator /(TimeType lhs,
                                          int rhs)
        {
            int minutesInt = 0;
            int secondsInt = 0;

            double step = lhs.Minutes + (lhs.Seconds / 60.0);
            double dividedTime = step / rhs;

            try
            {
                minutesInt = (int)Math.Truncate(dividedTime);
                double seconds = (dividedTime - Math.Truncate(dividedTime)) * 60;
                secondsInt = (int)Math.Round(seconds, MidpointRounding.AwayFromZero);
            }
            catch (Exception ex)
            {
                // TODO Need to raise an exception.
                string exception = ex.ToString();
                return new TimeType(0, 0);
            }

            return new TimeType(minutesInt, secondsInt);
        }

        /// <summary>
        /// Round the time to the nearest 30 seconds
        /// </summary>
        /// <returns>rounded time</returns>
        public TimeType Round()
        {
            if (Seconds < 15)
            {
                return new TimeType(Minutes, 0);
            }
            else if (Seconds < 45)
            {
                return new TimeType(Minutes, 30);
            }
            else
            {
                return new TimeType(Minutes + 1, 0);
            }
        }

        /// <summary>
        /// Return string of format "mm:ss"
        /// </summary>
        /// <returns>new string</returns>
        public override string ToString()
        {
            return Minutes.ToString() +
                   separator +
                   Seconds.ToString("00");
        }

        /// <summary>
        /// Return string of format "mm-cc"
        /// </summary>
        /// <returns>new string</returns>
        protected void Update(string time)
        {
            string[] cells = null;

            if (time.Contains(separator))
            {
                cells = time.Split(separator);
            }
            else
            {
                cells = time.Split(alternativeSeparator);
            }

            int minutesInt = 0;
            int secondsInt = 0;

            if (cells.Length == 2)
            {
                if (!int.TryParse(cells[0], out minutesInt))
                {
                    // TODO Need to raise an exception.
                }
                else
                {
                    if (!int.TryParse(cells[1], out secondsInt))
                    {
                        // TODO Need to raise an exception.
                    }
                    else
                    {
                        Minutes = minutesInt;
                        Seconds = secondsInt;
                    }
                }
            }
            else
            {
                // TODO Need to raise an exception.
            }
        }
    }
}