using bnbapp.IRepository;
using MailKit.Net.Imap;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Linq;
using Org.BouncyCastle.Crypto;
using MailKit;

namespace bnbapp.Repository
{

    public class EmailSaveRepo : IEmailSaveRepo
    {
        private readonly IEmailRepository EmailRepository;
        private readonly ISentEmailRepository SentEmailRepository;

        //import GPTRepository
        // This code declares a readonly variable _clientFactory of type IHttpClientFactory. 
        // The 'readonly' keyword indicates that its value cannot be changed once initialized. 
        // IHttpClientFactory is an interface for a factory used to create HttpClient instances.

        public EmailSaveRepo(IEmailRepository emailRepository,ISentEmailRepository sentEmailRepository)
        {
            EmailRepository = emailRepository;
            SentEmailRepository = sentEmailRepository;
        }
        //This uses Imap On a gmail account to save the inbox to a table called Email & the Sent to a table called SentEmail and has a boolean for IsAttachment
        //create an empty array of int  called inboxEmailids

        
    //    public void SaveEmail()
    //    {
    //        try
    //        {
    //            using (var client = new ImapClient())
    //            {
    //                client.Connect("imap.gmail.com", 993, true);
    //                client.Authenticate("bnbcoding.tech@gmail.com", "
    //
    //                ");
    //                var inbox = client.Inbox;
    //                inbox.Open(MailKit.FolderAccess.ReadWrite);
    //                for (int i = 0; i < inbox.Count; i++)
    //                {

    //                    var message = inbox.GetMessage(i);
    //                    var email = new bnbapp.Models.Email();
    //                    email.From = message.From.ToString();
    //                    email.To = message.To.ToString();
    //                    if(message.Subject == null)
    //                    {
    //                        email.Subject = "NULL";
    //                    }
    //                    else
    //                    {
    //                        email.Subject = message.Subject;
    //                    }
    //                    if (message.TextBody == null)
    //                    {
    //                        if (message.HtmlBody == null)
    //                        {
    //                            email.Body = "NULL";
    //                        }
    //                        else
    //                        {
    //                            email.Body = message.HtmlBody;
    //                        }
    //                    }
    //                    else
    //                    {
    //                        email.Body = message.TextBody;
    //                    }
    //                    email.Date = message.Date.ToString();


    //                    //how to check if there is an attachment
    //                    if (message.Attachments.Count() > 0)
    //                    {
    //                        email.IsAttachment = "true";
    //                    }
    //                    else
    //                    {
    //                        email.IsAttachment = "false";
    //                    }
                        
    //                    EmailRepository.Save(email);
    //                    //delete the email from the inbox after saving
    //                    //append i to the inboxEmails array
                        
                        



    //                    // confirm the delte


    //                }

    //                //declare sent as a folder
    //                IMailFolder sent;

    //                //var sub = personal.GetSubfolder("Gmail");
    //                //var subs = sub.GetSubfolders();
    //                //var sent = sub.GetSubfolder();
    //                // Sent Folder from gmail acount using MailKit

    //                if (client.Capabilities.HasFlag(ImapCapabilities.SpecialUse))
    //                {
    //                    sent = client.GetFolder(SpecialFolder.Sent);
    //                }
    //                else
    //                {
    //                    var personal = client.GetFolder(client.PersonalNamespaces[0]);
    //                    sent = personal.GetSubfolder("Sent Items");
    //                }



    //                //is that going to work?

    //                sent.Open(MailKit.FolderAccess.ReadWrite);
    //                for (int i = 0; i < sent.Count; i++)
    //                {
    //                    var message = sent.GetMessage(i);
    //                    var email = new bnbapp.Models.SentEmail();
    //                    email.From = message.From.ToString();
    //                    email.To = message.To.ToString();
    //                    if (message.Subject == null)
    //                    {
    //                        email.Subject = "NULL";
    //                    }
    //                    else
    //                    {
    //                        email.Subject = message.Subject;
    //                    }
    //                    if (message.TextBody == null)
    //                    {
    //                        if (message.HtmlBody == null)
    //                        {
    //                            email.Body = "NULL";
    //                        }
    //                        else
    //                        {
    //                            email.Body = message.HtmlBody;
    //                        }
    //                    }
    //                    else
    //                    {
    //                        email.Body = message.TextBody;
    //                    }
    //                    email.Date = message.Date.ToString();
    //                    //how to check if there is an attachment
    //                    if (message.Attachments.Count() > 0)
    //                    {
    //                        email.IsAttachment = "true";
    //                    }
    //                    else
    //                    {
    //                        email.IsAttachment = "false";
    //                    }
                        
    //                    SentEmailRepository.Save(email);
    //                    //delete the email
    //                    //append i to sentEmails array
                        

    //                }
    //                //delete the emails from the inbox
                    
    //                client.Disconnect(true);
    //            }
    //        }
    //        catch(Exception ex) { }
            
    //    }
        // recreate the same method above but modify it slightly to delete the emails from the inbox & sent after saving them to the database

        public void SaveEmail()
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect("imap.gmail.com", 993, true);
                    client.Authenticate("bnbcoding.tech@gmail.com", "passwordington");
                    var inbox = client.Inbox;
                    inbox.Open(MailKit.FolderAccess.ReadWrite);
                    for (int i = 0; i < inbox.Count; i++)
                    {
                        var message = inbox.GetMessage(i);
                        var email = new bnbapp.Models.Email();
                        email.From = message.From.ToString();
                        email.To = message.To.ToString();
                        if (message.Subject == null)
                        {
                            email.Subject = "NULL";
                        }
                        else
                        {
                            email.Subject = message.Subject;
                        }
                        if (message.TextBody == null)
                        {
                            if (message.HtmlBody == null)
                            {
                                email.Body = "NULL";
                            }
                            else
                            {
                                email.Body = message.HtmlBody;
                            }
                        }
                        else
                        {
                            email.Body = message.TextBody;
                        }
                        email.Date = message.Date.ToString();
                        if (message.Attachments.Count() > 0)
                        {
                            email.IsAttachment = "true";
                        }
                        else
                        {
                            email.IsAttachment = "false";
                        }
                        EmailRepository.Save(email);
                        

                        

                        //inbox.AddFlags(i, MessageFlags.Deleted, true);
                        

                        //inbox.Expunge();

                        


                    }
                    //declare sent as a folder
                    IMailFolder sent;

                    if (client.Capabilities.HasFlag(ImapCapabilities.SpecialUse))
                    {
                        sent = client.GetFolder(SpecialFolder.Sent);
                    }
                    else
                    {
                        var personal = client.GetFolder(client.PersonalNamespaces[0]);
                        sent = personal.GetSubfolder("Sent Items");
                    }

                    sent.Open(MailKit.FolderAccess.ReadWrite);

                    for (int i = 0; i < sent.Count; i++)
                    {
                        var message = sent.GetMessage(i);
                        var email = new bnbapp.Models.SentEmail();
                        email.From = message.From.ToString();
                        email.To = message.To.ToString();
                        if (message.Subject == null)
                        {
                            email.Subject = "NULL";
                        }
                        else
                        {
                            email.Subject = message.Subject;
                        }
                        if (message.TextBody == null)
                        {
                            if (message.HtmlBody == null)
                            {
                                email.Body = "NULL";
                            }
                            else
                            {
                                email.Body = message.HtmlBody;
                            }
                        }
                        else
                        {
                            email.Body = message.TextBody;
                        }
                        email.Date = message.Date.ToString();
                        //how to check if there is an attachment
                        //
                        //

                        if (message.Attachments.Count() > 0)
                        {
                            email.IsAttachment = "true";
                        }
                        else
                        {
                            email.IsAttachment = "false";
                        }
                        SentEmailRepository.Save(email);
                        //sent.AddFlags(i, MessageFlags.Deleted, true);
                        //sent.Expunge();
                        //wait for 5 seconds
                        
                    }



                    //delete all emails from inbox
                    
                    inbox.Open(MailKit.FolderAccess.ReadWrite);
                    //for each item in inbox delete it
                    for (int i = 0; i < inbox.Count; i++)
                        inbox.AddFlags(i, MessageFlags.Deleted, true);

                    inbox.Expunge();
                    //delete all emails from sent

                    sent.Open(MailKit.FolderAccess.ReadWrite);
                    for (int i = 0; i < sent.Count; i++)
                        sent.AddFlags(i, MessageFlags.Deleted, true);
                    
                    sent.Expunge();



                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
