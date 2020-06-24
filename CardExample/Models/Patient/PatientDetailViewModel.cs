using System.ComponentModel.DataAnnotations;

namespace CardExample.Models.Patient
{
    public class PatientDetailViewModel
    {
        [Display(Name = "ИИН пациента")]
        public string IIN { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Адресс")]
        public string Address { get; set; }
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }
    }
}