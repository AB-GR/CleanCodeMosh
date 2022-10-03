using System;

namespace CleanCode.DuplicatedCode
{
	class Time
	{
		public Time(int hours, int minutes)
		{
			Hours = hours;
			Minutes = minutes;
		}

		public int Hours { get; }
		public int Minutes { get; }

		public static Time Parse(string str)
		{
			int hours;
			int minutes;
			if (!string.IsNullOrWhiteSpace(str))
			{
				if (int.TryParse(str.Replace(":", ""), out int time))
				{
					hours = time / 100;
					minutes = time % 100;
				}
				else
				{
					throw new ArgumentException("str");
				}

			}
			else
				throw new ArgumentNullException("str");

			return new Time(hours, minutes);
		}
	}
}