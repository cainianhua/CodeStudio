using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStudio
{
	public class RandomEx
	{
		private int _internalSeed;

		public RandomEx() {
			_internalSeed = this.RandomSeedInternal();
		}

		public RandomEx(int seed) {
			_internalSeed = seed;
		}

		public int Next() {
			return new Random( _internalSeed ).Next();
		}

		public int Next(int maxValue) {
			return new Random( _internalSeed ).Next(maxValue);
		}

		public int Next( int minValue, int maxValue ) {
			return new Random( _internalSeed ).Next( minValue, maxValue );
		}

		public double NextDouble() {
			return new Random( _internalSeed ).NextDouble();
		}

		public void NextBytes( byte[] buffer ) {
			new Random( _internalSeed ).NextBytes( buffer );
		}

		/// <summary>
		/// 生成随机数的种子(Seed)
		/// </summary>
		/// <returns></returns>
		private int RandomSeedInternal() {
			byte[] bytes = new byte[4];
			System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
			rng.GetBytes( bytes );
			return BitConverter.ToInt32( bytes, 0 );
		}
	}
}
