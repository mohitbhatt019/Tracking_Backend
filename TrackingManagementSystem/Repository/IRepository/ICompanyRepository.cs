using TrackingManagementSystem.Models;

namespace TrackingManagementSystem.Repository.IRepository
{
    public interface ICompanyRepository
    {
        Task<bool> AddCompany(Company company);
        ICollection<Company> GetAllCompanies(string id);
        Company GetById(int id);
        Company GetByName(string name);
        bool DeleteById(int id);
        bool UpdateCompany(Company company);
    }
}
