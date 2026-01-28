using System.ComponentModel.DataAnnotations;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WordSquare.Validators
{
    public class ValidWordSquareAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var request = (WordSquareRequest)validationContext.ObjectInstance;

            if (request.Letters?.Length != request.Size * request.Size)
            {
                return new ValidationResult(
                    $"Request not valid. Letters length must be {request.Size * request.Size} (Size * Size).");
            }

            return ValidationResult.Success;
        }
    }
}
