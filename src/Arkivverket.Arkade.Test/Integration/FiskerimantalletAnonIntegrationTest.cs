﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Arkivverket.Arkade.Core;
using Arkivverket.Arkade.Core.Addml.Processes;
using Arkivverket.Arkade.Util;
using FluentAssertions;
using Xunit;

namespace Arkivverket.Arkade.Test.Integration
{
    public class FiskerimantalletAnonIntegrationTest
    {
        [Fact(Skip = "Not yet support for delimiter based archives")]
        public void Test1()
        {
            ArchiveFile archive = ArchiveFile.Read("..\\..\\TestData\\tar\\fiskerimantallet-anonymized\\dab6c748-8d1a-4b6d-b091-3a7b8b3cb255.tar");
            Arkade.Core.Arkade arkade = new Arkade.Core.Arkade();
            TestSession testSesson = arkade.RunTests(archive);

            testSesson.Should().NotBeNull();
            TestSuite testSuite = testSesson.TestSuite;
            testSuite.Should().NotBeNull();
            testSuite.TestRuns.Should().NotBeNullOrEmpty();

            List<TestRun> analyseFindMinMaxValues = testSuite.TestRuns
                .Where(run => run.TestName == AnalyseFindMinMaxValues.Name)
                .ToList();
            analyseFindMinMaxValues.Count.Should().Be(1);
        }


        //[Fact]
        public void AnonymizeFiskerimantallet()
        {
            StreamWriter file = new StreamWriter(@"C:\tmp\file.txt", false, Encodings.ISO_8859_1);      

            Dictionary<string, string> randomFodselsnummerOgNavn = new Dictionary<string, string>();

            string[] allLines = File.ReadAllLines("C:\\tmp\\_testdata\\fiskerimantallet-anon\\manntal2000_2009.dat", Encodings.ISO_8859_1);
            foreach (string line in allLines)
            {
                string[] fields = line.Split(';');

                // Anonymize birth number
                string fnr = fields[1];
                string randomFnr = NorwegianBirthNumber.CreateRandom(fnr).ToString();

                fields[1] = randomFnr;

                // Anonymize name
                string randomName;
                if (randomFodselsnummerOgNavn.ContainsKey(randomFnr))
                {
                    randomName = randomFodselsnummerOgNavn[randomFnr];
                }
                else
                {
                    randomName = NorwegianNameGenerator.RandomLastNameAndFirstName().ToUpper();
                    randomFodselsnummerOgNavn.Add(randomFnr, randomName);
                }
                fields[2] = randomName;

                // Anonymize address
                fields[3] = fields[3].Length > 0 ? "PORTV. 2" : "";

                file.WriteLine(string.Join(";", fields));
            }

            file.Close();
        }
    }
}