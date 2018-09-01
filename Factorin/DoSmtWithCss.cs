using NLog;

namespace Factorin
{
    public sealed class DoSmtWithCss : DoSmtWithFile
    {
        private readonly Logger _logger;

        public DoSmtWithCss(Logger logger)
        {
            _logger = logger;
            FileExtension = ".css";
        }

        public override void DoSmt(string fileName, string file)
        {
            var result = VerifyCss(file);
            _logger.Info(CreateLogMessage(fileName, nameof(VerifyCss), result.ToString()));
        }

        private bool VerifyCss(string file)
        {
            var count1 = GetSubStringCount(file, "{");
            var count2 = GetSubStringCount(file, "}");
            return count1 == count2;
        }
    }
}