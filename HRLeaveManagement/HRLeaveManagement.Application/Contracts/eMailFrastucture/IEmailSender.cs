﻿using HRLeaveManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Contracts.eMailFrastucture
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
