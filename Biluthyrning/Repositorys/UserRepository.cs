using Biluthyrning.Data;
using Biluthyrning.Interface;
using Microsoft.EntityFrameworkCore;

namespace Biluthyrning.Repositorys
{
    public class UserRepository : IUserRepository
    {
		private readonly IDbContextFactory<RentalDbContext> dbContextFactory;

		public UserRepository(IDbContextFactory<RentalDbContext> dbContextFactory)
        {
			this.dbContextFactory = dbContextFactory;
		}
        public async Task<int> CreateUser(User user)
        {
			using (RentalDbContext ctx = dbContextFactory.CreateDbContext())
            {
				ctx.User.Add(user);
				await ctx.SaveChangesAsync();
				return user.UserId;
			}
        }

        public async Task DeleteUser(User user)
        {
            using (RentalDbContext ctx = dbContextFactory.CreateDbContext())
            {
				ctx.User.Remove(user);
				await ctx.SaveChangesAsync();
			}
        }

        public async Task<List<User>> GetAllUsers()
        {
            using (RentalDbContext ctx = dbContextFactory.CreateDbContext())
            {
				return await ctx.User.OrderBy(s => s.UserId).ToListAsync();
			}	
        }

        public async Task<User> GetById(int userId)
        {
            using (RentalDbContext ctx = dbContextFactory.CreateDbContext())
            {
                return await ctx.User.FirstOrDefaultAsync(i => i.UserId == userId);
            }
        }

        public async Task UpdateUser(User user)
        {
            using (RentalDbContext ctx = dbContextFactory.CreateDbContext())
            {
                ctx.User.Update(user);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
