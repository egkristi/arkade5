﻿using System.Collections.Generic;
using System.Linq;
using Arkivverket.Arkade.Core.Base;
using Arkivverket.Arkade.Core.Testing;
using Arkivverket.Arkade.Core.Testing.Noark5;
using Arkivverket.Arkade.Core.Tests.Base;
using FluentAssertions;
using Xunit;

namespace Arkivverket.Arkade.Core.Tests.Testing.Noark5
{
    public class N5_45_NumberOfDisposalsExecutedTest : LanguageDependentTest
    {
        [Fact]
        public void HasSeveralDisposalsExecutedWithinSingleArchivePart()
        {
            XmlElementHelper helper = new XmlElementHelper()
                .Add("arkiv",
                    new XmlElementHelper()
                        .Add("arkivdel",
                            new XmlElementHelper()
                                .Add("systemID", "someArchivePartSystemId_1")
                                .Add("utfoertKassasjon", string.Empty)
                                .Add("klassifikasjonssystem",
                                    new XmlElementHelper()
                                        .Add("klasse",
                                            new XmlElementHelper()
                                                .Add("mappe",
                                                    new XmlElementHelper()
                                                        .Add("registrering",
                                                            new XmlElementHelper()
                                                                .Add("dokumentbeskrivelse",
                                                                    new XmlElementHelper()
                                                                        .Add("utfoertKassasjon", string.Empty))))))));


            // Creating a test archive stating that it should contain executed disposals
            var testArchive = new ArchiveBuilder().WithArchiveType(ArchiveType.Noark5)
                .WithWorkingDirectoryRoot("TestData\\Noark5\\MetaDataTesting\\BooleansTrue").Build();

            TestRun testRun = helper.RunEventsOnTest(new N5_45_NumberOfDisposalsExecuted(testArchive));

            testRun.TestResults.TestsResults.First().Message.Should().Be("Totalt: 2");

            testRun.TestResults.GetNumberOfResults().Should().Be(1);
        }

        [Fact]
        public void HasSeveralDisposalsExecutedWithinSeveralArchiveParts()
        {
            XmlElementHelper helper = new XmlElementHelper()
                .Add("arkiv",
                    new XmlElementHelper()
                        .Add("arkivdel",
                            new XmlElementHelper()
                                .Add("systemID", "someArchivePartSystemId_1")
                                .Add("tittel", "someArchivePartTitle_1")
                                .Add("utfoertKassasjon", string.Empty)
                                .Add("klassifikasjonssystem",
                                    new XmlElementHelper()
                                        .Add("klasse",
                                            new XmlElementHelper()
                                                .Add("mappe",
                                                    new XmlElementHelper()
                                                        .Add("registrering",
                                                            new XmlElementHelper()
                                                                .Add("dokumentbeskrivelse",
                                                                    new XmlElementHelper()
                                                                        .Add("utfoertKassasjon", string.Empty)))))))
                        .Add("arkivdel",
                            new XmlElementHelper()
                                .Add("systemID", "someArchivePartSystemId_2")
                                .Add("tittel", "someArchivePartTitle_2")
                                .Add("klassifikasjonssystem",
                                    new XmlElementHelper()
                                        .Add("klasse",
                                            new XmlElementHelper()
                                                .Add("mappe",
                                                    new XmlElementHelper()
                                                        .Add("registrering",
                                                            new XmlElementHelper()
                                                                .Add("dokumentbeskrivelse",
                                                                    new XmlElementHelper()
                                                                        .Add("utfoertKassasjon", string.Empty))))))));

            // Creating a test archive stating that it should contain executed disposals
            var testArchive = new ArchiveBuilder().WithArchiveType(ArchiveType.Noark5)
                .WithWorkingDirectoryRoot("TestData\\Noark5\\MetaDataTesting\\BooleansTrue").Build();

            TestRun testRun = helper.RunEventsOnTest(new N5_45_NumberOfDisposalsExecuted(testArchive));

            List<TestResult> testResults = testRun.TestResults.TestsResults;
            testResults.First().Message.Should().Be("Totalt: 3");
            testResults.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID, tittel): someArchivePartSystemId_1, someArchivePartTitle_1: 2"));
            testResults.Should().Contain(r =>
                r.Message.Equals("Arkivdel (systemID, tittel): someArchivePartSystemId_2, someArchivePartTitle_2: 1"));

            testRun.TestResults.GetNumberOfResults().Should().Be(3);
        }

        [Fact]
        public void ShouldRaiseWarningWithDocumentedExecutedDisposalsFalseAndActualExecutedDisposalsTrue()
        {
            XmlElementHelper helper = new XmlElementHelper()
                .Add("arkiv",
                    new XmlElementHelper()
                        .Add("arkivdel",
                            new XmlElementHelper()
                                .Add("systemID", "someArchivePartSystemId_1")
                                .Add("klassifikasjonssystem",
                                    new XmlElementHelper()
                                        .Add("klasse",
                                            new XmlElementHelper()
                                                .Add("mappe",
                                                    new XmlElementHelper()
                                                        .Add("registrering",
                                                            new XmlElementHelper()
                                                                .Add("dokumentbeskrivelse",
                                                                    new XmlElementHelper()
                                                                        .Add("utfoertKassasjon", string.Empty))))))));


            // Creating a test archive stating that it should not contain any executed disposals
            var testArchive = new ArchiveBuilder().WithArchiveType(ArchiveType.Noark5)
                .WithWorkingDirectoryRoot("TestData\\Noark5\\MetaDataTesting\\BooleansFalse").Build();

            TestRun testRun = helper.RunEventsOnTest(new N5_45_NumberOfDisposalsExecuted(testArchive));

            List<TestResult> testResults = testRun.TestResults.TestsResults;
            testResults.First().Message.Should().Be("Totalt: 1");
            testResults.Should().Contain(r => r.Message.Equals(
                "Det er dokumentert at uttrekket ikke skal omfatte utførte kassasjoner, men utførte kassasjoner ble funnet"
            ));

            testRun.TestResults.GetNumberOfResults().Should().Be(2);
        }

        [Fact]
        public void ShouldRaiseWarningWithDocumentedExecutedDisposalsTrueAndActualExecutedDisposalsFalse()
        {
            XmlElementHelper helper = new XmlElementHelper()
                .Add("arkiv",
                    new XmlElementHelper()
                        .Add("arkivdel",
                            new XmlElementHelper()
                                .Add("systemID", "someArchivePartSystemId_1")
                                .Add("klassifikasjonssystem",
                                    new XmlElementHelper()
                                        .Add("klasse",
                                            new XmlElementHelper()
                                                .Add("mappe",
                                                    new XmlElementHelper()
                                                        .Add("registrering",
                                                            new XmlElementHelper()
                                                                .Add("dokumentbeskrivelse", string.Empty)))))));


            // Creating a test archive stating that it should contain executed disposals
            var testArchive = new ArchiveBuilder().WithArchiveType(ArchiveType.Noark5)
                .WithWorkingDirectoryRoot("TestData\\Noark5\\MetaDataTesting\\BooleansTrue").Build();

            TestRun testRun = helper.RunEventsOnTest(new N5_45_NumberOfDisposalsExecuted(testArchive));

            List<TestResult> testResults = testRun.TestResults.TestsResults;
            testResults.First().Message.Should().Be("Totalt: 0");
            testResults.Should().Contain(r => r.Message.Equals(
                "Det er dokumentert at uttrekket skal omfatte utførte kassasjoner, men ingen utførte kassasjoner ble funnet"
            ));

            testRun.TestResults.GetNumberOfResults().Should().Be(2);
        }

        [Fact]
        public void HasNoDisposalsExecuted()
        {
            XmlElementHelper helper = new XmlElementHelper()
                .Add("arkiv",
                    new XmlElementHelper()
                        .Add("arkivdel",
                            new XmlElementHelper()
                                .Add("systemID", "someArchivePartSystemId_1")
                                .Add("klassifikasjonssystem",
                                    new XmlElementHelper()
                                        .Add("klasse",
                                            new XmlElementHelper()
                                                .Add("mappe",
                                                    new XmlElementHelper()
                                                        .Add("registrering",
                                                            new XmlElementHelper()
                                                                .Add("dokumentbeskrivelse",
                                                                    new XmlElementHelper())))))));


            // Creating a test archive stating that it should not contain any executed disposals
            var testArchive = new ArchiveBuilder().WithArchiveType(ArchiveType.Noark5)
                .WithWorkingDirectoryRoot("TestData\\Noark5\\MetaDataTesting\\BooleansFalse").Build();

            TestRun testRun = helper.RunEventsOnTest(new N5_45_NumberOfDisposalsExecuted(testArchive));

            testRun.TestResults.TestsResults.First().Message.Should().Be("Totalt: 0");

            testRun.TestResults.GetNumberOfResults().Should().Be(1);
        }
    }
}
