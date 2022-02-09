using System;
namespace LibraryManagement.Repository.Interfaces
{
    public interface ILoggerRepository
    {
        void InserirLog(string action, string request, string response, string path, int? statusCode);
    }
}

