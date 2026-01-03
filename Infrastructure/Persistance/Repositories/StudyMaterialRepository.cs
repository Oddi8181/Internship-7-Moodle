using Application.Courses.AddMaterial;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class StudyMaterialRepository : IStudyMaterialRepository
    {
        private readonly AppDbContext _context;

        public StudyMaterialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StudyMaterial material)
        {
            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();
        }

        
    }
}
