using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace RandomNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rndSys = new Random();

            int minValue = 1;
            int maxValue = 4;

            Dictionary<int, long> picked = new Dictionary<int, long>();
            for (int ii = minValue; ii <= maxValue; ii++)
                picked.Add(ii, 0);

            for (long i = 0; i < 1000000; i++)
            {
                int ni = NextInt(minValue, maxValue);
                //int ni = rndSys.Next(minValue, maxValue);

                if ((ni < minValue) || (ni > maxValue))
                    throw new Exception($"BAD value: {ni}");

                //    picked[ni - 1]++;
                picked[ni]++;
            //    Console.WriteLine(NextInt(1, 3));
            }

            foreach (var pick in picked)
                Trace.WriteLine($"Number of {pick.Key}: {pick.Value}");

            Console.Read();
        }

        private static RNGCryptoServiceProvider _rnd = new RNGCryptoServiceProvider();

        /// <summary>
        /// Random integer using proper crypto class and mapping correctly across range of integers, with
        /// equal distribution across specified range.
        /// NOTE: System.Random is not cryptographically secure and should not be used for password generation.
        /// <paramref name="min">Minimum value returned (inclusive)</paramref>
        /// <paramref name="max">Maximum value returned (inclusive)</paramref>
        /// </summary>
        private static int NextInt(int min, int max)
        {
            if (min > max)
                throw new ArgumentOutOfRangeException("min", min, "Minimum must be less than or equal to maximum");

            //RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
            byte[] buff = new byte[4];

            _rnd.GetBytes(buff);
            uint randUint = BitConverter.ToUInt32(buff, 0);

            // Algorithm works with range (0..1], i.e. exclude 0
            if (randUint == uint.MinValue)
                randUint++;

            double sample = randUint / (double)uint.MaxValue;
            long range = (long)max - min + 1;
            double scaled = sample * range;
            int ceil = (int)Math.Ceiling(scaled);
            int rndInt = min + ceil - 1;
            
            //Trace.WriteLine($"pct:{sample}, scaled={scaled}, ceil={ceil}, rndInt:{rndInt}");

            return rndInt;
        }
    }
}
