using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        //public int Id { get; set; }
        public LeaveRequestDto LeaveRequestDto { get; set; }
        //public ChangeLeaveRequestApproveDto ChangeLeaveRequestApproveDto { get; set; }
    }
}
