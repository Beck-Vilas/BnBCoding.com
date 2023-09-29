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

//copy this but replace all the Order to SentEmail

using bnbapp.IRepository;
using bnbapp.Models;
using bnbapp.DBContext;

namespace bnbapp.Repository
{
    public class SentEmailRepository : ISentEmailRepository
    {
        bnbappContext context;
        public SentEmailRepository(bnbappContext context)
        {
            this.context = context;
        }
        public string Delete(int id)
        {
            var sentEmail = context.SentEmail.FirstOrDefault(x => x.Id == id); //GET User 
            context.Remove(sentEmail); //DELETE 
            context.SaveChanges();  //COMMIT 
            return "Deleted";
        }
        public SentEmail Get(int id)
        {
            //MVC
            return context.SentEmail.FirstOrDefault(x => x.Id == id);
        }
        public List<SentEmail> Gets()
        {
            return context.SentEmail.ToList();
        }
        public SentEmail Save(SentEmail c)
        {
            context.SentEmail.Add(c);
            context.SaveChanges(); //COMMIT
            return this.Get(c.Id);
        }
        public SentEmail Update(SentEmail c)
        {
            context.SentEmail.Update(c);
            context.SaveChanges(); //COMP
            return this.Get(c.Id);
        }
    }
}   