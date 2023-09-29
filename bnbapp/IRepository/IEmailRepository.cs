using bnbapp.Models;
namespace bnbapp.IRepository
{
    public interface IEmailRepository
    {
        //public Company Save(Company c);
        //public Company Update(Company c);
        //public Company Get(int id);
        //public List<Company> Gets();
        //public string Delete(int id);
        //change all the Company to Email
        public Email Save(Email c);
        public Email Update(Email c);
        public Email Get(int id);
        public List<Email> Gets();
        public string Delete(int id);


    }
}
