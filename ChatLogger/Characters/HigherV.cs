﻿using System;

namespace ChatLogger.Characters
{
    public class HigherV : CharacterBase
    {
        public HigherV()
        {
            BooleanMap = new bool[11][];

            BooleanMap[0] = new bool[6];
            BooleanMap[1] = new bool[6];
            BooleanMap[2] = new bool[] { false, true, false, false, true, false };
            BooleanMap[3] = new bool[] { false, true, false, false, true, false };
            BooleanMap[4] = new bool[] { false, true, false, false, true, false };
            BooleanMap[5] = new bool[] { false, true, false, false, true, false };
            BooleanMap[6] = new bool[] { false, false, true, true, false, false };
            BooleanMap[7] = new bool[] { false, false, true, true, false, false };
            BooleanMap[8] = new bool[6];
            BooleanMap[9] = new bool[6];
            BooleanMap[10] = new bool[6];
        }

        public override char Character { get { return 'V'; } }
    }
}