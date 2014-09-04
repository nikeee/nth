using System;
using System.IO;

namespace NTH.IO
{
    public static class FileInfoEx
    {
        /// <summary>Gets the <see cref="T:System.IO.FileAttributes" /> of the file on the path.</summary>
        /// <returns>The <see cref="T:System.IO.FileAttributes" /> of the file on the path.</returns>
        /// <param name="file">The file.</param>
        /// <exception cref="T:System.NullReferenceException"><paramref name="file" />is null.</exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException"><paramref name="file" /> represents a file and is invalid, such as being on an unmapped drive, or the file cannot be found.</exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="file" /> represents a directory and is invalid, such as being on an unmapped drive, or the directory cannot be found.</exception>
        /// <exception cref="T:System.IO.IOException">This file is being used by another process.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static FileAttributes GetAttributes(this FileInfo file)
        {
            if (file == null)
                throw new NullReferenceException();
            return File.GetAttributes(file.FullName);
        }


        /// <summary>Sets the specified <see cref="T:System.IO.FileAttributes" /> of the file on the specified path.</summary>
        /// <param name="file">The file.</param>
        /// <param name="attributes">A bitwise combination of the enumeration values.</param>
        /// <exception cref="T:System.NullReferenceException"><paramref name="file" />is null.</exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive).</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file cannot be found.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException"><paramref name="file" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="file" /> specified a directory.-or- The caller does not have the required permission.</exception>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public static void GetAttributes(this FileInfo file, FileAttributes attributes)
        {
            if (file == null)
                throw new NullReferenceException();
            File.SetAttributes(file.FullName, attributes);
        }
    }
}
