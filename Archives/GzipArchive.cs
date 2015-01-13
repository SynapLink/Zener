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
using System.IO;
using System.IO.Compression;

namespace SynapLink.Zener.Archives
{
    /// <summary>
    /// Represents an RFC 1952 GZip archive file.
    /// </summary>
    public sealed class GzipArchive
        : Archive, IDisposable
    {
        private enum GzipFlags : byte
        {
            /// <summary>
            /// Whether the file is likely to
            /// contain ASCII text.
            /// </summary>
            AsciiText       = 0 << 0,
            /// <summary>
            /// Whether the archive contains a
            /// Gzip CRC-16 header checksum.
            /// </summary>
            Checksum        = 1 << 0,
            /// <summary>
            /// Whether the archive uses optional
            /// extra flags.
            /// </summary>
            OptionalExtras  = 1 << 1,
            /// <summary>
            /// Whether the archive contains an
            /// original file name for the file.
            /// </summary>
            OriginalName    = 1 << 2,
            /// <summary>
            /// Whether the archive contains a
            /// human-readable comment.
            /// </summary>
            Comment         = 1 << 3,
            Reserved        = 0xF0
        }
        private enum GzipCompression : byte
        {
            /// <summary>
            /// The DEFLATE compression method
            /// identifier.
            /// </summary>
            DEFLATE         = 0x08
        }
        private enum GzipOs : byte
        {
            /// <summary>
            /// The file is from a FAT file system, such
            /// as is used on MS-DOS, OS/2, or NT/Win32.
            /// </summary>
            FAT         = 0x00,
            /// <summary>
            /// The file is from an Amiga OS.
            /// </summary>
            Amiga       = 0x01,
            /// <summary>
            /// The file is from VMS or OpenVMS.
            /// </summary>
            VMS         = 0x02,
            /// <summary>
            /// The file is from a UNIX system.
            /// </summary>
            UNIX        = 0x03,
            /// <summary>
            /// The file is from a VM/CMS system.
            /// </summary>
            VMCMS       = 0x04,
            /// <summary>
            /// The file is from an Atari TOS system.
            /// </summary>
            AtariTOS    = 0x05,
            /// <summary>
            /// The file is from an HPFS filesystem,
            /// such as is used on OS/2 or NT.
            /// </summary>
            HPFS        = 0x06,
            /// <summary>
            /// The file is from a Macintosh system.
            /// </summary>
            Macintosh   = 0x07,
            /// <summary>
            /// The file is from a Z-System.
            /// </summary>
            ZSystem     = 0x08,
            /// <summary>
            /// The file is from a CP/M system.
            /// </summary>
            CPM         = 0x09,
            /// <summary>
            /// The file is from a TOPS-20 system.
            /// </summary>
            TOPS20      = 0x0A,
            /// <summary>
            /// The file is from an NTFS filesystem.
            /// </summary>
            NTFS        = 0x0B,
            /// <summary>
            /// The file is from a QDOS system.
            /// </summary>
            QDOS        = 0x0C,
            /// <summary>
            /// The file is from an Acorn RISCOS system.
            /// </summary>
            AcornRISCOS = 0x0D,
            /// <summary>
            /// The origin system is unknown.
            /// </summary>
            Unknown     = 0xFF
        }
        private enum GzipExtra : byte
        {
            /// <summary>
            /// The DEFLATE algorithm used slow compression.
            /// </summary>
            DeflateSlow     = 0x02,
            /// <summary>
            /// The DEFLATE algorithm used fast compression.
            /// </summary>
            DeflateFast     = 0x04
        }

        private const byte
            // Gzip header is minimally 10 bytes:
            // ID bytes, compression method identifier,
            // flags, modification time, extra flags, and
            // the OS identifier.
            HEADER_LEN_MIN  = 0x0A,
            HEADER_OFFSET   = 0x00,

            FLG_OFFSET      = 0x04,

            // The gzip magic number bytes. These are the first
            // two bytes within any gzip archive file.
            ID_1            = 0x1f,
            ID_1_OFFSET     = 0x00,
            ID_2            = 0x8b,
            ID_2_OFFSET     = 0x01,

            // Compression method identifier
            CM_OFFSET       = 0x03,
            // Modification time
            MTIME_OFFSET    = 0x05,
            // Optional extra flags
            XFL_OFFSET      = 0x09,
            // Operating system identifier
            OS_OFFSET       = 0x0A,
            // Optional extra length
            XLEN_OFFSET     = 0x0B
            ;
        private const string ISO_ENCODING = "ISO-8859-1";
        /// <summary>
        /// The encoding to use for file names and comments.
        /// </summary>
        private static readonly Encoding IsoEncoding;
        
        static GzipArchive()
        {
            IsoEncoding = Encoding.GetEncoding(ISO_ENCODING);
        }
        }

        public GzipArchive()
        {
            
        }
    }
}
