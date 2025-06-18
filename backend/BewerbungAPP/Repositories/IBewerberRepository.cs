// Interface: IBewerberRepository.cs
using BewerbungAPP.ViewModels;

namespace BewerbungAPP.Repositories
{
    public interface IBewerberRepository
    {
        Task<IEnumerable<BewerberProfilViewModel>> GetAllAsync();
        Task<BewerberProfilViewModel?> GetByIdAsync(int id);
        Task<BewerberProfilViewModel> CreateAsync(BewerberProfilViewModel viewModel);
        Task<bool> UpdateAsync(int id, BewerberProfilViewModel viewModel);
        Task<bool> DeleteAsync(int id);
    }
}
