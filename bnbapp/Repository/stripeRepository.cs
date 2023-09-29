//using stripe.net
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bnbapp.IRepository;
using Stripe;
//use Invoice
using bnbapp.Models;
using bnbapp.Areas.Identity.Pages.Account;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;

namespace bnbapp.Repository
{
    public class stripeRepository : IStripeRepository
    {
        //inject signin manager
        //inject auth state provider
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IInvoiceRepository _invoiceRepository;
        //inject order repo
        private readonly IOrderRepository _orderRepository;
        public stripeRepository(IInvoiceRepository invoiceRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,AuthenticationStateProvider authenticationStateProvider, IOrderRepository orderRepository)
        {
            _invoiceRepository = invoiceRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationStateProvider = authenticationStateProvider;
            _orderRepository = orderRepository;

        }
        Models.Invoice invoice = new Models.Invoice();
        List<Models.Invoice> invoices = new List<Models.Invoice>();
        Order order = new Order();
        List<Order> orders = new List<Order>();
        Charge charge;
        private void LoadInvoicesAndOrders()
        {
            orders = new List<Order>();
            orders = _orderRepository.Gets();

            invoices = new List<Models.Invoice>();
            invoices = _invoiceRepository.Gets();

        }
        private void SaveInvoice(string paymentId,string amount, string userId, string id, decimal val)
        {

            invoice.Amount = amount;
            invoice.BillingId = paymentId;
            invoice.Date = DateTime.Today.ToShortDateString();
            invoice.Email = userId;
            invoice.OrderId = id;
            //go through each order in orders and find the one with the order.id == id  
            

            if (invoice.Id == 0) invoice = _invoiceRepository.Save(invoice);
            else invoice = _invoiceRepository.Update(invoice);

            // COMPANY 1
            // COMPANY 2
            // COMPANY 3
            LoadInvoicesAndOrders();
            SaveOrder(id, val);


        }
        private void SaveOrder(string id, decimal val)
        {
            foreach (Order orderd in orders)
            {
                if (orderd.Id == Convert.ToInt32(id))
                {
                    order = orderd;
                }
            }
            //order.TotalPayed = order.TotalPayed + convert to integer (val)
            order.TotalPayed = order.TotalPayed + Convert.ToInt32(val);
            if (order.Id == 0) order = _orderRepository.Save(order);
            else order = _orderRepository.Update(order);
            LoadInvoicesAndOrders();
        }
        public async Task<string> MakePaymentStripe(string cardNumber, string expMonth, string expYear, string cvc, decimal value,string name,string city, string country,string line1,string line2, string zip, string state, string email,int orId)
        {
            
            try
            {
                StripeConfiguration.ApiKey = "";//API KEY HERE;
                var optionToken = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = cardNumber,
                        ExpMonth = expMonth,
                        ExpYear = expYear,
                        Cvc = cvc
                    }
                };
                var serviceToken = new TokenService();
                Token stripeToken = await serviceToken.CreateAsync(optionToken);
                //if line2 is a equal to the string "null" then set customer with line2 as null
                if (line2 == "null")
                { 
                    var customer = new Customer
                    {
                        Name = name,
                        Address = new Address
                        {
                            City = city,
                            Country = country,
                            Line1 = line1,
                            PostalCode = zip,
                            State = state,
                        }
                    };
                }
                else
                {
                    var customer = new Customer
                    {
                        Name = name,
                        Address = new Address
                        {
                            City = city,
                            Country = country,
                            Line1 = line1,
                            Line2 = line2,
                            PostalCode = zip,
                            State = state,
                        }
                    };
                }
                var options = new ChargeCreateOptions
                {
                    Amount = Convert.ToInt64(value),
                    Currency = "usd",
                    Description = "BnB Coding Project Invoice",
                    Source = stripeToken.Id
                };
                
                var service = new ChargeService();
                Charge charge = await service.CreateAsync(options);
                if (charge.Paid)
                {
                    string orderID = orId.ToString();
                    //run the function save list of roles passing the payment id
                    LoadInvoicesAndOrders();
                    SaveInvoice(charge.Id,charge.Amount.ToString(),email,orderID,value);
                    return "*"+value.ToString();
                }
                else
                {
                    return "Error Charging The Card Provided Please Check The Credentials And Try Again";
                }
            }
            catch (Exception ex)
            {
               
                string error = ex.Message.Replace(" ", "%20");
                error = error.Replace("\n", "%20");
                error = error.Replace("\r", "%20");
                error = error.Replace("{", "");
                error = error.Replace("}", "");
                error = error.Replace("(", "");
                error = error.Replace(")", "");
                
                error = error.Replace("/", "");
                
                
                
                error = error.Replace("\"", "");
                
                return error;
            }
        }
    }
}
