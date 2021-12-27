using Google.Apis.Auth.OAuth2;
using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StructuredFeedback.Group1.Repositories.GoogleCloud
{
    public class BQ : IBQ
    {
        const string PROJECT_ID = "you-project-id";

        readonly IHostingEnvironment _hostingEnvironment;

        public BQ(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public BigQueryClient GetBigqueryClient()
        {
            var config = Path.Combine(_hostingEnvironment.WebRootPath, "bq-secrets.json");

            GoogleCredential credential = null;
            using (var jsonStream = new FileStream(config, FileMode.Open, FileAccess.Read, FileShare.Read))
                credential = GoogleCredential.FromStream(jsonStream);

            return BigQueryClient.Create(PROJECT_ID, credential);
        }

        public async Task<List<TableRow>> GetRows(string query)
        {
            var bqClient = GetBigqueryClient();

            var response = new List<TableRow>();

            var jobResource = bqClient.Service.Jobs;
            var querys = new QueryRequest() { Query = query};

            var queryResponse = await jobResource.Query(querys, PROJECT_ID).ExecuteAsync();

            if (queryResponse.JobComplete != false)
            {
                return queryResponse.Rows == null
                    ? new List<TableRow>()
                    : queryResponse.Rows.ToList();
            }

            var jobId = queryResponse.JobReference.JobId;

            var retry = true;
            var retryCounter = 0;
            while (retry && retryCounter < 4)
            {
                Thread.Sleep(100);

                var queryResults = await bqClient.Service.Jobs.GetQueryResults(PROJECT_ID, jobId).ExecuteAsync();

                if (queryResults.JobComplete != true)
                {
                    retryCounter++;
                    continue;
                }

                if (queryResults.Rows != null)
                    response = queryResults.Rows.ToList();

                retry = false;
            }

            return response;
        }
    }
}
