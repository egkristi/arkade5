using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Arkivverket.Arkade.Core.Util.ArchiveFormatValidation;
using FluentAssertions;
using ICSharpCode.SharpZipLib.Tar;
using Xunit;
using static Arkivverket.Arkade.Core.Util.ArkadeConstants;

namespace Arkivverket.Arkade.Core.Tests.Util.DiasValidation
{
    public class DiasValidatorTests
    {
        [Fact]
        public void ShouldValidateN5SipDirectory()
        {
            DiasDirectory diasDirectory = DiasProvider.ProvideForFormat(ArchiveFormat.DiasSipN5);

            var testDirectory = new DirectoryInfo("testDirectory");

            DiasProvider.Write(diasDirectory, testDirectory.FullName);

            DiasValidator.ValidateAsync(testDirectory, ArchiveFormat.DiasSipN5).Result
                .ValidationResult.Should().Be(ArchiveFormatValidationResultType.Valid);

            Delete(testDirectory);
        }

        [Fact]
        public void ShouldInvalidateN5SipDirectory()
        {
            DiasDirectory diasDirectory = DiasProvider.ProvideForFormat(ArchiveFormat.DiasSip);

            var testDirectory = new DirectoryInfo("testDirectory");

            DiasProvider.Write(diasDirectory, testDirectory.FullName);

            ArchiveFormatValidationResult result = DiasValidator.ValidateAsync(testDirectory, ArchiveFormat.DiasSipN5)
                .Result;

            result.ValidationResult.Should().Be(ArchiveFormatValidationResultType.Invalid);
            result.ValidationSummary().Should().Contain(Path.Combine(DirectoryNameContent, ArkivstrukturXmlFileName));

            Delete(testDirectory);
        }

        [Fact]
        public void ShouldValidateN5SipZipArchive()
        {
            DiasEntry[] diasEntries = DiasProvider.ProvideForFormat(ArchiveFormat.DiasSipN5).GetEntries();

            FileInfo diasTarArchive = CreateDiasTarArchive("testArchive.tar", diasEntries);

            DiasValidator.ValidateAsync(diasTarArchive, ArchiveFormat.DiasSipN5).Result
                .ValidationResult.Should().Be(ArchiveFormatValidationResultType.Valid);

            Delete(diasTarArchive);
        }

        [Fact]
        public void ShouldInvalidateN5SipZipArchive()
        {
            DiasEntry[] diasEntries = DiasProvider.ProvideForFormat(ArchiveFormat.DiasSip).GetEntries();

            FileInfo diasTarArchive = CreateDiasTarArchive("testArchive.tar", diasEntries);

            ArchiveFormatValidationResult result =
                DiasValidator.ValidateAsync(diasTarArchive, ArchiveFormat.DiasSipN5).Result;

            result.ValidationResult.Should().Be(ArchiveFormatValidationResultType.Invalid);
            result.ValidationSummary().Should().Contain(Path.Combine(DirectoryNameContent, ArkivstrukturXmlFileName));

            Delete(diasTarArchive);
        }

        [Fact]
        public void ShouldReportInvalidButAcceptableDias()
        {
            DiasDirectory diasSource = DiasProvider.ProvideForFormat(ArchiveFormat.DiasSipN5);
            diasSource.DeleteEntry(ChangeLogXmlFileName, true);

            DiasEntry[] diasEntries = diasSource.GetEntries();
            FileInfo diasTarArchive = CreateDiasTarArchive("testArchive.tar", diasEntries);

            ArchiveFormatValidationResult result =
                DiasValidator.ValidateAsync(diasTarArchive, ArchiveFormat.DiasSipN5).Result;

            result.ValidationResult.Should().Be(ArchiveFormatValidationResultType.Invalid);
            result.IsAcceptable.Should().BeTrue();
            result.ValidationSummary().Should().Contain(Path.Combine(DirectoryNameContent, ChangeLogXmlFileName));

            Delete(diasTarArchive);
        }

        private static FileInfo CreateDiasTarArchive(string fileName, IEnumerable<DiasEntry> diasEntries)
        {
            var outputStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            using var tarOutputStream = new TarOutputStream(outputStream, Encoding.Latin1);

            CreateDiasTarArchiveEntries(diasEntries, Path.GetFileNameWithoutExtension(fileName), tarOutputStream);

            return new FileInfo(fileName);
        }

        private static void CreateDiasTarArchiveEntries(IEnumerable<DiasEntry> diasEntries, string path, TarOutputStream archive)
        {
            foreach (DiasEntry diasEntry in diasEntries)
            {
                var tarEntry = TarEntry.CreateTarEntry(Path.Join(path, diasEntry.Name));

                if (diasEntry is DiasDirectory diasSubDirectory)
                {
                    tarEntry.TarHeader.TypeFlag = TarHeader.LF_DIR;

                    string diasSubDirectoryPath = Path.Join(path, diasSubDirectory.Name);

                    CreateDiasTarArchiveEntries(diasSubDirectory.GetEntries(), diasSubDirectoryPath, archive);
                }

                archive.PutNextEntry(tarEntry);
                archive.CloseEntry();
            }
        }

        private static void Delete(FileSystemInfo item)
        {
            if (item is DirectoryInfo directory)
                directory.Delete(recursive: true);

            else item.Delete();

            if (item.Exists)
                throw new Exception("Unable to delete: " + item);
        }
    }
}
