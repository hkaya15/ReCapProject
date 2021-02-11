using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
