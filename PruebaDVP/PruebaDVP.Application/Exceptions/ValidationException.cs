﻿using FluentValidation.Results;

namespace PruebaDVP.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get;}

        public ValidationException() : base("Se presentan uno o más errores de validación.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failuerGroup => failuerGroup.Key, failureGroup => failureGroup.ToArray());
        }

    }
}
