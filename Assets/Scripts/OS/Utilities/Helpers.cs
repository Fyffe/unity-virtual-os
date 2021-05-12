using System;

namespace OS.Utilities
{
	public static class Helpers
	{
		private static readonly Random RANDOM = new Random();
		
		public static long RandomLong()
		{
			byte[] bytes = new byte[8];
			
			RANDOM.NextBytes(bytes);
			
			return BitConverter.ToInt64(bytes, 0);
		}
	}
}
