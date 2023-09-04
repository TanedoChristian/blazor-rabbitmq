using BlazorApp.Data;
using BlazorApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

      

        public  async Task Delete(User entity)
        {
             _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task Update(User entity)
        {
            _context.Update(entity);
           await  _context.SaveChangesAsync();

            
        }
    }
}
