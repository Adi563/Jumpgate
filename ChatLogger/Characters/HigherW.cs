using System;

namespace ChatLogger.Characters
{
    public class HigherW : CharacterBase
    {
        public HigherW()
        {
            BooleanMap = new bool[11][];

            BooleanMap[0] = new bool[6];
            BooleanMap[1] = new bool[6];
            BooleanMap[2] = new bool[] { false, true, false, false, false, true };
            BooleanMap[3] = new bool[] { false, true, false, false, false, true };
            BooleanMap[4] = new bool[] { false, true, false, true, false, true };
            BooleanMap[5] = new bool[] { false, true, false, true, false, true };
            BooleanMap[6] = new bool[] { false, true, false, true, false, true };
            BooleanMap[7] = new bool[] { false, false, true, false, true, false };
            BooleanMap[8] = new bool[6];
            BooleanMap[9] = new bool[6];
            BooleanMap[10] = new bool[6];
        }

        public override char Character { get { return 'W'; } }
    }
}