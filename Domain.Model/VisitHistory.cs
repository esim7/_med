using System;

namespace Domain.Model
{
    public class VisitHistory : BaseEntity
    {
        public string FullName { get; set; }
        public DoctorPosition Position { get; set; }
        public string Diagnose { get; set; }
        public string Complaint { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}