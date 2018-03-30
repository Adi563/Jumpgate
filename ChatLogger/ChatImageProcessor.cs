namespace ChatLogger
{
    using System.Linq;

    public class ChatImageProcessor
    {
        const int ChatPositionX = 81;
        const int ChatPositionY = 31;
        const int ChatWidth = 354;
        const int ChatHeight = 66;

        const byte MaximumCharactersPerLine = 59;
        const byte LinesPerChat = 6;
        const byte CharacterWidth = 6;
        const byte CharacterHeight = 11;

        private System.Collections.Generic.List<Characters.CharacterBase> characterSet = new System.Collections.Generic.List<Characters.CharacterBase>();

        public ChatImageProcessor()
        {
            characterSet.Add(new Characters.HigherA());
            characterSet.Add(new Characters.HigherB());
            characterSet.Add(new Characters.HigherC());
            characterSet.Add(new Characters.HigherD());
            characterSet.Add(new Characters.HigherE());
            characterSet.Add(new Characters.HigherF());
            characterSet.Add(new Characters.HigherG());
            characterSet.Add(new Characters.HigherH());
            characterSet.Add(new Characters.HigherI());
            characterSet.Add(new Characters.HigherJ());
            characterSet.Add(new Characters.HigherK());
            characterSet.Add(new Characters.HigherL());
            characterSet.Add(new Characters.HigherM());
            characterSet.Add(new Characters.HigherN());
            characterSet.Add(new Characters.HigherO());
            characterSet.Add(new Characters.HigherP());
            characterSet.Add(new Characters.HigherQ());
            characterSet.Add(new Characters.HigherR());
            characterSet.Add(new Characters.HigherS());
            characterSet.Add(new Characters.HigherT());
            characterSet.Add(new Characters.HigherU());
            characterSet.Add(new Characters.HigherV());
            characterSet.Add(new Characters.HigherW());
            characterSet.Add(new Characters.HigherX());
            characterSet.Add(new Characters.HigherY());
            characterSet.Add(new Characters.HigherZ());
            characterSet.Add(new Characters.LowerA());
            characterSet.Add(new Characters.LowerAWithDiaeresis());
            characterSet.Add(new Characters.LowerAWithGrave());
            characterSet.Add(new Characters.LowerB());
            characterSet.Add(new Characters.LowerC());
            characterSet.Add(new Characters.LowerCWithCedille());
            characterSet.Add(new Characters.LowerD());
            characterSet.Add(new Characters.LowerE());
            characterSet.Add(new Characters.LowerEWithAcute());
            characterSet.Add(new Characters.LowerEWithGrave());
            characterSet.Add(new Characters.LowerF());
            characterSet.Add(new Characters.LowerG());
            characterSet.Add(new Characters.LowerH());
            characterSet.Add(new Characters.LowerI());
            characterSet.Add(new Characters.LowerJ());
            characterSet.Add(new Characters.LowerK());
            characterSet.Add(new Characters.LowerL());
            characterSet.Add(new Characters.LowerM());
            characterSet.Add(new Characters.LowerN());
            characterSet.Add(new Characters.LowerO());
            characterSet.Add(new Characters.LowerOWithDiaeresis());
            characterSet.Add(new Characters.LowerP());
            characterSet.Add(new Characters.LowerQ());
            characterSet.Add(new Characters.LowerR());
            characterSet.Add(new Characters.LowerS());
            characterSet.Add(new Characters.LowerT());
            characterSet.Add(new Characters.LowerU());
            characterSet.Add(new Characters.LowerV());
            characterSet.Add(new Characters.LowerW());
            characterSet.Add(new Characters.LowerX());
            characterSet.Add(new Characters.LowerY());
            characterSet.Add(new Characters.LowerZ());
            characterSet.Add(new Characters.NumberZero());
            characterSet.Add(new Characters.NumberOne());
            characterSet.Add(new Characters.NumberTwo());
            characterSet.Add(new Characters.NumberThree());
            characterSet.Add(new Characters.NumberFour());
            characterSet.Add(new Characters.NumberFive());
            characterSet.Add(new Characters.NumberSix());
            characterSet.Add(new Characters.NumberSeven());
            characterSet.Add(new Characters.NumberEight());
            characterSet.Add(new Characters.NumberNine());
            characterSet.Add(new Characters.SpecialSpace());
            characterSet.Add(new Characters.SpecialAt());
            characterSet.Add(new Characters.SpecialColon());
            characterSet.Add(new Characters.SpecialSemiColon());
            characterSet.Add(new Characters.SpecialDot());
            characterSet.Add(new Characters.SpecialComma());
            characterSet.Add(new Characters.SpecialBracketOpen());
            characterSet.Add(new Characters.SpecialBracketClosed());
            characterSet.Add(new Characters.SpecialCurlyBracketOpen());
            characterSet.Add(new Characters.SpecialCurlyBracketClosed());
            characterSet.Add(new Characters.SpecialSquareBracketOpen());
            characterSet.Add(new Characters.SpecialSquareBracketClosed());
            characterSet.Add(new Characters.SpecialAngleBracketOpen());
            characterSet.Add(new Characters.SpecialAngleBracketClosed());
            characterSet.Add(new Characters.SpecialSlash());
            characterSet.Add(new Characters.SpecialBackSlash());
            characterSet.Add(new Characters.SpecialExclamation());
            characterSet.Add(new Characters.SpecialHyphen());
            characterSet.Add(new Characters.SpecialApostrophe());
            characterSet.Add(new Characters.SpecialParagraph());
            characterSet.Add(new Characters.SpecialDegree());
            characterSet.Add(new Characters.SpecialPlus());
            characterSet.Add(new Characters.SpecialMultiply());
            characterSet.Add(new Characters.SpecialQuoteSign());
            characterSet.Add(new Characters.SpecialPercent());
            characterSet.Add(new Characters.SpecialEqual());
            characterSet.Add(new Characters.SpecialQuestionMark());
            characterSet.Add(new Characters.SpecialSingleQuotaLeft());
            characterSet.Add(new Characters.SpecialSingleQuotaRight());
            characterSet.Add(new Characters.SpecialTilde());
            characterSet.Add(new Characters.SpecialNegation());
            characterSet.Add(new Characters.SpecialVerticalBar());
            characterSet.Add(new Characters.SpecialBrokenBar());
            characterSet.Add(new Characters.SpecialCent());
            characterSet.Add(new Characters.SpecialPound());
            characterSet.Add(new Characters.SpecialUnderline());
            characterSet.Add(new Characters.SpecialCircumflex());
            characterSet.Add(new Characters.SpecialDiaeresis());
            characterSet.Add(new Characters.SpecialHashTag());
        }


        /// <summary>
        /// Screens the capture test.
        /// </summary>
        public void ScreenCaptureTest(string logFilePath)
        {
            var bitmapOld = new System.Drawing.Bitmap(ChatWidth, ChatHeight);
            var graphicsOld = System.Drawing.Graphics.FromImage(bitmapOld);
            var bitmapNew = new System.Drawing.Bitmap(ChatWidth, ChatHeight);
            var graphicsNew = System.Drawing.Graphics.FromImage(bitmapNew);

            var stream = new System.IO.FileStream(logFilePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);

            while (true)
            {
                graphicsNew.CopyFromScreen(ChatPositionX, ChatPositionY, 0, 0, new System.Drawing.Size(bitmapNew.Width, bitmapNew.Height), System.Drawing.CopyPixelOperation.SourceCopy);

                if (CompareImages(bitmapOld, bitmapNew))
                {
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }

                graphicsOld.DrawImage(bitmapNew, 0, 0);

                if (!bitmapNew.GetPixel(0, 0).Equals(System.Drawing.Color.FromArgb(255, 10, 10, 10))) { continue; }

                var text = ConvertChatImageToText(bitmapNew);

                var numberOfLinesAdded = GetNumberOfLinesAdded(stream, text);
                
                var subText = text.Substring(text.Length - (numberOfLinesAdded * MaximumCharactersPerLine + numberOfLinesAdded * 2));
                var subTextCharArray = subText.ToCharArray();
                var subTextByteArray = subTextCharArray.Select(b => (byte)b).ToArray();

                stream.Write(subTextByteArray, 0, subTextByteArray.Length);
                stream.Flush();
            }
        }

        public byte GetNumberOfLinesAdded(System.IO.Stream stream, string text)
        {
            if (stream.Length < LinesPerChat * MaximumCharactersPerLine) { return LinesPerChat; }

            var data = new byte[LinesPerChat * MaximumCharactersPerLine + LinesPerChat * 2];
            stream.Position = stream.Length - data.Length;
            stream.Read(data, 0, data.Length);

            var chatText = System.Text.Encoding.ASCII.GetString(data);

            var chatTextElements = chatText.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);

            var textElements = text.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);

            if (chatTextElements[0].Equals(textElements[0]) && chatTextElements[1].Equals(textElements[1]) && chatTextElements[2].Equals(textElements[2]) && chatTextElements[3].Equals(textElements[3]) && chatTextElements[4].Equals(textElements[4]) && chatTextElements[5].Equals(textElements[5])) { return 0; }

            if (chatTextElements[1].Equals(textElements[0]) && chatTextElements[2].Equals(textElements[1]) && chatTextElements[3].Equals(textElements[2]) && chatTextElements[4].Equals(textElements[3]) && chatTextElements[5].Equals(textElements[4])) { return 1; }

            if (chatTextElements[2].Equals(textElements[0]) && chatTextElements[3].Equals(textElements[1]) && chatTextElements[4].Equals(textElements[2]) && chatTextElements[5].Equals(textElements[3])) { return 2; }

            if (chatTextElements[3].Equals(textElements[0]) && chatTextElements[4].Equals(textElements[1]) && chatTextElements[5].Equals(textElements[2])) { return 3; }

            if (chatTextElements[4].Equals(textElements[0]) && chatTextElements[5].Equals(textElements[1])) { return 4; }

            if (chatTextElements[5].Equals(textElements[0])) { return 5; }

            return 6;
        }


        /// <summary>
        /// Gets the chat image from screenshot.
        /// </summary>
        /// <param name="screenshot">The screenshot.</param>
        /// <returns></returns>
        public System.Drawing.Image GetChatImageFromScreenshot(System.Drawing.Image screenshot)
        {
            var chatImage = new System.Drawing.Bitmap(ChatWidth, ChatHeight);
            var chatGraphics = System.Drawing.Graphics.FromImage(chatImage);

            chatGraphics.DrawImage(screenshot, new System.Drawing.Rectangle(0, 0, ChatWidth, ChatHeight), ChatPositionX, ChatPositionY, ChatWidth, ChatHeight, System.Drawing.GraphicsUnit.Pixel);
            return chatImage;
        }


        /// <summary>
        /// Compares the images.
        /// </summary>
        /// <param name="image1">The image1.</param>
        /// <param name="image2">The image2.</param>
        /// <returns></returns>
        private static bool CompareImages(System.Drawing.Bitmap image1, System.Drawing.Bitmap image2)
        {
            for (int x = 0; x < image1.Width; x++)
            {
                for (int y = 0; y < image1.Height; y++)
                {
                    if (image1.GetPixel(x, y) != image2.GetPixel(x, y))
                    { return false; }
                }
            }

            return true;
        }


        /// <summary>
        /// Converts the chat image to text.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns></returns>
        public string ConvertChatImageToText(System.Drawing.Bitmap bitmap)
        {
            var buffer = new char[LinesPerChat * MaximumCharactersPerLine + LinesPerChat * 2];

            var backgroundColor = bitmap.GetPixel(0, 0);

            for (int l = 0; l < LinesPerChat; l++)
            {
                var fontColor = GetFontColor(bitmap, backgroundColor, (l * CharacterHeight + CharacterHeight / 2));

                for (int c = 0; c < MaximumCharactersPerLine; c++)
                {
                    int x = c * CharacterWidth;
                    int y = l * CharacterHeight;
                    buffer[l * MaximumCharactersPerLine + c + l * 2] = GetChatImageCharacter(bitmap, fontColor, x, y);
                }
                
                buffer[(l+1) * MaximumCharactersPerLine + l * 2] = '\r';
                buffer[(l+1) * MaximumCharactersPerLine + l * 2 + 1] = '\n';
            }
            
            return new string(buffer);
        }


        /// <summary>
        /// Gets the color of the font.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="backgroundColor">Color of the background.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Font color not found</exception>
        public System.Drawing.Color GetFontColor(System.Drawing.Bitmap bitmap, System.Drawing.Color backgroundColor, int y)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                var pixelColor = bitmap.GetPixel(x, y);

                if (!pixelColor.Equals(backgroundColor)) { return pixelColor; }
            }

            throw new System.Exception("Font color not found");
        }


        /// <summary>
        /// Gets the chat image character.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="fontColor">Color of the font.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public char GetChatImageCharacter(System.Drawing.Bitmap bitmap, System.Drawing.Color fontColor, int x, int y)
        {
            var colorMap = new System.Drawing.Color[CharacterHeight][];

            for (int h = 0; h < CharacterHeight; h++)
            {
                colorMap[h] = new System.Drawing.Color[CharacterWidth];

                for (int w = 0; w < CharacterWidth; w++)
                {
                    colorMap[h][w] = bitmap.GetPixel(x + w, y + h);
                }
            }

            return GetCharacterByColorMap(colorMap, fontColor);
        }


        /// <summary>
        /// Gets the character by color map.
        /// </summary>
        /// <param name="colorMap">The color map.</param>
        /// <param name="fontColor">Color of the font.</param>
        /// <returns></returns>
        public char GetCharacterByColorMap(System.Drawing.Color[][] colorMap, System.Drawing.Color fontColor)
        {
            var character = characterSet.AsParallel().FirstOrDefault(c => c.Match(colorMap, fontColor));

            if (character == null) { throw new System.NotImplementedException("Character not implemented"); }

            return character.Character;
        }
    }
}