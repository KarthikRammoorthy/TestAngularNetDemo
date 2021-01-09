using testapi.Models;

namespace testapi.Service
{
    public interface IQueryProcessor
    {
        public Response QueryProcessing(QueryRequest queryItem);
    }
}