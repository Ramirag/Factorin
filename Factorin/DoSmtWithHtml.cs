using NLog;

namespace Factorin
{
    public sealed class DoSmtWithHtml : DoSmtWithFile
    {
        private readonly Logger _logger;

        public DoSmtWithHtml(Logger logger)
        {
            _logger = logger;
            FileExtension = ".html";
        }

        public override void DoSmt(string fileName, string file)
        {
            var count = GetDivCount(file);
            _logger.Info(CreateLogMessage(fileName, nameof(GetDivCount), count.ToString()));
        }

        private int GetDivCount(string file)
        {
            return GetSubStringCount(file, "div");
        }
    }
}