using System;

class Program
{
    static void Main(string[] args)
    {
        string host = "eu-central-1.sftpcloud.io";
        string username = "cb04906e609b4004a36013854650a1a6";
        string password = "G0vwx7H4WjNSvpmcG04onCP2MJllmCvK";

        using (var sftpManager = new SftpManager(host, username, password))
        {
            try
            {
                Console.WriteLine(AppContext.BaseDirectory);

                // Upload a file
                sftpManager.UploadFile(AppContext.BaseDirectory + "/files/upload/localfile.txt", "remotefile.txt");

                // Download a file
                sftpManager.DownloadFile("remotefile_2.txt", AppContext.BaseDirectory + "/files/download/downloadedfile.txt");

                Console.WriteLine("File operations completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
