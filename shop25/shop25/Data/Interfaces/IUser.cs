
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop25
{
   public interface IUser
    { 
        Task<User> Users { get;}
    }
}