using System;

class Program
{
    static void Main(string[] args)
    {
        string host = "your_sftp_host";
        int port = 22; // SFTP default port
        string username = "your_username";
        string password = "your_password";

        using (var sftpManager = new SftpManager(host, port, username, password))
        {
            try
            {
                sftpManager.Connect();

                // Example: Upload a file to the SFTP server
                string localFilePath = AppContext.BaseDirectory + "/files/upload/localfile.txt";
                string remoteFilePath = "remotefile.txt";
                sftpManager.UploadFile(localFilePath, remoteFilePath);
                Console.WriteLine("File uploaded successfully.");

                // Example: Download a file from the SFTP server
                string downloadedFilePath = AppContext.BaseDirectory + "/files/download/downloadedfile.txt";
                sftpManager.DownloadFile(remoteFilePath, downloadedFilePath);
                Console.WriteLine("File downloaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                sftpManager.Disconnect();
            }
        }
    }
}
