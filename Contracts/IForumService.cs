using Forum_App.Models;

namespace Forum_App.Contracts
{
    public interface IForumService
    {
        Task<IEnumerable<PostViewModel>> GetAllAsync();

        Task<PostFormModel> GetByIdAsync(int id);

        Task AddPostAsync(PostFormModel model);

        Task DeletePostAsync(int id);
        Task UpdatePostAsync(PostFormModel model);
    }
}
