﻿/*
 *      Copyright (c) 2014-2015, SynapLink, LLC
 *      All Rights reserved.
 *      
 *      Released under BSD 3-Clause licence. See terms in
 *      /LICENCE, or online: http://opensource.org/licenses/BSD-3-Clause
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynapLink.Zener.Archives
{
    /// <summary>
    /// Defines the interface for working with archive files.
    /// </summary>
    public abstract class Archive 
        : IDisposable
    {
        /// <summary>
        /// The number of files in the archive.
        /// </summary>
        public abstract int Count { get; }
        /// <summary>
        /// The names of the files in the archive.
        /// </summary>
        public abstract IEnumerable<string> Files { get; }

        /// <summary>
        /// Retrieves a file from the archive based on its name.
        /// </summary>
        /// <param name="name">The name of the file to retrieve.</param>
        /// <param name="contents">An enumerable containing the file's contents.</param>
        /// <returns>True if a file with the given name exists within the archive.</returns>
        public abstract bool GetFile(string name, out IEnumerable<byte> contents);
        /// <summary>
        /// Retrieves a file from the archive based on its name, and
        /// returns it after converting it to a string with the specified
        /// encoding.
        /// </summary>
        /// <param name="name">The name of the file to retrieve.</param>
        /// <param name="encoding">The encoding to apply to the file.</param>
        /// <param name="str">
        ///     A string containing the file's contents with <paramref name="encoding"/>
        ///     applied to the bytes.
        /// </param>
        /// <returns>True if a file with the given name exists within the archive.</returns>
        public virtual bool GetFile(string name, Encoding encoding, out string str)
        {
            IEnumerable<byte> file;
            bool success = this.GetFile(name, out file);

            if (success)
            {
                str = encoding.GetString(file.ToArray());
            }
            else str = null;

            return success;
        }
        /// <summary>
        /// Releases any resources in use by the class.
        /// </summary>
        public abstract void Dispose();
    }
}
