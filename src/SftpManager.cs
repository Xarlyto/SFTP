using Renci.SshNet;
using System;
using System.IO;

public class SftpManager : IDisposable
{
    private SftpClient sftpClient;

    public SftpManager(string host, int port, string username, string password)
    {
        sftpClient = new SftpClient(host, port, username, password);
    }

    public void Connect()
    {
        sftpClient.Connect();
    }

    public void Disconnect()
    {
        sftpClient.Disconnect();
    }

    public void UploadFile(string localPath, string remotePath)
    {
        using (var fileStream = new FileStream(localPath, FileMode.Open))
        {
            sftpClient.UploadFile(fileStream, remotePath);
        }
    }

    public void DownloadFile(string remotePath, string localPath)
    {
        using (var fileStream = File.Create(localPath))
        {
            sftpClient.DownloadFile(remotePath, fileStream);
        }
    }

    public void Dispose()
    {
        sftpClient.Dispose();
    }
}
