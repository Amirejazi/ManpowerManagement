﻿using MpManagement.Application.DTOs.Common;
using MpManagement.Domain;

namespace MpManagement.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDTO : BaseDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequest { get; set; }
        public string RequestComment { get; set; }
        public DateTime DateActioned { get; set; }
        public bool Aproved { get; set; }
        public bool Canceled { get; set; }
    }
}
