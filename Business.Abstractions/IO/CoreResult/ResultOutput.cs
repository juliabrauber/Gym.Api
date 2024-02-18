
using Business.Abstractions.Interfaces.IO;

namespace Business.Abstractions.IO.CoreResult
{
    public class ResultOutput<TOutput> : IResultOutput<TOutput>
    {
        public bool Success { get; set; }
        public TOutput Data { get; set; }
        public IEnumerable<TOutput>? DataList { get; set; }
        public string Message { get; set; }

        public IResultOutput<TOutput> OperationOutputSuccess(TOutput data, string message) => new ResultOutput<TOutput> { Success = true, Data = data, Message = message };
        public IResultOutput<TOutput> OperationListOutputSuccess(IEnumerable<TOutput>? data, string message) => new ResultOutput<TOutput> { Success = true, DataList = data, Message = message };
        public IResultOutput<TOutput> OperationOutputError(string message) => new ResultOutput<TOutput> { Success = false, Message = message };
        public IResultOutput<TOutput> OperationOutputCustomer(bool success, TOutput data, string message) => new ResultOutput<TOutput> { Success = success, Data = data, Message = message };
    }
}
