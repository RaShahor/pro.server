using Aspose.Pdf;
using DAL;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BL
{
    public class SignerBl : ISignerBl

    {
        ISignerDl _signerDl;
        public List<SignImage> signsToBuild { get; set; }//Image

        public SignerBl(ISignerDl sdl)
        {
            _signerDl = sdl;
            signsToBuild = new List<SignImage>();//Image
        }
        public void addSign(Image sign, int v, int signId)
        {
            signsToBuild.Add(new SignImage(v, sign, signId));
        }

        public List<Sign> loadSignPointsLocation(int fTSid)
        {
            throw new NotImplementedException();
        }


        public void newSignedForm(FormSignerDTO fsDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> sendMail(int ftsId, Office office, int signer)
        {
            Signer ourSigner = await _signerDl.getSignerById(signer);
            Person p = await _signerDl.getPersonById(ourSigner.PersonId);

            //send a mail
            MailAddress to = new MailAddress(p.Mail);
            MailAddress from = new MailAddress("greensign2022@outlook.com");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Hi " + p.FName + " " + p.LName + "!!";
            message.Body = "You got a new form to sign on\nfrom the " + office.Name + " \nplease open the followed link as soon as posibble!\n\n\n for generate a password: https://docs.docker.com/desktop/extensions-sdk/";
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

        public async Task<bool> getPassword(string mail)
        {
            String pwd = _signerDl.getPassword(mail);
            DateTime pass = _signerDl.getPassTime(mail);
            //Signer ourSigner = await _signerDl.getSignerById(signer);
            //Person p = await _signerDl.getPersonById(ourSigner.PersonId);

            //send a mail
            MailAddress to = new MailAddress(mail);
            MailAddress from = new MailAddress("greensign2022@outlook.com");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "verification password";
            message.Body = "הסיסמא הזמנית שלך היא: " + pwd + " \n\n תשומת לבך, הסיסמא הינה מוגבלת בזמן!! (מאופשרת עד 24 ש' בלבד מרגע יצירתה) כלומר תקפה עד ל" + pass;


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

            //return 
        }
    
        public Task<List<Signer>> getAllSignersByUser(int id){
            return _signerDl.getAllSignersByUser(id);
        }

        public Task<Signer> NewSigner(Signer signerDTO, int UId)
        {
            return _signerDl.newSigner(signerDTO, UId);
        }

        public class SignImage
        {
            public int id { get; set; }
            public Image image { get; set; }
            public int sid { get; set; }
            public SignImage(int id, Image image, int sid)
            {
                this.id = id;
                this.image = image;
                this.sid = sid;
            }
        }
    }
}
