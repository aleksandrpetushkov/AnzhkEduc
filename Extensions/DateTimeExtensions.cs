using System;

namespace Extensions
{
	public static class DateTimeExtensions
	{
		public static DateTime Trim(this DateTime dateTime, TimeSpan timeSpan)
		{
			// if (timeSpan == TimeSpan.Zero) return dateTime; // Or could throw an ArgumentException
			// if (dateTime == DateTime.MinValue || dateTime == DateTime.MaxValue) return dateTime; // do not modify "guard" values
			long lg = -1 * (dateTime.Ticks % timeSpan.Ticks);
			return dateTime.AddTicks(lg);

			// dateTime = dateTime.Truncate(TimeSpan.FromMilliseconds(1)); // Truncate to whole ms
			// dateTime = dateTime.Truncate(TimeSpan.FromSeconds(1)); // Truncate to whole second
			// dateTime = dateTime.Truncate(TimeSpan.FromMinutes(1)); // Truncate to whole minute
		}
	}
}