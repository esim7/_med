namespace Domain.Model
{
    public class Patient : BaseEntity
    {
        public string IIN { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public VisitHistory History { get; set; }
    }
}