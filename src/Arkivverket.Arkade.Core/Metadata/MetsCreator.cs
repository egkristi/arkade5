using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Arkivverket.Arkade.Core.Base;
using Arkivverket.Arkade.Core.ExternalModels.DiasMets;
using Arkivverket.Arkade.Core.Util;

namespace Arkivverket.Arkade.Core.Metadata
{
    public abstract class MetsCreator<T>
    {
        protected const string DateFormat = "yyyy-MM-dd";

        protected static XmlSerializerNamespaces SetupNamespaces()
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("mets", "http://www.loc.gov/METS/");
            namespaces.Add("xlink", "http://www.w3.org/1999/xlink");
            namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            return namespaces;
        }

        protected static void CreateStructMap(dynamic mets)
        {
            mets.structMap = new[] { new structMapType { div = new divType() } };
        }

        protected List<FileDescription> GetFileDescriptions(DirectoryInfo directory,
            DirectoryInfo pathRoot, string[] directoriesToSkip = null, string[] filesToSkip = null)
        {
            var fileDescriptions = new List<FileDescription>();

            foreach (FileInfo file in GetFilesToDescribe(directory, directoriesToSkip, filesToSkip))
                fileDescriptions.Add(GetFileDescription(file, pathRoot));

            return fileDescriptions;
        }

        protected FileDescription GetFileDescription(FileInfo file, DirectoryInfo pathRoot)
        {
            string name = pathRoot != null ? Path.GetRelativePath(pathRoot.FullName, file.FullName) : file.FullName;

            return new FileDescription
            {
                Name = name,
                Extension = file.Extension,
                Sha256Checksum = GetSha256Checksum(file),
                Size = file.Length,
                ModifiedTime = file.LastWriteTime
            };
        }

        private static IEnumerable<FileInfo> GetFilesToDescribe(DirectoryInfo directory, string[] directoriesToSkip, string[] filesToSkip)
        {
            IEnumerable<FileInfo> filesToDescribe = directory.EnumerateFiles(".", SearchOption.TopDirectoryOnly);

            if (filesToSkip != null)
                filesToDescribe = filesToDescribe.Where(f => !filesToSkip.Contains(f.Name));

            foreach (DirectoryInfo subDirectory in directory.EnumerateDirectories())
            {
                if (directoriesToSkip?.Contains(subDirectory.Name) == true)
                    continue;

                var filesInSubDirectory = GetFilesToDescribe(subDirectory, directoriesToSkip, filesToSkip);
                filesToDescribe = filesToDescribe.Concat(filesInSubDirectory);
            }

            return filesToDescribe;
        }

        protected static void AutoIncrementFileIds(IEnumerable<FileDescription> fileDescriptions, int offset = 0)
        {
            int nextFileId = offset;
            foreach (FileDescription fileDescription in fileDescriptions)
                fileDescription.Id = nextFileId++;
        }

        private static string GetSha256Checksum(FileInfo file)
        {
            return new Sha256ChecksumGenerator().GenerateChecksum(file.FullName);
        }

        protected static bool HasEntity(MetadataEntityInformationUnit entityInformationUnit)
        {
            return !string.IsNullOrEmpty(entityInformationUnit.Entity);
        }

        protected static bool HasContactData(MetadataEntityInformationUnit entityInformationUnit)
        {
            return !string.IsNullOrEmpty(entityInformationUnit.ContactPerson) ||
                   !string.IsNullOrEmpty(entityInformationUnit.Address) ||
                   !string.IsNullOrEmpty(entityInformationUnit.Telephone) ||
                   !string.IsNullOrEmpty(entityInformationUnit.Email);
        }
    }
}
