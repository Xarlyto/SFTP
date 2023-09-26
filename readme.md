
# SFTP Test

Basic SFTP Test class based on Renci.SshNet to upload and download files to an SFTP Server.


## Run Locally

Clone the project

```bash
  git clone https://github.com/Xarlyto/SFTP.git
```

Go to the project directory

```bash
  cd SFTP
```

Install dependencies

```bash
  dotnet add package SSH.NET --version 2020.0.2
```

Start the SFTP free server

```bash
  https://sftpcloud.io/tools/free-sftp-server
```

Make sure to replace **"your_sftp_host", "your_username", and "your_password"** with your actual SFTP server details.

Run

```bash
  dotnet run
```

## License

[MIT](https://choosealicense.com/licenses/mit/)

