using ConventionsHandicap.Model;
using System.Threading.Tasks;

namespace ConventionsHandicap.App.Contracts
{
    public interface IConventionsHandicapReferentialService
    {
        Task<Academy[]> GetAcademiesAsync();
        Task<Academy> GetAcademyAsync(string academyName);
    }
}