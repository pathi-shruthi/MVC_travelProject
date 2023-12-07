using System;
using System.Collections.Generic;

namespace MVC_TravelProject.Models
{
    public partial class TravelRequest
    {
        public int RequestedId { get; set; }
        public int? EmployeeId { get; set; }
        public string? FromLocation { get; set; }
        public string? ToLocation { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? ApproveStatus { get; set; } = "Pending";
        public string? BookingStatus { get; set; } = "Pending";
        public string? CurrentStatus { get; set; } = "Open";

        public virtual Employee? Employee { get; set; }
    }
}
