using System;

namespace Math
{
	class MyRandom
	{
		private static readonly Random random = new Random();
		private static readonly object syncLock = new object();
		public static int Next(int min, int max)
		{
			lock (syncLock)
			{ // synchronize
				return random.Next(min, max);
			}
		}
	}
}
