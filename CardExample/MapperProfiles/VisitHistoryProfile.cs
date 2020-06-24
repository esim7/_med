using AutoMapper;
using CardExample.Models.Patient;
using CardExample.Models.VisitHistory;
using Domain.Model;

namespace CardExample.MapperProfiles
{
    public class VisitHistoryProfile : Profile
    {
        public VisitHistoryProfile()
        {
            CreateMap<PatientRequestViewModel, VisitHistory>()
                .ForMember(dest => dest.FullName, 
                    exp => 
                        exp.MapFrom(src => src.DoctorFullName));

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