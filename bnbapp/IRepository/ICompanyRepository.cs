using bnbapp.Models;

namespace bnbapp.IRepository
{
    public interface ICompanyRepository
    {
        public Company Save(Company c);
        public Company Update(Company c);
        public Company Get(int id);
        public List<Company> Gets();
        public string Delete(int id);

    }
}