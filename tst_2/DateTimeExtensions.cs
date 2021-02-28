namespace tst_2
{
	public static class Extensions
	{
		public static DateTime TrimMs(this DateTime dateTime)
		{
			// if (timeSpan == TimeSpan.Zero) return dateTime; // Or could throw an ArgumentException
			// if (dateTime == DateTime.MinValue || dateTime == DateTime.MaxValue) return dateTime; // do not modify "guard" values
			return dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.FromSeconds(1).Ticks));

			// dateTime = dateTime.Truncate(TimeSpan.FromMilliseconds(1)); // Truncate to whole ms
			// dateTime = dateTime.Truncate(TimeSpan.FromSeconds(1)); // Truncate to whole second
			// dateTime = dateTime.Truncate(TimeSpan.FromMinutes(1)); // Truncate to whole minute
		}

		public static DateTime TrimSec(this DateTime dateTime)
		{
			// if (timeSpan == TimeSpan.Zero) return dateTime; // Or could throw an ArgumentException
			// if (dateTime == DateTime.MinValue || dateTime == DateTime.MaxValue) return dateTime; // do not modify "guard" values
			return dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.FromMinutes(1).Ticks));

			// dateTime = dateTime.Truncate(TimeSpan.FromMilliseconds(1)); // Truncate to whole ms
			// dateTime = dateTime.Truncate(TimeSpan.FromSeconds(1)); // Truncate to whole second
			// dateTime = dateTime.Truncate(TimeSpan.FromMinutes(1)); // Truncate to whole minute
		}
	}
}