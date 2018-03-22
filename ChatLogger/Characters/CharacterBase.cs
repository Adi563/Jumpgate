namespace ChatLogger.Characters
{
    public abstract class CharacterBase
    {
        public bool[][] BooleanMap { get; internal set; }

        public bool Match(System.Drawing.Color[][] colorMap, System.Drawing.Color fontColor)
        {
            for (int h = 0; h < BooleanMap.Length; h++)
            {
                for (int w = 0; w < BooleanMap[h].Length; w++)
                {
                    if ((!BooleanMap[h][w] && colorMap[h][w].Equals(fontColor)) || (BooleanMap[h][w] && !colorMap[h][w].Equals(fontColor))) { return false; }
                }
            }

            return true;
        }

        public abstract char Character { get; }
    }
}