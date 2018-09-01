namespace Factorin
{
    public abstract class DoSmtWithFile : IDoSmtWithFile
    {
        public string FileExtension { get; protected set; }
        public abstract void DoSmt(string fileName, string file);

        protected int GetSubStringCount(string file, string subString)
        {
            var count = (file.Length - file.Replace(subString, "").Length) / subString.Length;
            return count;
        }

        protected string CreateLogMessage(string fileName, string methodName, string result)
        {
            return $"{fileName} - {methodName} - {result}";
        }
    }
}