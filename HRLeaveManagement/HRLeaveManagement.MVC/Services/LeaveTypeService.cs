﻿using AutoMapper;
using HRLeaveManagement.MVC.Contracts;
using HRLeaveManagement.MVC.Models;
using HRLeaveManagement.MVC.Services.Base;

namespace HRLeaveManagement.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public LeaveTypeService(IMapper mapper, IClient httpclient, ILocalStorageService localStorageService) : base(httpclient, localStorageService)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                var createLeaveType = _mapper.Map<CreateLeaveTypeDto>(leaveType);
                AddBearerToken();
                var apiResponse = _client.LeaveTypePOSTAsync(createLeaveType);
                //if (apiResponse.IsCompletedSuccessfully)
                //{
                //    response.Data = apiResponse.Id;
                //    response.Success = true;
                //}
                //else
                //{
                //    foreach (var error in apiResponse.Errors)
                //    {
                //        response.ValidationErrors += error + Environment.NewLine;
                //    }
                //}
                response.Data = apiResponse.Id;
                response.Success = true;
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                AddBearerToken();
                await _client.LeaveTypeDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            AddBearerToken();
            var leaveType = await _client.LeaveTypeGETAsync(id);
            return _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            AddBearerToken();
            var leaveTypes = await _client.LeaveTypeAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            try
            {
                LeaveTypeDto leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);
                AddBearerToken();
                await _client.LeaveTypePUTAsync(leaveTypeDto);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

    }
}
