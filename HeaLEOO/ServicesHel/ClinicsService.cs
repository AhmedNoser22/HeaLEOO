using HeaLEOO.Data;
using HeaLEOO.Models;
using Microsoft.EntityFrameworkCore;

namespace HeaLEOO.Services
{
    public class ClinicsService : IClinicsService
    {
        private readonly AppDbContext _context;
        public ClinicsService(AppDbContext context) => _context = context;

        public async Task<List<Clinics>> GetAllAsync() =>
            await _context.Clinics
                .Include(c => c.ClinicDoctors)
                .Include(c => c.Appointments)
                .ToListAsync();

        public async Task<Clinics?> GetByIdAsync(int id) =>
            await _context.Clinics
                .Include(c => c.ClinicDoctors)
                .Include(c => c.Appointments)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Clinics> CreateAsync(Clinics clinic)
        {
            _context.Clinics.Add(clinic);
            await _context.SaveChangesAsync();
            return clinic;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var clinic = await _context.Clinics.FindAsync(id);
            if (clinic == null) return false;

            _context.Clinics.Remove(clinic);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
