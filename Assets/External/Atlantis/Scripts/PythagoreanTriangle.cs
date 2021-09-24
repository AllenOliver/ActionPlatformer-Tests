namespace Atlantis
{
    /// <summary>
    /// Data struct for holding data related to a Pythagorean Triangle.
    /// Remember, Number is all. O
    /// </summary>
    public struct PythagoreanTriangle
    {
        /// <summary>
        /// The golden ratio for calculation.
        /// </summary>
        public const float PHI = 1.618f;

        public int SideA;
        public int SideB;
        public int SideC;

        /// <summary>
        /// Checks for the triangle to conform to the Golden Ratio, or <see cref="PHI"/>
        /// </summary>
        /// <returns></returns>
        public bool IsGolden()
        {
            if (SideA / SideB == PHI) return true;
            else return false;
        }
    }
}