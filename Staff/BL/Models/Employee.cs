using System;

namespace Staff.BL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public long Inn { get; set; }
        public long Pss { get; set; }
        public int PassportSeries {get; set; }
        public int PassportId { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime HiredAt { get; set; }
        public DateTime? DismissedAt { get; set; }
        public int ContractId { get; set; }
        public string Education { get; set; }
        public string Address { get; set; }
        public long MobilePhone { get; set; }
        public string Mail { get; set; }
    }
}
