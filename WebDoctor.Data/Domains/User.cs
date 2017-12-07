using System;

namespace WebDoctor.Data
{
    public class User
    {
        public int Id { get; set; }
        public int? MemberNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public int? PhotoId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
