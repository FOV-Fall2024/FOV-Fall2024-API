﻿using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Application.Features.Users.Responses;
public sealed record GetAllEmployeeResponse(Guid Id, string FullName, string PhoneNumber, string EmployeeCode, DateTime HireDate, string RoleName, string RestaurantName, Status Status);
public sealed record RegisterUserResponse(Guid Id,string Message,string FullName,string PhoneNumber);
public sealed record GetUsersResponse(Guid Id, string FullName, string PhoneNumber,int Point, DateTime CreatedDate);
