using System;

namespace CodingKatas
{
    public class VolumeCalculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="heightOfLiquid"></param>
        /// <param name="diameter"></param>
        /// <param name="volumeTotal"></param>
        /// <returns></returns>
        public static int CalculateVolume(int heightOfLiquid, int diameter, int volumeTotal)
        {
            var radius = (double)diameter / 2;
            var radiusSquared = Math.Pow(radius, 2);
            var length = volumeTotal / (Math.PI * radiusSquared);
            var areaOfCircularSegment = GetAreaOfCircularSegment(heightOfLiquid, radius, radiusSquared);
            var volumeOfLiquid = areaOfCircularSegment * length;

            return (int)Math.Floor(volumeOfLiquid);
        }

        /// <summary>
        /// Get area of a circular segment
        /// </summary>
        /// <param name="h">Height</param>
        /// <param name="r">Radius</param>
        /// <param name="r2">Radius squared</param>
        private static double GetAreaOfCircularSegment(int h, double r, double r2)
        {
            var inverseCosignArgument = (r - h) / r;
            var intermediateValue1 = r2 * Math.Acos(inverseCosignArgument);
            var intermediateValue2 = (r - h) * Math.Sqrt(2 * r * h - Math.Pow(h, 2));
            var areaOfCircularSegment = intermediateValue1 - intermediateValue2;
            return areaOfCircularSegment;
        }
    }
}
