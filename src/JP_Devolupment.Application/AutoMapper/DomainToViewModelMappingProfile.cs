using AutoMapper;
using JP_Devolupment.Application.ViewModels;
using JP_Devolupment.Domain.Models;

namespace JP_Devolupment.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
