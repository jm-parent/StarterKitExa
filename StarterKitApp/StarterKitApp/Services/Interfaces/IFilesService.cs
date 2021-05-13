using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StarterKitApp.Services.Interfaces
{
    public interface IFilesService
    {
        /// <summary>
        /// Gets the path of the installation directory.
        /// </summary>
        string InstallationPath { get; }

        /// <summary>
        /// Gets a readonly <see cref="Stream"/> for a file at a specified path.
        /// </summary>
        /// <param name="path">The path of the file to retrieve.</param>
        /// <returns>The <see cref="Stream"/> for the specified file.</returns>
        Task<Stream> OpenForReadAsync(string path);
    }
}
