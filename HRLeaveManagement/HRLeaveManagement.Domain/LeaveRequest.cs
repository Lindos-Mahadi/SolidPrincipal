﻿using HRLeaveManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Domain
{
    public class LeaveRequest : BaseDomainEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set;}
        public DateTime DateRequested {  get; set; }
        public string RequestCommnets { get; set; }
        public DateTime? DateActioned {  get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get;}
    }
}
