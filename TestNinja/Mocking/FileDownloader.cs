using System.Net;

namespace TestNinja.Mocking
{
    public class FileDownloader : IFileDownloader
    {
        public void Download(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url,path);
        }
    }
}
