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
using AutoMapper;

namespace BL
{
    public class SignerBl : ISignerBl

    {
        ISignerDl _signerDl;
        private IMapper _mapper;
        public List<SignImage> signsToBuild { get; set; }//Image

        public SignerBl(ISignerDl sdl,IMapper m)
        {
            _signerDl = sdl;
            signsToBuild = new List<SignImage>();//Image
            _mapper = m;
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
            message.Subject = "גדול יום גשמים";
            message.Body = "שלום חברות! \n\n\n כאן ריקי יערי \n מתגעגעת אליכן מאד\n רציתי את השמות של כולן לתפילה לזיווג הגון בעז''ה \n בעיתו ובזמנו בקרוב, בקלות ובשמחה...\nנשמח מאד לכל אחת שתתקשר אלי- 0533105673 \nאו תשלח לכאן את שמה המלא\n\nתודה רבה! \nובשורות טובות לכולנו!!!";
            //Attachment a = new Attachment("C:\\Users\\1\\OneDrive - מרכז בית יעקב\\RSWebAppCurrent\\RSWebApp\\wwwroot\\mail.190622.pdf");
            //message.Attachments.Add(a);

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
            message.Subject = "גדול יום גשמים";
            message.Body = "שלום חברות! /n כאן ריקי יערי/n מתגעגעת  מאד/n רציתי את השמות של כולן לתפילה לזיווג הגון בעז''ה n בעיתו ובזמנו בקרוב, בקלות ובשמחה.../nנשמח מאד לכל אחת שתתקשר אלי - /nאו תשלח לכאן את שמה המלא\nתודה רבה! \nובשורות טובות לכולנו!!!";




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
    
        public List<SignerDTO> getAllSignersByUser(int id){
            List<Signer>s= _signerDl.getAllSignersByUser(id).Result;
            List<SignerDTO> sDTO = _mapper.Map<List<Signer>, List<SignerDTO>>(s);
            return sDTO;
        }

        public Task<Signer> NewSigner(SignerDTO signerDTO, int UId)
        {
            Signer NewSigner = _mapper.Map<SignerDTO, Signer>(signerDTO);
            NewSigner.Person.Password ="";
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                NewSigner.Person.Password += ((char)(rnd.Next(106) + 20));
            }
            NewSigner.PassTime = DateTime.Now;
            return _signerDl.newSigner(NewSigner, UId);
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
