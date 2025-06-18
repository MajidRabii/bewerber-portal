// Implementation: BewerberRepository.cs
using AutoMapper;
using BewerbungAPP.Data;
using BewerbungAPP.Models;
using BewerbungAPP.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BewerbungAPP.Repositories
{
    public class BewerberRepository : IBewerberRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BewerberRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BewerberProfilViewModel>> GetAllAsync()
        {
            var profiles = await _context.Profile
                .Include(p => p.Person)
                .Include(p => p.Beruf1)
                .Include(p => p.Beruf2)
                .Include(p => p.Studiengang)
                .Include(p => p.Studienort)
                .Include(p => p.Abschlussart)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BewerberProfilViewModel>>(profiles);
        }

        public async Task<BewerberProfilViewModel?> GetByIdAsync(int id)
        {
            var profil = await _context.Profile
                .Include(p => p.Person)
                .Include(p => p.Beruf1)
                .Include(p => p.Beruf2)
                .Include(p => p.Studiengang)
                .Include(p => p.Studienort)
                .Include(p => p.Abschlussart)
                .FirstOrDefaultAsync(p => p.Id == id);

            return profil == null ? null : _mapper.Map<BewerberProfilViewModel>(profil);
        }

        public async Task<BewerberProfilViewModel> CreateAsync(BewerberProfilViewModel viewModel)
        {
            var person = _mapper.Map<Person>(viewModel);
            _context.Personen.Add(person);
            await _context.SaveChangesAsync();

            var profil = _mapper.Map<Profil>(viewModel);
            profil.Person_Id = person.Id;
            _context.Profile.Add(profil);
            await _context.SaveChangesAsync();

            return _mapper.Map<BewerberProfilViewModel>(profil);
        }

        public async Task<bool> UpdateAsync(int id, BewerberProfilViewModel viewModel)
        {
            var profil = await _context.Profile.Include(p => p.Person).FirstOrDefaultAsync(p => p.Id == id);
            if (profil == null) return false;

            _mapper.Map(viewModel, profil.Person);
            _mapper.Map(viewModel, profil);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var profil = await _context.Profile.Include(p => p.Person).FirstOrDefaultAsync(p => p.Id == id);
            if (profil == null) return false;

            _context.Profile.Remove(profil);
            _context.Personen.Remove(profil.Person!);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
