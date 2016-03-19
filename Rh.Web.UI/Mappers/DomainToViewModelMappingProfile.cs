using AutoMapper;
using Rh.Dominio;
using Rh.Web.UI.ViewModels;

namespace Rh.Web.UI.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CandidatoViewModel, Candidato>();
        }
    }
}