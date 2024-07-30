using FOV.Application.Features.Categories.Commands.AddNewChildCategory;
using FOV.Application.Features.Categories.Commands.AddNewParentCategory;
using FOV.Application.Features.Categories.Commands.Delete;
using FOV.Application.Features.Categories.Commands.Update;
using FOV.Application.Features.Categories.Queries.GetChildCategories;
using FOV.Application.Features.Categories.Queries.GetParentCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class CategoryController(IMediator mediator) : DefaultController
{

    private readonly IMediator _mediator = mediator;

    // [ ] Get All Parent Categories
    [HttpGet]
    public async Task<IActionResult> GetParentCategory()
    {
        var response = await _mediator.Send(new GetParentCategoriesCommand());
        return Ok(response);
    }

    // [ ] Get All Children Categories follow ParentCategory 
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetChildrenCategory(Guid Id)
    {
        var response = await _mediator.Send(new GetChilCategoriesCommand(Id));
        return Ok(response);
    }


    // [ ] Add New Parent Category
    [HttpPost("parentcategory")]
    public async Task<IActionResult> AddParentCategory(AddNewParentCategoryCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // [ ] Add Child Category
    [HttpPost("childcategory")]
    public async Task<IActionResult> AddChildCategory(AddNewChildCategoryCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // [ ] Update Name and Descriptiion 
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] string name)
    {
        var response = await _mediator.Send(new UpdateCategoryCommand { CategoryName = name, Id = id });
        return Ok(response);
    }

    // [ ] Delete Child Category
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteCategoryCommand(id));
        return Ok(response);
    }
}
