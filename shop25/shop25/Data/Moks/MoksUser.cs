using Microsoft.AspNetCore.Http.HttpResults;
using shop25.Data.Contex;

namespace shop25.Data.Moks
{
    public class MoksUser : IUser
    {
        private readonly UserContex _dbContext;
        public MoksUser(UserContex dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<User> Users => throw new NotImplementedException();
    }
}
