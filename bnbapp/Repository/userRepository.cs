using bnbapp.IRepository;
using bnbapp.Models;
using bnbapp.DBContext;

namespace bnbapp.Repository
{
    public class UserRepository : IUserRepository
    {
        bnbappContext context;

        public UserRepository(bnbappContext context)
        {
            this.context = context;
        }

        public string Delete(int id)
        {
            var user = context.User.FirstOrDefault(x => x.Id == id); //GET User 
            context.Remove(user); //DELETE 
            context.SaveChanges();  //COMMIT 
            return "Deleted";

        }

        public User Get(int id)
        {
            //MVC
            return context.User.FirstOrDefault(x => x.Id == id);
        }

        public List<User> Gets()
        {
            return context.User.ToList();

        }

        public User Save(User c)
        {
            context.User.Add(c);
            context.SaveChanges(); //COMMIT
            return this.Get(c.Id);
        }

        public User Update(User c)
        {
            context.User.Update(c);
            context.SaveChanges(); //COMP
            return this.Get(c.Id);

        }
    }
}