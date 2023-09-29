using bnbapp.Models;

namespace bnbapp.IRepository
{
    public interface ISentEmailRepository
    {
        //public User Save(User c);
        //public User Update(User c);
        //public User Get(int id);
        //public List<User> Gets();
        //public string Delete(int id);
        //change all the User to SentEmail
        public SentEmail Save(SentEmail c);
        public SentEmail Update(SentEmail c);
        public SentEmail Get(int id);
        public List<SentEmail> Gets();
        public string Delete(int id);
    }
}
