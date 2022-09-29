
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
	}

    class DuplicatedCode
    {
        public void AdmitGuest(string name, string admissionDateTime)
		{
			// Some logic 
			// ...

			var time = GetAdmissionTime(admissionDateTime);

			// Some more logic 
			// ...
			if (time.Hours < 10)
			{

			}
		}

		public void UpdateAdmission(int admissionId, string name, string admissionDateTime)
        {
			// Some logic 
			// ...

			var time = GetAdmissionTime(admissionDateTime);

			// Some more logic 
			// ...
			if (time.Hours < 10)
			{

			}
		}

		private static Time GetAdmissionTime(string admissionDateTime)
		{
			int hours;
			int minutes;
			if (!string.IsNullOrWhiteSpace(admissionDateTime))
			{
				if (int.TryParse(admissionDateTime.Replace(":", ""), out int time))
				{
					hours = time / 100;
					minutes = time % 100;
				}
				else
				{
					throw new ArgumentException("admissionDateTime");
				}

			}
			else
				throw new ArgumentNullException("admissionDateTime");

			return new Time(hours, minutes);
		}
	}
}
