using bnbapp.Models;

namespace bnbapp.IRepository
{
    public interface IUserRepository
    {
        public User Save(User c);
        public User Update(User c);
        public User Get(int id);
        public List<User> Gets();
        public string Delete(int id);

    }
}