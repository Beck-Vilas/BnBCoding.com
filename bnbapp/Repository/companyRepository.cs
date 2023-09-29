using bnbapp.IRepository;
using bnbapp.Models;
using bnbapp.DBContext;

namespace bnbapp.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        bnbappContext context;

        public CompanyRepository(bnbappContext context)
        {
            this.context = context;
        }

        public string Delete(int id)
        {
            var company = context.Company.FirstOrDefault(x => x.Id == id); //GET COMPANY 
            context.Remove(company); //DELETE 
            context.SaveChanges();  //COMMIT 
            return "Deleted";

        }

        public Company Get(int id)
        {
            //MVC
            return context.Company.FirstOrDefault(x => x.Id == id);
        }

        public List<Company> Gets()
        {
            return context.Company.ToList();

        }

        public Company Save(Company c)
        {
            context.Company.Add(c);
            context.SaveChanges(); //COMMIT

            return this.Get(c.Id);
        }

        public Company Update(Company c)
        {
            context.Company.Update(c);
            context.SaveChanges(); //COMMIT
            return this.Get(c.Id);

        }
    }
}