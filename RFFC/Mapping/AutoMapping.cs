using AutoMapper;
using RFFC.DTO_s;
using RFFC.DTO_S;
using RFFC.Entities;

namespace RFFC.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<RFC, RFCMemberDto>().ReverseMap();
            CreateMap<RFC, RFCStringDTO>().ReverseMap();

            CreateMap<AuthDto.Signup, Auth>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        }
    }
}
