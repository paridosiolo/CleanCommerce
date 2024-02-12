using CleanCommerce.Application.Categories.Commands.CreateCategory;
using CleanCommerce.Application.Categories.Commands.DeleteCategory;
using CleanCommerce.Application.Categories.Commands.UpdateCategory;
using CleanCommerce.Application.Categories.Queries.GetCategory;
using CleanCommerce.Contracts.Category;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanCommerce.Api.Controllers
{
    [Route("[controller]")]
    public class CategoriesController : ApiController
    {
        ISender _sender;
        IMapper _mapper;
        public CategoriesController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            var command = _mapper.Map<CreateCategoryCommand>(request);

            var createCategoryResult = await _sender.Send(command);

            if (createCategoryResult.IsFailed)
            {
                return Problem(createCategoryResult.Errors);
            }

            return Ok(_mapper.Map<CategoryResponse>(createCategoryResult.Value));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetCategory(Guid productId)
        {
            var query = new GetCategoryQuery(productId);

            var getCategoryResult = await _sender.Send(query);

            if (getCategoryResult.IsFailed)
            {
                return Problem(getCategoryResult.Errors);
            }

            return Ok(_mapper.Map<CategoryResponse>(getCategoryResult.Value));
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteCategory(Guid productId)
        {
            var command = new DeleteCategoryCommand(productId);

            var deleteCategoryResult = await _sender.Send(command);

            if (deleteCategoryResult.IsFailed)
            {
                return Problem(deleteCategoryResult.Errors);
            }

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest request)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(request);

            var updateCategoryResult = await _sender.Send(command);

            if (updateCategoryResult.IsFailed)
            {
                return Problem(updateCategoryResult.Errors);
            }

            return Ok(_mapper.Map<CategoryResponse>(updateCategoryResult.Value));
        }
    }
}
