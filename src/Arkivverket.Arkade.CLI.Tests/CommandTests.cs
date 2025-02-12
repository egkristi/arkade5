using System.Collections.Generic;
using System.Linq;
using CommandLine;
using FluentAssertions;
using Xunit;

namespace Arkivverket.Arkade.CLI.Tests
{
    public class CommandTests
    {
        [Fact]
        public void CommonInputErrorIsHandled()
        {
            var argsWithExpectedError = new List<(string, ErrorType)>
            {
                // BadVerbSelectedError
                ("-a archive", ErrorType.BadVerbSelectedError),
                ("wrong -a archive", ErrorType.BadVerbSelectedError),

                // MissingRequiredOptionError
                ("process -m metadata -p process-dir -o output-dir", ErrorType.MissingRequiredOptionError),
                ("process -a archive -p process-dir -o output-dir", ErrorType.MissingRequiredOptionError),
                ("process -a archive -m metadata -o output-dir", ErrorType.MissingRequiredOptionError),
                ("process -a archive -m metadata -p process-dir", ErrorType.MissingRequiredOptionError),
                ("pack -m metadata -p process-dir -o output-dir", ErrorType.MissingRequiredOptionError),
                ("pack -a archive -p process-dir -o output-dir", ErrorType.MissingRequiredOptionError),
                ("pack -a archive -m metadata -o output-dir", ErrorType.MissingRequiredOptionError),
                ("pack -a archive -m metadata -p process-dir", ErrorType.MissingRequiredOptionError),
                ("test -p process-dir -o output-dir", ErrorType.MissingRequiredOptionError),
                ("test -a archive -o output-dir", ErrorType.MissingRequiredOptionError),
                ("test -a archive -p process-dir", ErrorType.MissingRequiredOptionError),
                ("generate -m", ErrorType.MissingRequiredOptionError),
                ("generate -l", ErrorType.MissingRequiredOptionError),
                ("analyse -f document-file-dir", ErrorType.MissingRequiredOptionError),
                ("analyse -o output-dir", ErrorType.MissingRequiredOptionError),

                //MissingGroupOptionError
                ("generate -o output-dir", ErrorType.MissingGroupOptionError),

                // TODO: After upgrading nuget package CommandlineParser from version 2.8.0 to 2.9.1, the test cases below are failing with ErrorType.MissingRequiredOptionError, not with ErrorType.MissingValueOptionError. Rewrite or remove.
                // MissingValueOptionError
                //("process --archive", ErrorType.MissingValueOptionError),
                //("process --type", ErrorType.MissingValueOptionError),
                //("process --metadata-file", ErrorType.MissingValueOptionError),
                //("process --processing-area", ErrorType.MissingValueOptionError),
                //("process --output-directory", ErrorType.MissingValueOptionError),
                //("process --information-package-type", ErrorType.MissingValueOptionError),
                //("pack --archive", ErrorType.MissingValueOptionError),
                //("pack --type", ErrorType.MissingValueOptionError),
                //("pack --metadata-file", ErrorType.MissingValueOptionError),
                //("pack --processing-area", ErrorType.MissingValueOptionError),
                //("pack --output-directory", ErrorType.MissingValueOptionError),
                //("pack --information-package-type", ErrorType.MissingValueOptionError),
                //("test --archive", ErrorType.MissingValueOptionError),
                //("test --type", ErrorType.MissingValueOptionError),
                //("test --processing-area", ErrorType.MissingValueOptionError),
                //("test --output-directory", ErrorType.MissingValueOptionError),
                //("generate --output-directory", ErrorType.MissingValueOptionError),
                //("analyse --output-directory", ErrorType.MissingValueOptionError),
                //("analyse --format-analysis", ErrorType.MissingValueOptionError),
                

                // UnknownOptionError
                ("process --metadata-example", ErrorType.UnknownOptionError),
                ("pack --metadata-example", ErrorType.UnknownOptionError),
                ("test --metadata-example", ErrorType.UnknownOptionError),
                ("test --metadata-file", ErrorType.UnknownOptionError),
                ("test --information-package-type", ErrorType.UnknownOptionError),
                ("generate --archive", ErrorType.UnknownOptionError),
                ("generate --type", ErrorType.UnknownOptionError),
                ("generate --metadata-file", ErrorType.UnknownOptionError),
                ("generate --processing-area", ErrorType.UnknownOptionError),
                ("generate --information-package-type", ErrorType.UnknownOptionError),
                ("analyse --archive", ErrorType.UnknownOptionError),
                ("analyse --type", ErrorType.UnknownOptionError),
                ("analyse --metadata-file", ErrorType.UnknownOptionError),
                ("analyse --processing-area", ErrorType.UnknownOptionError),
                ("analyse --information-package-type", ErrorType.UnknownOptionError),

                // RepeatedOptionError
                ("process -a archive -a archive", ErrorType.RepeatedOptionError),
                ("pack -a archive -a archive", ErrorType.RepeatedOptionError),
                ("test -a archive -a archive", ErrorType.RepeatedOptionError),
                ("generate -m metadata -m metadata", ErrorType.RepeatedOptionError),
                ("analyse -f document-file-dir -f document-file-dir", ErrorType.RepeatedOptionError),
            };

            foreach ((string command, ErrorType expectedError) in argsWithExpectedError)
            {
                IEnumerable<ErrorType> parseErrors = null;

                Program.ParseArguments(command.Split(' ')).WithNotParsed(errors =>
                {
                    parseErrors = errors.Select(e => e.Tag);
                });

                parseErrors.Should().Contain(expectedError);
            }
        }
    }
}
