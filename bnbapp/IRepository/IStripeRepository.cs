using Stripe;

namespace bnbapp.IRepository
{
    public interface IStripeRepository
    {
        Task<string> MakePaymentStripe(string cardNumber, string expMonth, string expYear, string cvc, decimal value,string name, string city, string country, string line1, string line2, string zip, string state, string email,int orId);
    }
}
