using System;

namespace ChatLogger.Characters
{
    public class SpecialSingleQuotaLeft : CharacterBase
    {
        public SpecialSingleQuotaLeft()
        {
            BooleanMap = new bool[11][];

            BooleanMap[0] = new bool[] { false, false, true, false, false, false };
            BooleanMap[1] = new bool[] { false, false, false, true, false, false };
            BooleanMap[2] = new bool[6];
            BooleanMap[3] = new bool[6];
            BooleanMap[4] = new bool[6];
            BooleanMap[5] = new bool[6];
            BooleanMap[6] = new bool[6];
            BooleanMap[7] = new bool[6];
            BooleanMap[8] = new bool[6];
            BooleanMap[9] = new bool[6];
            BooleanMap[10] = new bool[6];
        }

        public override char Character { get { return '`'; } }
    }
}