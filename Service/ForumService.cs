using Forum_App.Contracts;
using Forum_App.Data;
using Forum_App.Data.Models;
using Forum_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Forum_App.Service
{
    public class ForumService : IForumService
    {
        private readonly ForumAppDbContext _context;
        public ForumService(ForumAppDbContext context)
        {
            _context = context;
        }
        public async  Task AddPostAsync(PostFormModel model)
        {

            if (model == null)
            {
                throw new ArgumentException("Invalid Post");
            }


            _context.Posts.Add(new Post()
            {
                Title = model.Title,
                Content = model.Content,
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var entity = await _context.Posts.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid Post");
            }

            _context.Posts.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(PostFormModel model)
        {

            var entity = await _context.Posts.FindAsync(model.Id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid Product");
            }

            entity.Title = model.Title;
            entity.Content = model.Content;

            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<PostViewModel>> GetAllAsync()
        {
            return await _context
                .Posts
                .AsNoTracking()
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
               .ToListAsync();
        }

        public async Task<PostFormModel> GetByIdAsync(int id)
        {
            var entity = await _context.Posts.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid Product");
            }

            return new PostFormModel
            {
                Id = id,
                Title = entity.Title,
                Content = entity.Content,
            };
        }
    }
}
