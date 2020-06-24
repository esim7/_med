using System;
using System.ComponentModel.DataAnnotations;
using Domain.Model;

namespace CardExample.Models.VisitHistory
{
    public class VisitHistoryEditViewModel
    {
        public int Id { get; set; }
        [Display(Name = "ФИО доктора")]
        public string FullName { get; set; }
        [Display(Name = "Должность")]
        public DoctorPosition Position { get; set; }
        [Display(Name = "Диагноз")]
        public string Diagnose { get; set; }
        [Display(Name = "Жалобы")]
        public string Complaint { get; set; }
        [Display(Name = "Дата обращения")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Пациент")]
        public Domain.Model.Patient Patient { get; set; }
    }
}