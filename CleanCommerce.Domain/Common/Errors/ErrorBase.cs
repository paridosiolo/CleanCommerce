using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommerce.Domain.Common.Errors
{
    public class ErrorBase : Error
    {
        public const string TYPE = "Type";
        public const string CODE = "Code";
        public ErrorBase(string code, ErrorType type, string message) : base(message)
        {
            Metadata.Add(CODE, code);
            Metadata.Add(TYPE, type);

            Code = code;
            Type = type;
        }
        public ErrorType Type { get; private set; }
        public string Code { get; private set; }
    }
    
    public enum ErrorType
    {
        Failure,
        Unexpected,
        Validation,
        Conflict,
        NotFound,
        Unauthorized,
    }
}
