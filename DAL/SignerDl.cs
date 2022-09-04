using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SignerDl:ISignerDl
    {
        private readonly SignContext _ctx;
        public SignerDl(SignContext scon)
        {
            this._ctx = scon;
        }
        private async Task<Signer> getSignerById(int signer)
        {
            return await _ctx.Signers.FindAsync(signer);
           

        }

        private async Task<Person> getPersonById(int p)
        {
            Person pers = await _ctx.People.FindAsync(p);
            return pers;
        }
        public async Task<bool> sendMail(int ftsId,Office office,int signer)
        {
           
                ////checking if the student already got a mail
                //if (await _IStudentStatuseDL.isSentMessege(studentId))
                //    return false;
                //else
               
                //find the current user

                Signer ourSigner =await getSignerById(signer);
                Person p = await getPersonById(ourSigner.PersonId);
       
                        //send a mail
                        MailAddress to = new MailAddress(p.Mail);
                        MailAddress from = new MailAddress("greensign2022@outlook.com");
                        MailMessage message = new MailMessage(from, to);
                        message.Subject = "Hi"+p.FName+" "+p.LName+"!!";
                        message.Body = "You got a new form to sign on\nfrom the " + office.Name+ " \nplease open the followed link as soon as posibble!";
                        Attachment a = new Attachment("C:\\Users\\1\\OneDrive - מרכז בית יעקב\\RSWebAppCurrent\\RSWebApp\\wwwroot\\mail.190622.pdf");
                        message.Attachments.Add(a);
                        SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
                        SmtpServer.Port = 587;
                        SmtpServer.UseDefaultCredentials = false;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("greensign2022@outlook.com", "ourj,hny");
                        SmtpServer.EnableSsl = true;
                        try
                        {
                            SmtpServer.Send(message);
                        }
                        catch (SmtpException ex)
                        {
                            Console.WriteLine(ex);
                            return false;
                        }
                        //update the file 'get alert' and return true
                        return true;
                    }
                   
                }
            }

       
 
