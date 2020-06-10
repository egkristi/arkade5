using System.Collections.Generic;
using System.IO;
using Arkivverket.Arkade.Core.Base;
using Arkivverket.Arkade.Core.Base.Noark5;
using Arkivverket.Arkade.Core.Resources;
using Arkivverket.Arkade.Core.Util;

namespace Arkivverket.Arkade.Core.Testing.Noark5
{
    public class N5_33_DocumentfilesReferenceControl : Noark5XmlReaderBaseTest
    {
        private readonly TestId _id = new TestId(TestId.TestKind.Noark5, 33);

        private static Dictionary<string, FileInfo> _documentFileNames;
        private static DirectoryInfo _documentsDirectory;

        public N5_33_DocumentfilesReferenceControl(Archive archive)
        {
            _documentsDirectory = archive.GetDocumentsDirectory();
            _documentFileNames = new Dictionary<string, FileInfo>(archive.DocumentFiles);
        }

        public override TestId GetId()
        {
            return _id;
        }

        public override TestType GetTestType()
        {
            return TestType.ContentAnalysis;
        }

        protected override List<TestResult> GetTestResults()
        {
            var testResults = new List<TestResult>();
            int documentWithoutReferenceCount = 0;

            foreach (KeyValuePair<string, FileInfo> fileNameEntry in _documentFileNames)
            {
                testResults.Add(new TestResult(ResultType.Error,
                    new Location(_documentsDirectory.Name),
                    string.Format(Noark5Messages.DocumentfilesReferenceControlMessage, fileNameEntry.Key)));

                documentWithoutReferenceCount++;
            }

            testResults.Insert(0, new TestResult(ResultType.Success, new Location(""), string.Format(Noark5Messages.TotalResultNumber,
                documentWithoutReferenceCount.ToString())));

            return testResults;
        }

        protected override void ReadElementValueEvent(object sender, ReadElementEventArgs eventArgs)
        {
            if (eventArgs.Path.Matches("referanseDokumentfil", "dokumentobjekt"))
                _documentFileNames.Remove(eventArgs.Value.Replace("\\", "/"));
        }

        protected override void ReadStartElementEvent(object sender, ReadElementEventArgs eventArgs)
        {
        }

        protected override void ReadAttributeEvent(object sender, ReadElementEventArgs eventArgs)
        {
        }

        protected override void ReadEndElementEvent(object sender, ReadElementEventArgs eventArgs)
        {
        }
    }
}
