using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StarterKitApp.Services.Interfaces;

namespace StarterKitApp.Services
{
    public sealed class FileService : IFilesService
    {
        public string InstallationPath => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public async Task<Stream> OpenForReadAsync(string path)
        {
            return await GetEmbeddedFileStreamAsync(GetType(), path);
        }


        private static async Task<Stream> GetEmbeddedFileStreamAsync(Type assemblyType, string fileName)
        {
            await Task.Yield();

            var manifestResourceNames = assemblyType.GetTypeInfo().Assembly
                .GetManifestResourceNames();
            var manifestName = manifestResourceNames
                .FirstOrDefault(n => n.EndsWith(fileName.Replace(" ", "_").Replace("\\", ".").Replace("/", "."), StringComparison.OrdinalIgnoreCase));

            if (manifestName == null)
            {
                throw new InvalidOperationException($"Failed to find resource [{fileName}]");
            }

            return assemblyType.GetTypeInfo().Assembly.GetManifestResourceStream(manifestName);
        }
    }
}
