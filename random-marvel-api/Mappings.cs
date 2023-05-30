using AutoMapper;

namespace random_marvel_api
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CharacterBioModel, TranslatedViewResponse>();
        }
    }
}
