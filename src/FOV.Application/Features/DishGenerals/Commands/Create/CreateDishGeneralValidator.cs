﻿using FluentValidation;
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
            .MaximumLength(100).WithMessage("Tên sản phẩm không được vượt quá 100 ký tự.");
            //.SetValidator(nameCheck);

        RuleFor(command => command.DishGeneralPrice)
            .ExclusiveBetween(1000,1000000).WithMessage("Giá phải trong khoảng 1.000 ~ 1.000.000 .");

        RuleFor(command => command.DishGeneralDescription)
            .NotEmpty().WithMessage("Mô tả là bắt buộc.")
            .MaximumLength(500).WithMessage("Mô tả không được vượt quá 500 ký tự.");

        RuleFor(command => command.CategoryId)
            .NotEmpty().WithMessage("ID danh mục là bắt buộc.")
            .SetValidator(categoryIdCheck);

        RuleFor(command => command.Images)
            .NotNull().WithMessage("Bạn phải cung cấp ít nhất một hình ảnh.")
            .Must(images => images.Count >= 1 && images.Count <= 3).WithMessage("Bạn phải cung cấp từ 1 đến 3 hình ảnh.");

        //RuleFor(command => command.Ingredients)
        //    .NotEmpty().WithMessage("Cần ít nhất một thành phần.");

        //RuleFor(command => command.DishGeneralImage)
        //    .NotEmpty().WithMessage("Hình ảnh mặc định là bắt buộc.")
        //    .Must(BeAValidUrl).WithMessage("Hình ảnh mặc định phải là URL hợp lệ.");
        RuleFor(command => command.PercentPriceDifference).NotEmpty().ExclusiveBetween(1,100).WithMessage("Trong khoảng 1-100");
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

