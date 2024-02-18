namespace Business.Abstractions.IO.CoreResult
{
    public class CoreOutputPaged<TOutput>
    {
        public int TotalRecords { get; set; }
        public IEnumerable<TOutput> ListOutput { get; set; }
    }
}
