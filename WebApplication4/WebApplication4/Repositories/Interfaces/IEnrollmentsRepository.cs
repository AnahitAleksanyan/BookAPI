using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Repositories.Interfaces
{
    public interface IEnrollmentsRepository
    {
        Task<Enrollment> CreateEnrollment(EnrollmentCreateDTO enrollment);
    }
}
