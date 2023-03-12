namespace ViServiceTest
{
    internal class FileService : BackgroundService
    {
        private readonly ILogger<FileService> _logger;
        private readonly string _tmpPath;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public FileService(ILogger<FileService> logger)
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
            _logger = logger;
            _tmpPath = @"C:\tmp";
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("TMP_PATH")))
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
                _tmpPath = Environment.GetEnvironmentVariable("TMP_PATH");
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Tmp Path: {0}", _tmpPath);
            _logger.LogInformation($"{nameof(FileService)} started");
            await Task.Run(() => Action(cancellationToken), cancellationToken);
        }

        public async Task Action(CancellationToken cancellationToken)
        {
            int n = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                string s = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                _logger.LogInformation("{0} - {1}", ++n, s);
                await WriteAllTextAsync("data.txt", s);
                var fi = new FileInfo("data.txt");
                await WriteAllTextAsync(@"c:\tmp\vst.txt", fi.FullName);
                await Task.Delay(1000);
            }
        }

        private async Task WriteAllTextAsync(string fn, string s)
        {
            try
            {
                await File.WriteAllTextAsync(fn, s);
            }
            catch (Exception ex)
            {
                _logger.LogError("Err: {0}", ex);
            }
        }
    }
}
