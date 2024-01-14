namespace LogService.Services
{
    public interface ILogService
    { 
        Task Append(string str);
    }
}
