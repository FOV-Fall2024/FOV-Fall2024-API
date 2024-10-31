using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Application.Features.Users.Responses;
public sealed record GetAllEmployeeResponse(string Id, string FullName, string PhoneNumber, string EmployeeCode, DateTime HireDate, string RoleName, string RestaurantName, Status Status, DateTime CreatedDate);
public sealed record RegisterUserResponse(string Id,string Message,string FullName,string PhoneNumber);
public sealed record GetUsersResponse(string Id, string FullName, string PhoneNumber, int Point, DateTime CreatedDate);
