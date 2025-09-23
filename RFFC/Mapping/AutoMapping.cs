using RFFC.DTO_S;
using RFFC.Entities;
using AutoMapper;

namespace RFFC.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<RFC, RFCMemberDto>().ReverseMap();
            CreateMap<RFC, RFCStringDTO>().ReverseMap();
        }
    }
}
