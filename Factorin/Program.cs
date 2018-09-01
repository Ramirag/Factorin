using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;
using NLog;

namespace Factorin
{
    internal class Program
    {
        private const string ScanDirectory = "D:\\Test";
        private static Dictionary<string, IDoSmtWithFile> _doSmtWithFiles;
        private static IDoSmtWithFile _defaultDoSmtWithFiles;

        private static void Main()
        {
            var logger = LogManager.LogFactory.GetLogger("logger");

            var doSmtWithHtml = new DoSmtWithHtml(logger);
            var doSmtWithCss = new DoSmtWithCss(logger);
            var doSmtWithAllFiles = new DoSmtWithAllFiles(logger);

            _doSmtWithFiles = new Dictionary<string, IDoSmtWithFile>
            {
                {doSmtWithHtml.FileExtension, doSmtWithHtml},
                {doSmtWithCss.FileExtension, doSmtWithCss}
            };
            _defaultDoSmtWithFiles = doSmtWithAllFiles;

            Directory.CreateDirectory(ScanDirectory);
            var watcher = new FileSystemWatcher(ScanDirectory);
            watcher.Created += FileChanged;
            watcher.Changed += FileChanged;
            watcher.Renamed += FileChanged;

            watcher.EnableRaisingEvents = true;
            Console.ReadLine();

        }

        private static void FileChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            var extension = Path.GetExtension(fileSystemEventArgs.FullPath);
            var file = File.ReadAllText(fileSystemEventArgs.FullPath);
            if (!_doSmtWithFiles.TryGetValue(extension, out var doSmtWithFile))
            {
                doSmtWithFile = _defaultDoSmtWithFiles;
            }

            doSmtWithFile.DoSmt(fileSystemEventArgs.FullPath, file);
        }
    }
}