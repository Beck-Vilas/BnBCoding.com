// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Drawing.Text;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using bnbapp.Models;
using bnbapp.Repository;

namespace bnbapp.Areas.Identity.Pages.Account
{
    public class EmailChangeModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public EmailChangeModel(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }
        public string Message { get; set; }

        IdentityUser getUser;
        public async Task OnGetAsync(string userId, string newEmail)
        {
            getUser = await _userManager.FindByIdAsync(userId);
            if (getUser == null)
            {
                Response.Redirect("/home");

            }
            _logger.LogInformation("User Updated Email Address");


            var code = await _userManager.GenerateChangeEmailTokenAsync(getUser, newEmail);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmailChange",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, email = newEmail, code = code, },
                protocol: Request.Scheme);


            SendMail(callbackUrl,newEmail);
            Response.Redirect("PostEmailChange");

        }
        private void SendMail(string url,string email)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("bnbcoding.tech@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Confirm your new email";
                    mail.Body = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(url)}'>clicking here</a>.";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("bnbcoding.tech@gmail.com", "passwordington");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        Message = "Please check your email to confirm your account.";
                    }
                }
            }
            catch (Exception ex)
            {
                Message = (ex.Message);
            }

        }
        



    }
}
