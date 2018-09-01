using NLog;

namespace Factorin
{
    public sealed class DoSmtWithAllFiles : DoSmtWithFile
    {
        private readonly Logger _logger;

        public DoSmtWithAllFiles(Logger logger)
        {
            _logger = logger;
            FileExtension = "*";
        }

        public override void DoSmt(string fileName, string file)
        {
            var count = GetPunctuationMarkCount(file);
            _logger.Info(CreateLogMessage(fileName, nameof(GetPunctuationMarkCount), count.ToString()));
        }

        private int GetPunctuationMarkCount(string file)
        {
            var count1 = GetSubStringCount(file, ".");
            var count2 = GetSubStringCount(file, ",");
            return count1 + count2;
        }
    }
}