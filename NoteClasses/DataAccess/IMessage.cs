using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteClasses.DataAccess
{
    public interface IMessage
    {
        MessageModel DeleteMessage(MessageModel message);
    }
}
