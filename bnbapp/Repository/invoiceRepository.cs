using bnbapp.IRepository;
using bnbapp.Models;
using bnbapp.DBContext;

namespace bnbapp.Repository
{
    public class invoiceRepository : IInvoiceRepository
    {
        bnbappContext context;

        public invoiceRepository(bnbappContext context)
        {
            this.context = context;
        }

        public string Delete(int id)
        {
            var invoice = context.Invoice.FirstOrDefault(x => x.Id == id); //GET User 
            context.Remove(invoice); //DELETE 
            context.SaveChanges();  //COMMIT 
            return "Deleted";
        }

        public Invoice Get(int id)
        {
            //MVC
            return context.Invoice.FirstOrDefault(x => x.Id == id);
        }

        public List<Invoice> Gets()
        {
            return context.Invoice.ToList();

        }

        public Invoice Save(Invoice c)
        {
            context.Invoice.Add(c);
            context.SaveChanges(); //COMMIT
            return this.Get(c.Id);
        }

        public Invoice Update(Invoice c)
        {
            context.Invoice.Update(c);
            context.SaveChanges(); //COMP
            return this.Get(c.Id);

        }
    }
}