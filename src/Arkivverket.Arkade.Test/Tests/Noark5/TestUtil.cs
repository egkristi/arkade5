using System;
using System.IO;
using Arkivverket.Arkade.Core;

namespace Arkivverket.Arkade.Test.Tests.Noark5
{
    public class TestUtil
    {
        public static string TestDataDirectory =  AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "TestData" + Path.DirectorySeparatorChar;

        public static Archive CreateArchiveExtraction(string testdataDirectory)
        {
            string workingDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\{testdataDirectory}";
            return new Core.ArchiveBuilder()
                .WithArchiveType(ArchiveType.Noark5)
                .WithWorkingDirectory(workingDirectory)
                .Build();
        }

        public static string ReadFromFileInTestDataDir(string fileName)
        {
            return File.ReadAllText(TestDataDirectory + fileName);
        }

    }
}
