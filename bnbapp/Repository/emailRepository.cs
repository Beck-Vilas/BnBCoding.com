//using bnbapp.IRepository;
//using bnbapp.Models;
//using bnbapp.DBContext;

//namespace bnbapp.Repository
//{
//    public class OrderRepository : IOrderRepository
//    {
//        bnbappContext context;

//        public OrderRepository(bnbappContext context)
//        {
//            this.context = context;
//        }

//        public string Delete(int id)
//        {
//            var order = context.Order.FirstOrDefault(x => x.Id == id); //GET User 
//            context.Remove(order); //DELETE 
//            context.SaveChanges();  //COMMIT 
//            return "Deleted";

//        }

//        public Order Get(int id)
//        {
//            //MVC
//            return context.Order.FirstOrDefault(x => x.Id == id);
//        }

//        public List<Order> Gets()
//        {
//            return context.Order.ToList();

//        }

//        public Order Save(Order c)
//        {
//            context.Order.Add(c);
//            context.SaveChanges(); //COMMIT
//            return this.Get(c.Id);
//        }

//        public Order Update(Order c)
//        {
//            context.Order.Update(c);
//            context.SaveChanges(); //COMP
//            return this.Get(c.Id);

//        }
//    }
//}

//copy this but replace all the Order to Email

using bnbapp.IRepository;
using bnbapp.Models;
using bnbapp.DBContext;

namespace bnbapp.Repository
{
    public class EmailRepository : IEmailRepository
    {
        bnbappContext context;
        public EmailRepository(bnbappContext context)
        {
            this.context = context;
        }
        public string Delete(int id)
        {
            var email = context.Email.FirstOrDefault(x => x.Id == id); //GET User 
            context.Remove(email); //DELETE 
            context.SaveChanges();  //COMMIT 
            return "Deleted";
        }
        public Email Get(int id)
        {
            //MVC
            return context.Email.FirstOrDefault(x => x.Id == id);
        }
        public List<Email> Gets()
        {
            return context.Email.ToList();
        }
        public Email Save(Email c)
        {
            context.Email.Add(c);
            context.SaveChanges(); //COMMIT
            return this.Get(c.Id);
        }
        public Email Update(Email c)
        {
            context.Email.Update(c);
            context.SaveChanges(); //COMP
            return this.Get(c.Id);
        }
    }
}
