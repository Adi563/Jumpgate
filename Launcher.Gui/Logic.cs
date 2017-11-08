namespace Launcher.Gui
{
    public class Logic
    {
        public static void WriteUserFile(System.IO.Stream stream, string userName, string password)
        {
            var buffer = new byte[21];

            var bufferUserName = System.Text.Encoding.ASCII.GetBytes(userName);
            var bufferPassword = System.Text.Encoding.ASCII.GetBytes(password);

            System.Array.Copy(bufferUserName, 0, buffer, 0, System.Math.Min(bufferUserName.Length, 7));
            System.Array.Copy(new byte[] { 0x30, 0x31 }, 0, buffer, 7, 2);
            System.Array.Copy(bufferPassword, 0, buffer, 11, System.Math.Min(bufferPassword.Length, 9));

            stream.Write(buffer, 0, buffer.Length);
        }

        public static void WriteUserChatFile(System.IO.Stream stream, string chatRoom)
        {
            var buffer = new byte[5];
            
            var bufferChatRoom = System.Text.Encoding.ASCII.GetBytes(chatRoom);

            System.Array.Copy(bufferChatRoom, 0, buffer, 0, System.Math.Min(bufferChatRoom.Length, buffer.Length));

            stream.Write(buffer, 0, buffer.Length);
        }
    }
}