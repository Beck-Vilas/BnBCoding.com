using bnbapp.IRepository;
using bnbapp.Models;
using bnbapp.DBContext;

namespace bnbapp.Repository
{
    public class AlibabaRepository : IAlibabaRepository
    {
        bnbappContext context;

        public AlibabaRepository(bnbappContext context)
        {
            this.context = context;
        }

        public string Delete(int id)
        {
            var alibaba = context.Alibaba.FirstOrDefault(x => x.Id == id); //GET COMPANY 
            context.Remove(alibaba); //DELETE 
            context.SaveChanges();  //COMMIT 
            return "Deleted";

        }

        public Alibaba Get(int id)
        {
            //MVC
            return context.Alibaba.FirstOrDefault(x => x.Id == id);
        }

        public List<Alibaba> Gets()
        {
            return context.Alibaba.ToList();

        }

        public Alibaba Save(Alibaba c)
        {
            context.Alibaba.Add(c);
            context.SaveChanges(); //COMMIT

            return this.Get(c.Id);
        }

        public Alibaba Update(Alibaba c)
        {
            context.Alibaba.Update(c);
            context.SaveChanges(); //COMMIT
            return this.Get(c.Id);

        }
    }
}