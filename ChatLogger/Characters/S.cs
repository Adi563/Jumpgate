namespace ChatLogger.Characters
{
    public class S
    {
        static S()
        {
            BooleanMap = new bool[11][];

            BooleanMap[0] = new bool[6];
            BooleanMap[1] = new bool[6];
            BooleanMap[2] = new bool[] { false, true, true, true, false, false };
            BooleanMap[3] = new bool[] { false, true, false, false, true, false };
            BooleanMap[4] = new bool[] { false, false, true, false, false, false };
            BooleanMap[5] = new bool[] { false, false, false, true, false, false };
            BooleanMap[6] = new bool[] { false, true, false, false, true, false };
            BooleanMap[7] = new bool[] { false, false, true, true, true, false };
            BooleanMap[8] = new bool[6];
            BooleanMap[9] = new bool[6];
            BooleanMap[10] = new bool[6];
        }

        public static bool[][] BooleanMap { get; private set; }

        public static bool Match(System.Drawing.Color[][] colorMap, System.Drawing.Color fontColor)
        {
            for (int h = 0; h < BooleanMap.Length; h++)
            {
                for (int w = 0; w < BooleanMap[h].Length; w++)
                {
                    if (BooleanMap[h][w] && !colorMap[h][w].Equals(fontColor)) { return false; }
                }
            }

            return true;
        }
    }
}