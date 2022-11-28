using AutoMapper;
using Entities;
using System;
namespace DTO
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<FormToSigner, FormToSignerDTO>().
                 ForMember(dest => dest.fullName, opts => opts.MapFrom(src => src.Signer.Person.FName + " " + src.Signer.Person.LName)).
                 ForMember(dest => dest.descrip, opts => opts.MapFrom(src => src.Form.FormName)).
                 ForMember(dest => dest.path, opts => opts.MapFrom(src => src.Form.Path)).
                 ForMember(dest=>dest.sID,opts=>opts.MapFrom(src=>src.SignerId));
            //.
            //ForMember(dest => dest.status, opts => opts.MapFrom(src => src.Status))

            CreateMap<Signer, SignerDTO>().
                ForMember(dest => dest.LName, opts => opts.MapFrom(src => src.Person.LName)).
                ForMember(dest => dest.FName, opts => opts.MapFrom(src => src.Person.FName)).
                ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Person.Mail)).
                ForMember(dest => dest.IdentityNumber, opts => opts.MapFrom(src => src.Person.IdentityNumber)).
                ReverseMap();

            CreateMap<FormTemplate, TemplateDTO>().
                ForMember(dest => dest.numOfSigns, opts => opts.MapFrom(src => src.FormUser.Signs.Count)).
                ForMember(dest => dest.owner, opts => opts.MapFrom(src => src.FormUser.User.Office.Name)).
                ForMember(dest => dest.numOfSigns, opts => opts.MapFrom(src => src.FormUser.Signs.Count));
        }

    }
}
