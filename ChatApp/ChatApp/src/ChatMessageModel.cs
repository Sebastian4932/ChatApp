using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.src
{
    public class ChatMessageModel
    {
        public class User
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }
       
        public class Message
        {
            public User Sender { get; set; }
            public string Content { get; set; }
            public DateTime CreatedOn { get; set; }
            public string FormatedCreatedOn => CreatedOn.ToString("MM.dd,HH:mm:ss");
            public override string ToString()
            {
                return $"{Sender.Name} ({FormatedCreatedOn}): {Content}";
            }
        }
    }
}
