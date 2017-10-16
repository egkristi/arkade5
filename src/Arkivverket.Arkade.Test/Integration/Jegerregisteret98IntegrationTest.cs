﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Animation;
using Arkivverket.Arkade.Core;
using Arkivverket.Arkade.Core.Addml.Processes;
using FluentAssertions;
using Xunit;

namespace Arkivverket.Arkade.Test.Integration
{
    public class Jegerregisteret98IntegrationTest
    {
        [Fact (Skip="Needs Arkade processing area setting")]
        public void ShouldReadSmallVersionOfJegerregisteret98()
        {
            ArkadeProcessingArea.SetLocationSetting("..\\..\\TestData\\");

            ArchiveFile archive = ArchiveFile.Read("..\\..\\TestData\\tar\\jegerregisteret98-small\\20b5f34c-4411-47c3-a0f9-0a8bca631603.tar", ArchiveType.Fagsystem);
            Arkade.Core.Arkade arkade = new Arkade.Core.Arkade();
            TestSession testSesson = arkade.RunTests(archive);

            testSesson.Should().NotBeNull();
            TestSuite testSuite = testSesson.TestSuite;
            testSuite.Should().NotBeNull();
        }

    }
}