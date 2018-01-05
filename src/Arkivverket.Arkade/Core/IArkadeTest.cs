using System;
using Arkivverket.Arkade.Tests;
using Arkivverket.Arkade.Util;

namespace Arkivverket.Arkade.Core
{
    public interface IArkadeTest : IComparable
    {
        /// <summary>
        ///     Returns the ID of the test
        /// </summary>
        /// <returns></returns>
        TestId GetId();
        
        /// <summary>
        ///     Returns the name of the test
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        ///     Returns the description of the test.
        /// </summary>
        /// <returns></returns>
        string GetDescription();

        /// <summary>
        /// Returns the test type: structure, content analysis or content control
        /// </summary>
        /// <returns></returns>
        TestType GetTestType();

        /// <summary>
        /// Returns the TestRun results.
        /// </summary>
        /// <returns></returns>
        TestRun GetTestRun();
    }
}
