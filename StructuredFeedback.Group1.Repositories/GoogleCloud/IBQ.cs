using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StructuredFeedback.Group1.Repositories.GoogleCloud
{
    public interface IBQ
    {
        Task<List<TableRow>> GetRows(string query);
        BigQueryClient GetBigqueryClient();
    }
}
