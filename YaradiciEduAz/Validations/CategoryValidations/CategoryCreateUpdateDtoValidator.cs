using FluentValidation;
using YaradiciEduAz.DTOs.CategoryDTOs;

namespace YaradiciEduAz.Validations.CategoryValidations
{
    public class CategoryCreateUpdateDtoValidator : AbstractValidator<CategoryCreateUpdateDto>
    {
        public CategoryCreateUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(255).WithMessage("Name must not exceed 255 characters.");
        }
    }
}
