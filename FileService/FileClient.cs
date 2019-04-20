using System.Net.Http;
using System.Net.Http.Headers;

namespace FileService
{
    public class BCMCHStorageClient
    {
        private HttpClient httpClient;
        private AuthenticationHeaderValue authenticationHeaderValue;
        private string fileName;
        private readonly string clientPostUrl;

        public BCMCHStorageClient()
        {
            clientPostUrl = "http://localhost:2821/api/upload/";
        }
        public BCMCHStorageClient(string accountId,string containerId, string path)
        {
            
        }


        public void Upload(byte[] fileContent)
        {
            ByteArrayContent fileDate = new ByteArrayContent(fileContent);
            MultipartFormDataContent multiContent = new MultipartFormDataContent
            {
                { fileDate, "file", fileName }
            };
            httpClient = new HttpClient();
            var result = httpClient.PostAsync(clientPostUrl + fileName, multiContent).Result;
        }

        private void AddHeader()
        {
            httpClient.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
            httpClient.DefaultRequestHeaders.Add("xcust", "ok");
        }
    }
}