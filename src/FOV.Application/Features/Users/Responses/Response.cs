﻿using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Application.Features.Users.Responses;
public sealed record GetAllEmployeeResponse(string Id, string FullName, string PhoneNumber, string EmployeeCode, DateTime HireDate, string RoleName, string RestaurantName, Status Status, DateTime CreatedDate);
public sealed record RegisterUserResponse(Guid Id,string Message,string FullName,string PhoneNumber);
public sealed record GetUsersResponse(Guid Id, string FullName, string PhoneNumber, DateTime CreatedDate);
