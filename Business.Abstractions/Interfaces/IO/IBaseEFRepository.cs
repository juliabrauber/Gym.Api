
using Business.Abstractions.IO.CoreResult;
using Entities.Data;


namespace Business.Abstractions.Interfaces.IO
{
    public interface IResultOutput<TOutput>
    {
        bool Success { get; set; }
        TOutput Data { get; set; }
        string Message { get; set; }
        IResultOutput<TOutput> OperationOutputSuccess(TOutput data, string message);
        IResultOutput<TOutput> OperationListOutputSuccess(IEnumerable<TOutput>? data, string message);
        IResultOutput<TOutput> OperationOutputError(string mensage);
        IResultOutput<TOutput> OperationOutputCustomer(bool success, TOutput data, string message);
    }

}
