namespace LogService.Services
{
    public class MyLogService : ILogService
    {

        public async Task Append(string str)
        {
            try
            {
                string logMessage = $" {str} - {DateTime.Now:yyyy-MM-dd HH:mm:ss} {Environment.NewLine}";

                await File.AppendAllTextAsync("Log.txt", logMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
