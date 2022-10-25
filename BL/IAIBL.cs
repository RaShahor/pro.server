using DTO;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Pdf;
using Aspose.Pdf;
namespace BL
{
    public interface IAIBL
    {
        //object getFTS(string name, int id);
        //Sign AddSign(Sign sign, int uId);
        //void updateSign(Sign sign, object uId, Sign newSign);
        //void deleteSign(int id);
        //Task<FormTemplate> getFT(string name, int id);
        //Task<List<Sign>> GetAllSignsFromAIModel(Page pdf);
        //Sign AddFT(FormTemplate ft, int uId);
        //Sign AddForm(FormUserDTO formDto, int uId);
        void buildMessage(int id);
    }
}