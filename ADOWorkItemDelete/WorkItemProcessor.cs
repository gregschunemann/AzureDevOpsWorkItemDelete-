using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace ADOWorkItemDelete
{
    public class WorkItemProcessor
    {
        public static async Task<HttpResponseMessage> Delete(int id, string projectUri, string projectName, string personalAccessToken)
        {
            //DELETE https://dev.azure.com/{organization}/{project}/_apis/wit/workitems/{id}?api-version=5.1

            var deleteUri = Url.Combine(projectUri, projectName, "/_apis/wit/workitems/", id.ToString(), "?destroy=true&api-version=5.1");

            var responseMessage = await deleteUri.WithBasicAuth(string.Empty, personalAccessToken).DeleteAsync();

            return responseMessage;
        }
    }
}
