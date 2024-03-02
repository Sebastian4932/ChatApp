using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChatApp.src.ChatMessageModel;

namespace ChatApp.src
{
    public interface IRepository
    {      
  
    }

    public class Repository : IRepository
    {    
        List<User> users = new List<User>()
        {
                new User(){Name="A", Id=1},
                new User(){Name="B", Id=2},
                new User(){Name="C", Id=3},
               
        };
    }
}
