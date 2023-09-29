using bnbapp.Models;
namespace bnbapp.IRepository
{
    public interface IAlibabaRepository
    {
        
            //public Company Save(Company c);
            //public Company Update(Company c);
            //public Company Get(int id);
            //public List<Company> Gets();
            //public string Delete(int id);
            //change all the Company to Email
        public Alibaba Save(Alibaba c);
        public Alibaba Update(Alibaba c);
        public Alibaba Get(int id);
        public List<Alibaba> Gets();
        public string Delete(int id);


        
    }
}
