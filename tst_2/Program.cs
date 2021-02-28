namespace tst_2
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Hellowzzzzz");
			DateTime dt = DateTime.UtcNow;
			Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
			//dt = new DateTime(dt.Ticks - (dt.Ticks % TimeSpan.TicksPerSecond));
			Console.WriteLine((uint)dt.TrimMs().Subtract(dt.AddSeconds(-19)).TotalSeconds);
			Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
			Console.WriteLine();
			// long ln = (-dt.Ticks % TimeSpan.FromSeconds(1).Ticks);
			// DateTime addTicks = dt.AddTicks(ln);
			// Console.WriteLine(addTicks.ToString("yyyy-MM-dd HH:mm:ss.fff"));
		}
	}
}