using bnbapp.Models;

namespace bnbapp.IRepository
{
    public interface IInvoiceRepository
    {
        public Invoice Save(Invoice c);
        public Invoice Update(Invoice c);
        public Invoice Get(int id);
        public List<Invoice> Gets();
        public string Delete(int id);

    }
}