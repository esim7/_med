using System;
using System.ComponentModel.DataAnnotations;
using Domain.Model;

namespace CardExample.Models.Patient
{
    public class PatientRequestViewModel
    {
        [Display(Name = "ИИН пациента")]
        public string IIN { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Адресс")]
        public string Address { get; set; }
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }
        public Domain.Model.VisitHistory History { get; set; }

        [Display(Name = "ФИО доктора")]
        public string DoctorFullName { get; set; }
        [Display(Name = "Должность")]
        public DoctorPosition Position { get; set; }
        [Display(Name = "Диагноз")]
        public string Diagnose { get; set; }
        [Display(Name = "Жалобы")]
        public string Complaint { get; set; }
        [Display(Name = "Дата обращения")]
        public DateTime CreationDate { get; set; }
    }
}