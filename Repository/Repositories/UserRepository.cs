using Domain.Entities;
using Repository.Base;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PokerPageContext context) : base(context)
        {
        }
    }
}
