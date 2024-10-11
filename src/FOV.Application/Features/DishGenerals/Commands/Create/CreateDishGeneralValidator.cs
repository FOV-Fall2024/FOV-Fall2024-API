using FluentValidation;
using FOV.Application.Features.Categories.Commands.Update;
using FOV.Application.Features.DishGenerals.Commands.Create;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

public class CreateProductGeneralValidator : AbstractValidator<CreateProductGeneralCommand>
{
    public CreateProductGeneralValidator(CheckDishGeneralName nameCheck, CheckCategoryIdValidator categoryIdCheck)
    {
        RuleFor(command => command.DishGeneralName)
            .NotEmpty().WithMessage("Tên sản phẩm là bắt buộc.")
            .MaximumLength(100).WithMessage("Tên sản phẩm không được vượt quá 100 ký tự.")
            .SetValidator(nameCheck);

        RuleFor(command => command.DishGeneralPrice)
            .GreaterThan(0).WithMessage("Giá phải lớn hơn 0.");

        RuleFor(command => command.DishGeneralDescription)
            .NotEmpty().WithMessage("Mô tả là bắt buộc.")
            .MaximumLength(500).WithMessage("Mô tả không được vượt quá 500 ký tự.");

        RuleFor(command => command.CategoryId)
            .NotEmpty().WithMessage("ID danh mục là bắt buộc.")
            .SetValidator(categoryIdCheck);

        RuleFor(command => command.Images)
              .Must(images => images != null && images.Count == 3)
              .WithMessage("Bạn phải cung cấp chính xác ba hình ảnh bổ sung.");

        //RuleFor(command => command.Ingredients)
        //    .NotEmpty().WithMessage("Cần ít nhất một thành phần.");

        //RuleFor(command => command.DishGeneralImage)
        //    .NotEmpty().WithMessage("Hình ảnh mặc định là bắt buộc.")
        //    .Must(BeAValidUrl).WithMessage("Hình ảnh mặc định phải là URL hợp lệ.");
        //RuleFor(command => command.PercentPriceDifference).NotEmpty().ExclusiveBetween(20,50).WithMessage("Trong khoảng 20-50");
    }

    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}

public sealed class CheckDishGeneralName : AbstractValidator<string>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public CheckDishGeneralName(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(name => name).MustAsync(CheckName).WithMessage("Tên đã có trong hệ thống");
    }

    private async Task<bool> CheckName(string name, CancellationToken token)
    {
        DishGeneral? dishGeneral = await _unitOfWorks.DishGeneralRepository.FirstOrDefaultAsync(x => x.DishName == name);
        return dishGeneral == null;
    }
}

