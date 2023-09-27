using Renci.SshNet;
using Renci.SshNet.Common;

public class SftpFileDownloader
{
    private readonly string host;
    private readonly string username;
    private readonly string password;
    private readonly int port;
    private readonly string remoteFilePath;
    private readonly string localFilePath;

    public SftpFileDownloader(string host, int port, string username, string password, string remoteFilePath, string localFilePath)
    {
        this.host = host;
        this.port = port;
        this.username = username;
        this.password = password;
        this.remoteFilePath = remoteFilePath;
        this.localFilePath = localFilePath;
    }

    public void DownloadFileWithRetries(int maxRetryAttempts = 3, int retryDelayMs = 2000)
    {
        int retryCount = 0;
        bool downloadSuccessful = false;

        while (!downloadSuccessful && retryCount < maxRetryAttempts)
        {
            try
            {
                using (var client = new SftpClient(host, port, username, password))
                {
                    client.Connect();
                    using (var stream = File.OpenWrite(localFilePath))
                    {
                        client.DownloadFile(remoteFilePath, stream);
                    }
                    client.Disconnect();
                    downloadSuccessful = true;
                }

                Console.WriteLine("Download successful!");
            }
            catch (SftpPathNotFoundException ex)
            {
                Console.WriteLine($"Remote file not found: {ex.Message}");
                break; // Exit the loop if the remote file doesn't exist.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading file: {ex.Message}");
                retryCount++;
                Thread.Sleep(retryDelayMs); // Wait before the next retry.
            }
        }

        if (!downloadSuccessful)
        {
            Console.WriteLine($"Failed to download file after {maxRetryAttempts} attempts.");
        }
    }
}
