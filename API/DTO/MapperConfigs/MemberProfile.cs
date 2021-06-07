using AutoMapper;
using Data;


namespace API.DTO.MapperConfigs
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberDto>();
        }
    }
}
