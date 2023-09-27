using System;
using System.IO;
using System.Threading;
using Renci.SshNet;

namespace SFTP.src;

public class SftpFileUploader
{
    private const string SftpHost = "your.sftp.server.com";
    private const string SftpUsername = "your_username";
    private const string SftpPassword = "your_password";
    private const string RemoteDirectory = "/path/to/remote/directory/";
    private const string LocalFilePath = "path/to/local/excel/file.xlsx";

    public void UploadFileWithRetry()
    {
        const int maxRetries = 3;
        int retryCount = 0;
        
        while (retryCount < maxRetries)
        {
            try
            {
                using (var client = new SftpClient(SftpHost, SftpUsername, SftpPassword))
                {
                    client.Connect();

                    if (!client.IsConnected)
                    {
                        Console.WriteLine("Failed to connect to the SFTP server.");
                        return;
                    }

                    Console.WriteLine("Connected to the SFTP server.");

                    using (var fileStream = new FileStream(LocalFilePath, FileMode.Open))
                    {
                        var fileName = Path.GetFileName(LocalFilePath);
                        var remoteFilePath = RemoteDirectory + fileName;

                        //client.UploadFile(fileStream, remoteFilePath, (ulong)fileStream.Length, UploadProgress);

                        Console.WriteLine("File upload completed successfully.");
                    }
                }

                return; // Upload successful, exit retry loop
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                retryCount++;
                if (retryCount < maxRetries)
                {
                    Console.WriteLine($"Retrying (Attempt {retryCount + 1}/{maxRetries})...");
                    Thread.Sleep(TimeSpan.FromSeconds(5)); // Wait before retrying
                }
                else
                {
                    Console.WriteLine("Max retry attempts reached. Upload failed.");
                }
            }
        }
    }

    private void UploadProgress(ulong uploadedBytes)
    {
        Console.WriteLine($"Uploaded {uploadedBytes / 1024} KB");
    }
/*
    public static void Main(string[] args)
    {
        var uploader = new SftpFileUploader();
        uploader.UploadFileWithRetry();
    }
    */
}
