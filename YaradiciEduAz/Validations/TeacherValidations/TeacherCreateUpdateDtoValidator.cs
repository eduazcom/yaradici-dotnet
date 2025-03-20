using System.Text.RegularExpressions;
using FluentValidation;
using YaradiciEduAz.DTOs.TeacherDTOs;

namespace YaradiciEduAz.Validations.TeacherValidations;

public class TeacherCreateUpdateDtoValidator: AbstractValidator<TeacherCreateUpdateDto>
{
    public TeacherCreateUpdateDtoValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full Name is required")
            .MaximumLength(255).WithMessage("Full Name cannot exceed 255 characters");
        
        RuleFor(x => x.Link)
            .Must(LinkMustBeAUri).WithMessage("Link must be a valid URI");

        
        RuleFor(x => x.Status)
            .NotNull().WithMessage("Status is required");
        
        RuleFor(x => x.Thumbnail)
            .Must(IsBase64String)
            .WithMessage("Thumbnail should be a valid base64 string");
    }
    private static bool LinkMustBeAUri(string link)
    {
        if (string.IsNullOrWhiteSpace(link))
        {
            return false;
        }
        Uri result;
        return Uri.TryCreate(link, UriKind.Absolute, out result);
    }
    public static bool IsBase64String(string base64)
    {
        Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
        return Convert.TryFromBase64String(base64, buffer , out int bytesParsed);
    }
}