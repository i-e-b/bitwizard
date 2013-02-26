namespace BitWizard
{
	public static class BitCounter
	{
		public static int Count(int src)
		{
			src = src - ((src >> 1) & 0x55555555);
			src = (src & 0x33333333) + ((src >> 2) & 0x33333333);
			return ((src + (src >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
		}
		public static int Count(ulong src)
		{
			const ulong a = (ulong.MaxValue / 3);
			const ulong b = ((ulong.MaxValue / 15) * 3);
			const ulong c = ((ulong.MaxValue / 255) * 15);
			const ulong d = (ulong.MaxValue / 255);

			src = src - ((src >> 1) & a);
			src = (src & b) + ((src >> 2) & b);
			src = (src + (src >> 4)) & c;
			return (int)(src * (d)) >> (sizeof(ulong) - 1) * 8;
		}
	}
}