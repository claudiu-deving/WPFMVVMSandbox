namespace Library.Infrastructure.ExceptionHandling.Tests
{
    public interface ITestFilesProvider
    {
        void AddFile(string name, string content);
        void DeleteFile(string name);
        bool FileExists(string name);
        string ReadFile(string name);
    }
}