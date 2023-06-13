using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class CustomerRequest
    {
        public int RequestId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime SubmitDate { get; set; }
    }
}
