﻿using FluentValidation.Results;
using Shared;
using System.Text;

namespace BusinessLogicalLayer.Extensions
{
    internal static class ResponseExtensions
    {
        public static Response ToResponse(this ValidationResult result)
        {
            StringBuilder sb = new StringBuilder();
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    sb.AppendLine(item.ErrorMessage);
                }
                return new Response()
                {
                    HasSuccess = false,
                    Message = sb.ToString()
                };
            }
            return new Response()
            {
                HasSuccess = true,
                Message = "Entidade validada com sucesso."
            };
        }
    }
}