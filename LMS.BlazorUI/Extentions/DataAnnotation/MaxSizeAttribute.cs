using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CinosoftErp.Extensions.DataAnnotations;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class MaxSizeAttribute : ValidationAttribute
{
    private readonly long _size;

    public MaxSizeAttribute(long size)
    {
        _size = size;
    }
    public override string FormatErrorMessage(string name)
    {
        return base.FormatErrorMessage($"{name} must be greather than {_size}");
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null) 
            return ValidationResult.Success;

        if (value is not long currentPropValue) 
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));

        if (currentPropValue > _size)
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), new[] { validationContext.MemberName });

        return ValidationResult.Success;
    }
}
