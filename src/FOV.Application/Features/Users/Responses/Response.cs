using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Application.Features.Users.Responses;
public sealed record GetAllEmployeeResponse(string Id, string FullName, string Email, string EmployeeCode, DateTime HireDate, string RoleName, Guid RestaurantId, Status Status, DateTimeOffset Created);

public sealed record RegisterUserResponse(string Id,string Message,string FullName,string Email,string PhoneNumber);
public sealed record GetUsersResponse(string Id, string Name, string LastName, string FirstName, string Email);
