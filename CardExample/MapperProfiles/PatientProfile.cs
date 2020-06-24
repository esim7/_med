using AutoMapper;
using CardExample.Models.Patient;
using CardExample.Models.VisitHistory;
using Domain.Model;

namespace CardExample.MapperProfiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientRequestViewModel>();
            CreateMap<PatientRequestViewModel, Patient>();

            CreateMap<Patient, PatientViewModel>();
            CreateMap<PatientViewModel, Patient>();

            CreateMap<Patient, PatientDetailViewModel>();
            CreateMap<PatientDetailViewModel, Patient>();

            CreateMap<Patient, PatientEditViewModel>();
            CreateMap<PatientEditViewModel, Patient>();

            CreateMap<Patient, PatientDeleteViewModel>();
            CreateMap<PatientDeleteViewModel, Patient>();
        }
    }
}