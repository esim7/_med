using AutoMapper;
using CardExample.Models.VisitHistory;
using Domain.Model;

namespace CardExample.MapperProfiles
{
    public class VisitHistoryProfile : Profile
    {
        public VisitHistoryProfile()
        {
            CreateMap<VisitHistory, VisitHistoryViewModel>();
            CreateMap<VisitHistoryViewModel, VisitHistory>();

            CreateMap<VisitHistory, VisitHistoryDetailsViewModel>();
            CreateMap<VisitHistoryDetailsViewModel, VisitHistory>();

            CreateMap<VisitHistory, VisitHistoryEditViewModel>();
            CreateMap<VisitHistoryEditViewModel, VisitHistory>();

            CreateMap<VisitHistory, VisitHistoryDeleteVewModel>();
            CreateMap<VisitHistoryDeleteVewModel, VisitHistory>();
        }
    }
}