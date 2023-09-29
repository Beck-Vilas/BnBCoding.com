// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using bnbapp.Models;
using bnbapp.IRepository;//add IRepository
using bnbapp.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bnbapp.Areas.Identity.Pages.Account
{
    public class ConfirmEmailChangeModel : PageModel
    {
        //inject the invoice repository
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUserRepository _userRepository;//do this shit for order repo
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ConfirmEmailChangeModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IUserRepository userRepository, IOrderRepository orderRepository, IInvoiceRepository invoiceRepository)// do this shit aswell
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _orderRepository = orderRepository;//right here and boom its all implemented and u can use the same functions we used in .razor
            _invoiceRepository = invoiceRepository;
        }
        User user = new User();
        List<User> users = new List<User>();
        Order order = new Order();
        List<Order> orders = new List<Order>();
        List<Order> curOrders = new List<Order>();
        Invoice invoice = new Invoice();
        List<Invoice> invoices = new List<Invoice>();
        List<Invoice> curinvoices = new List<Invoice>();
        string oldEmail;
        string newEmail;
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string email, string code)
        {
            LoadDb();
            newEmail = email;
            if (userId == null || email == null || code == null)
            {
                return RedirectToPage("/home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }
            oldEmail = await _userManager.GetEmailAsync(user);
            

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ChangeEmailAsync(user, email, code);
            if (!result.Succeeded)
            {
                StatusMessage = "Error changing email.";
                return Page();
            }

            // In our UI email and user name are one and the same, so when we update the email
            // we need to update the user name.
            var setUserNameResult = await _userManager.SetUserNameAsync(user, email);
            if (!setUserNameResult.Succeeded)
            {
                StatusMessage = "Error changing user name.";
                return Page();
            }
            CurrentActiveOrder();
            CurrentUser();
            CurrentActiveInvoice();
            SaveDB();
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Thank you for confirming your email change.";

            return Page();
        }
        private void LoadDb()
        {
            users = new List<User>();
            users = _userRepository.Gets();
            orders = new List<Order>();
            orders = _orderRepository.Gets();
            invoices = new List<Invoice>();
            invoices = _invoiceRepository.Gets();

        }
        private void CurrentUser()
        {

            foreach (User userd in users)
            {
                if (userd.Email == oldEmail)
                {
                    user = userd;
                    //make sure the user is not null
                    if (user != null)
                    {
                        user.Email = newEmail;
                        user = _userRepository.Update(user);
                    }
                    
                }
                     
            }
        }
        //create function call CurrentActiveInvoice that will update the email of the invoice
        private void CurrentActiveInvoice()
        {
            foreach (Invoice invoiced in invoices)
            {
                if (invoiced.Email == oldEmail)
                {
                    curinvoices.Add(invoiced);
                }
            }
            foreach (Invoice invoiced in curinvoices)
            {
                invoice = invoiced;
                if (invoice != null)
                {
                    invoice.Email = newEmail;
                    invoice = _invoiceRepository.Update(invoice);
                }
            }
        }   
        private void CurrentActiveOrder()
        {

            foreach (Order order in orders)
            {
                if (order.Email == oldEmail)
                {
                    curOrders.Add(order);
                }
            }


        }
        private void SaveDB()
        {

            foreach (Order orderd in curOrders)
            {
                order = orderd;
                if (order != null)
                {
                    order.Email = newEmail;
                    order = _orderRepository.Update(order);
                }
            }

        }
    }
}
