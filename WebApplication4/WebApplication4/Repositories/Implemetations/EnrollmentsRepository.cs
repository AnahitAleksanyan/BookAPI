using WebApplication4.DTOs;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;

namespace WebApplication4.Repositories.Implemetations
{
    public class EnrollmentsRepository : IEnrollmentsRepository
    {
        private readonly SQLDBContext _dbContext;

        public EnrollmentsRepository(SQLDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Enrollment> CreateEnrollment(EnrollmentCreateDTO enrollmentDTO)
        {
            Enrollment enrollment = enrollmentDTO.ToEnrollment();

            _dbContext.Enrollment.Add(enrollment);

            await _dbContext.SaveChangesAsync();

            return enrollment;
        }
    }
}
