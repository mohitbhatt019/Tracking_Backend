using Microsoft.AspNetCore.Identity;
using TrackingManagementSystem.Data;
using TrackingManagementSystem.Models;
using TrackingManagementSystem.Repository.IRepository;

namespace TrackingManagementSystem.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCompany(Company company)
        {
            if (company == null) throw new ArgumentNullException();
            _context.companies.Add(company);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteById(int id)
        {
            var company = _context.companies.Find(id);
            if (company != null)
            {
                _context.companies.Remove(company);
                _context.SaveChanges();
                return true;
            }
            return false; // or throw an exception, depending on your requirements
        }

        public ICollection<Company> GetAllCompanies(string id)
        {
            var list = _context.companies.Where(ids => ids.ApplicationUserId == id).ToList();
            return list;
        }

        public Company GetById(int id)
        {
            var findComapny= _context.companies.Find(id);
            if (findComapny != null)
                return findComapny;
            return null;
        }

        public Company GetByName(string name)
        {
            var findComapnyByName = _context.companies.FirstOrDefault(a=>a.Name==name);
            if (findComapnyByName != null)
                return findComapnyByName;
            return null;
        }

        public bool UpdateCompany(Company company)
        {
            if (company == null) return false;
            var updateCompany=_context.companies.Update(company);
            _context.SaveChanges();
            return true;
        }
    }
}
