namespace Factorin
{
    public interface IDoSmtWithFile
    {
        string FileExtension { get; }

        void DoSmt(string fileName, string file);
    }
}