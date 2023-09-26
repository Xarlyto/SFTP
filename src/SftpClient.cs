using Renci.SshNet;
using System;
using System.IO;

public class SftpManager : IDisposable
{
    private SftpClient sftpClient;

    public SftpManager(string host, string username, string password)
    {
        sftpClient = new SftpClient(host, username, password);
        sftpClient.Connect();
    }

    public void UploadFile(string localFilePath, string remoteFilePath)
    {
        using (var fileStream = new FileStream(localFilePath, FileMode.Open))
        {
            sftpClient.UploadFile(fileStream, remoteFilePath);
        }
    }

    public void DownloadFile(string remoteFilePath, string localFilePath)
    {
        using (var fileStream = new FileStream(localFilePath, FileMode.Create))
        {
            sftpClient.DownloadFile(remoteFilePath, fileStream);
        }
    }

    public void Dispose()
    {
        if (sftpClient != null && sftpClient.IsConnected)
        {
            sftpClient.Disconnect();
            sftpClient.Dispose();
        }
    }
}
