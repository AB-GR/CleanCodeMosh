
using System;

namespace CleanCode.DuplicatedCode
{
    class DuplicatedCode
    {
        public void AdmitGuest(string name, string admissionDateTime)
		{
			// Some logic 
			// ...

			var time = Time.Parse(admissionDateTime);

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

			var time = Time.Parse(admissionDateTime);

			// Some more logic 
			// ...
			if (time.Hours < 10)
			{

			}
		}
	}

	internal class Time
	{
		public int Hours { get; set; }

		internal static Time Parse(string admissionDateTime)
		{
			throw new NotImplementedException();
		}
	}
}
