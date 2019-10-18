using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidation.Infrastructure
{
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

    public class MustBeTrueAttribute : Attribute, IModelValidator
    {
        public string ErrorMessage { get; set; } = "Это должно быть правдой";

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            bool? value = context.Model as bool?;
            if (!value.HasValue || value.Value == false)
            {
                return new List<ModelValidationResult>
                           {
                               new ModelValidationResult(string.Empty, ErrorMessage)
                           };
            }
            else
            {
                return Enumerable.Empty<ModelValidationResult>();
            }
        }
    }
}