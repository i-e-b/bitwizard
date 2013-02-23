using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitWizard
{
	public class ArrayByteOrder
	{
		/// <summary>
		/// Swap endian order for elements in an array
		/// </summary>
		public static unsafe void SwapOrder(short[] data)
		{
			var remaining = data.Length;
			fixed (short* d = data)
			{
				var p = (byte*)d;
				while (remaining-- > 0)
				{
					byte a = *p;
					p++;
					byte b = *p;
					*(p - 1) = a;
					*(p - 2) = b;
				}
			}
		}
		
		/// <summary>
		/// Swap endian order for elements in an array
		/// </summary>
		public static unsafe void SwapOrder(int[] data)
		{
			var remaining = data.Length;
			fixed (int* d = data)
			{
				var p = (byte*)d;
				while (remaining-- > 0)
				{
					byte a = *p;
					p++;
					byte b = *p;
					*p = *(p + 1);
					p++;
					*p = b;
					p++;
					*(p - 3) = *p;
					*p = a;
					p++;
				}
			}
		}
	}
}
