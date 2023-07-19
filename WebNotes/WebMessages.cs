using NoteClasses;

namespace WebNotes
{
    public class WebMessages
    {
        public List<string> MessageDtoToStringList(MessageDto message)
        {
            var output = new List<string>
            {
                $"{message.Title},{message.Text}"
            };

            return output;
        }

        //public MessageModel Message(MessageDto message)
        //{
        //    var m = ToList(message);
        //    List<MessageModel> messages = m.ConvertWebToMessageModel();

        //}
    }
}
