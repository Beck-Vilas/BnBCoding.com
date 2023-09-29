
using bnbapp.IRepository;
using Microsoft.AspNetCore.Mvc;
using Stripe;
//inject i stripe repository

namespace bnbapp.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class stripeController : ControllerBase
    {
        bool check = false;
        string values;
        private readonly IStripeRepository _stripeRepository;

        public stripeController(IStripeRepository stripeRepository) 
        {
            _stripeRepository = stripeRepository;
        }
        [HttpGet]
        [Route("CheckoutStripe")]

        public IActionResult CheckoutStripe(string cardNumber, string expMonth, string expYear, string cvc, decimal value, string name, string city, string country, string line1, string line2, string zip, string state, string email, int orId) 
        {
            var data = _stripeRepository.MakePaymentStripe(cardNumber, expMonth, expYear, cvc, value,name,city,country,line1,line2,zip,state,email,orId);
            //send user to page Post success if payment is successful and post fail if payment fails with payment error as parameter Data
            //redirect to page Post Fail if payment fails with payment error as parameter Data
            //if data is 200 then payment is successful and send to page Post success
            //if data threw ex then payment failed and send to page Post fail with error message as parameter Data
            //see if data is 200
            //if data.result first char is * check is true
            if(data.Result.StartsWith("*")) check = true;
            if (check)
            {
                values = data.Result;
                //get rid char
                values = values.Remove(0, 1);
                
                return Redirect("/PostSuccess?data="+values);
            }
            else
            {
                //send to page Post fail with error message as parameter Data
                return Redirect("/PostFail?data=" + data.Result);
            }

        }
    }
}
