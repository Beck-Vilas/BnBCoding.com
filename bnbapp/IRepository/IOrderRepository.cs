using bnbapp.Models;

namespace bnbapp.IRepository
{
    public interface IOrderRepository
    {
        public Order Save(Order c);
        public Order Update(Order c);
        public Order Get(int id);
        public List<Order> Gets();
        public string Delete(int id);

    }
}