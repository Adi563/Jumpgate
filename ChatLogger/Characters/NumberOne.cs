using System;

namespace ChatLogger.Characters
{
    public class NumberOne : CharacterBase
    {
        public NumberOne()
        {
            BooleanMap = new bool[11][];

            BooleanMap[0] = new bool[6];
            BooleanMap[1] = new bool[6];
            BooleanMap[2] = new bool[] { false, true, true, true, false, false };
            BooleanMap[3] = new bool[] { false, false, false, true, false, false };
            BooleanMap[4] = new bool[] { false, false, false, true, false, false };
            BooleanMap[5] = new bool[] { false, false, false, true, false, true };
            BooleanMap[6] = new bool[] { false, false, false, true, false, true };
            BooleanMap[7] = new bool[] { false, true, true, true, true, true };
            BooleanMap[8] = new bool[6];
            BooleanMap[9] = new bool[6];
            BooleanMap[10] = new bool[6];
        }

        public override char Character { get { return '1'; } }
    }
}