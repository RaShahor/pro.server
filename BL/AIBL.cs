using Entities;
using DAL;
using Aspose.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Net.Mail;
using System.ComponentModel;

namespace BL
{
   public class AIBL : IAIBL
    {
        IAIDL IaiDL;
        public AIBL(IAIDL iai)
        {
            this.IaiDL= iai;
        }

        //public Sign AddForm(FormUserDTO formDto, int uId)
        //{
        //    throw new NotImplementedException();
        //}

        ////public Sign AddFT(FormTemplate ft, int uId)
        ////{
        ////    throw new NotImplementedException();
        ////}

        //public Sign AddSign(Sign sign, int uId)
        //{
        //    throw new NotImplementedException();
        //}

        //public void deleteSign(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<Sign>> GetAllSignsFromAIModel(Page myPdf)
        //{
        //    return IaiDL.GetAllSignsFromAIModel(myPdf);
        //}

        //public Task<List<Sign>> GetAllSignsFromAIModel()
        //{
        //    throw new NotImplementedException();
        //}

        ////public async Task<FormTemplate> getFT(string name, int id)
        ////{
        ////    return await IaiDL.getFT(name, id);
        ////}

        //public object getFTS(string name, int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void updateSign(Sign sign, object uId, Sign newSign)
        //{
        //    throw new NotImplementedException();
        //}
        public void buildMessage(int id)
        {
            SmtpClient client = new SmtpClient("@gmail.com");
            // Specify the email sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress("myLovelyProject@gmail.com",
               "first " + (char)0xD8 + " fromProject",
            System.Text.Encoding.UTF8);
            // Set destinations for the email message.
            MailAddress to = new MailAddress("racheli5400@gmail.com");
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);
            message.Body = "This is a test email message sent by an application. ";
            // Include some non-ASCII characters in body and subject.
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message.Body += Environment.NewLine + someArrows;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "test message 1" + someArrows;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            Attachment i = new Attachment("C: \\Users\\1\\OneDrive - מרכז בית יעקב\\RSWebAppCurrent\\RSWebApp\\wwwroot\\מייל פרוייקט.pdf");
            //C:\Users\325200806\OneDrive - מרכז בית יעקב\RSWebAppCurrent\RSWebApp\wwwroot\מייל פרוייקט.pdf
            message.Attachments.Add(i);
            // Set the method that is called back when the send operation ends.
            client.SendCompleted += new
            SendCompletedEventHandler(SendCompletedCallback);
            // The userState can be any object that allows your callback
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            string userState = "test message1";
            client.SendAsync(message, userState);
            Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
            //string answer = Console.ReadLine();
            //// If the user canceled the send, and mail hasn't been sent yet,
            //// then cancel the pending operation.
            //if (answer.StartsWith("c") && mailSent == false)
            //{
            //    client.SendAsyncCancel();
            //}
            // Clean up.
            message.Dispose();
            Console.WriteLine("Goodbye.");
            //return  IaiDL.returnAwait(id) ;
            return;
        }

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
