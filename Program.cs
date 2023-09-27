using System;

class Program
{


    static void Main()
    {
        string host = "your_sftp_host";
        int port = 22;
        string username = "your_username";
        string password = "your_password";
        string remoteFilePath = "excelfile_upload.xlsx";
        string localFilePath = AppContext.BaseDirectory + "/files/download/excelfile_downloaded.xlsx";

        //---------------------------------------------------------------------
        //Upload the test file first
        //---------------------------------------------------------------------
        /*using var sftpManager = new SftpManager(host, port, username, password);
        try
        {
            sftpManager.Connect();

            // Example: Upload a file to the SFTP server
            Console.WriteLine("File is being uploaded:" + localFilePath);
            sftpManager.UploadFile(AppContext.BaseDirectory + "/files/upload/excelfile.xlsx", "excelfile_upload.xlsx");
            Console.WriteLine("File uploaded successfully.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            sftpManager.Disconnect();
        }        
*/

        //---------------------------------------------------------------------
        //Test download with retries
        //---------------------------------------------------------------------
        SftpFileDownloader downloader = new(host, port, username, password, remoteFilePath, localFilePath);
        // Specify the number of retry attempts and retry delay in milliseconds.
        downloader.DownloadFileWithRetries(maxRetryAttempts: 3, retryDelayMs: 2000);


        Console.WriteLine("Enjoy :)");
    }

    /*
    static void Main(string[] args)
    {
        string host = "your_sftp_host";
        int port = 22; // SFTP default port
        string username = "your_username";
        string password = "your_password";

        using var sftpManager = new SftpManager(host, port, username, password);
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
    */
}
