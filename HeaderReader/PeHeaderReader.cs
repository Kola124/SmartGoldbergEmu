/* Copyright (C) 2019 Nemirtingas
   This file is part of the HeaderReader

   The HeaderReader is free software; you can redistribute it and/or
   modify it under the terms of the GNU Lesser General Public
   License as published by the Free Software Foundation; either
   version 3 of the License, or (at your option) any later version.

   The HeaderReader is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
   Lesser General Public License for more details.

   You should have received a copy of the GNU Lesser General Public
   License along with the HeaderReader; if not, see
   <http://www.gnu.org/licenses/>.
 */
using System;
using System.Runtime.InteropServices;
using System.IO;
using OSUtility;

namespace HeaderReader
{
    /// <summary>
    /// Reads in the header information of the Portable Executable format.
    /// </summary>
    public class PeHeaderReader : ExecutableHeaderReader
    {
        #region File Header Structures

        public enum HeaderMagic : ushort
        {
            /// <summary>
            /// MZ
            /// </summary>
            IMAGE_DOS_SIGNATURE = 0x5A4D,
            /// <summary>
            /// NE
            /// </summary>
            IMAGE_OS2_SIGNATURE = 0x454E,
            /// <summary>
            /// LE
            /// </summary>
            IMAGE_OS2_SIGNATURE_LE = 0x454C,
            /// <summary>
            /// LE
            /// </summary>
            IMAGE_VXD_SIGNATURE = 0x454C,
        }

        public struct IMAGE_DOS_HEADER
        {      // DOS .EXE header
            public HeaderMagic e_magic;     // Magic number
            public UInt16      e_cblp;      // Bytes on last page of file
            public UInt16      e_cp;        // Pages in file
            public UInt16      e_crlc;      // Relocations
            public UInt16      e_cparhdr;   // Size of header in paragraphs
            public UInt16      e_minalloc;  // Minimum extra paragraphs needed
            public UInt16      e_maxalloc;  // Maximum extra paragraphs needed
            public UInt16      e_ss;        // Initial (relative) SS value
            public UInt16      e_sp;        // Initial SP value
            public UInt16      e_csum;      // Checksum
            public UInt16      e_ip;        // Initial IP value
            public UInt16      e_cs;        // Initial (relative) CS value
            public UInt16      e_lfarlc;    // File address of relocation table
            public UInt16      e_ovno;      // Overlay number
            public UInt16      e_res_0;     // Reserved words
            public UInt16      e_res_1;     // Reserved words
            public UInt16      e_res_2;     // Reserved words
            public UInt16      e_res_3;     // Reserved words
            public UInt16      e_oemid;     // OEM identifier (for e_oeminfo)
            public UInt16      e_oeminfo;   // OEM information; e_oemid specific
            public UInt16      e_res2_0;    // Reserved words
            public UInt16      e_res2_1;    // Reserved words
            public UInt16      e_res2_2;    // Reserved words
            public UInt16      e_res2_3;    // Reserved words
            public UInt16      e_res2_4;    // Reserved words
            public UInt16      e_res2_5;    // Reserved words
            public UInt16      e_res2_6;    // Reserved words
            public UInt16      e_res2_7;    // Reserved words
            public UInt16      e_res2_8;    // Reserved words
            public UInt16      e_res2_9;    // Reserved words
            public UInt32      e_lfanew;    // File address of new exe header
        }

        const int IMAGE_NUMBEROF_DIRECTORY_ENTRIES = 16;
        enum ImageDirectoryEntry
        {
            /// <summary>
            /// Export Directory
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_EXPORT         = 0,
            /// <summary>
            /// Import Directory
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_IMPORT         = 1,
            /// <summary>
            /// Resource Directory
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_RESOURCE       = 2,
            /// <summary>
            /// Exception Directory
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_EXCEPTION      = 3,
            /// <summary>
            /// Security Directory
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_SECURITY       = 4,
            /// <summary>
            /// Base Relocation Table
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_BASERELOC      = 5,
            /// <summary>
            /// Debug Directory
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_DEBUG          = 6,
            /// <summary>
            /// (X86 usage)
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_COPYRIGHT      = 7,
            /// <summary>
            /// Architecture Specific Data
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_ARCHITECTURE   = 7,
            /// <summary>
            /// RVA of GP
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_GLOBALPTR      = 8,
            /// <summary>
            /// TLS Directory
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_TLS            = 9,
            /// <summary>
            /// Load Configuration Directory
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG    = 10,
            /// <summary>
            /// Bound Import Directory in headers
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT   = 11,
            /// <summary>
            /// Import Address Table
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_IAT            = 12,
            /// <summary>
            /// Delay Load Import Descriptors
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT   = 13,
            /// <summary>
            /// COM Runtime descriptor
            /// </summary>
            IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR = 14,
        }

        public enum NTHeaderMagic : uint
        {
            /// <summary>
            /// PE00
            /// </summary>
            IMAGE_NT_SIGNATURE = 0x00004550,
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_NT_HEADERS32
        {
            public NTHeaderMagic Signature;
            public IMAGE_FILE_HEADER FileHeader;
            public IMAGE_OPTIONAL_HEADER32 OptionalHeader;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_NT_HEADERS64
        {
            public NTHeaderMagic Signature;
            public IMAGE_FILE_HEADER FileHeader;
            public IMAGE_OPTIONAL_HEADER64 OptionalHeader;
        }

        public enum OptionalHeaderMagic : ushort
        {
            IMAGE_NT_OPTIONAL_HDR32_MAGIC = 0x10b,
            IMAGE_NT_OPTIONAL_HDR64_MAGIC = 0x20b,
            IMAGE_ROM_OPTIONAL_HDR_MAGIC = 0x107,
        }

        public enum ImageSubsystem : ushort
        {
            /// <summary>
            /// Unknown subsystem.
            /// </summary>
            IMAGE_SUBSYSTEM_UNKNOWN = 0,
            /// <summary>
            /// Image doesn't require a subsystem.
            /// </summary>
            IMAGE_SUBSYSTEM_NATIVE = 1,
            /// <summary>
            /// Image runs in the Windows GUI subsystem.
            /// </summary>
            IMAGE_SUBSYSTEM_WINDOWS_GUI = 2,
            /// <summary>
            /// Image runs in the Windows character subsystem.
            /// </summary>
            IMAGE_SUBSYSTEM_WINDOWS_CUI = 3,
            /// <summary>
            /// image runs in the OS/2 character subsystem.
            /// </summary>
            IMAGE_SUBSYSTEM_OS2_CUI = 5,
            /// <summary>
            /// image runs in the Posix character subsystem.
            /// </summary>
            IMAGE_SUBSYSTEM_POSIX_CUI = 7,
            /// <summary>
            /// image is a native Win9x driver.
            /// </summary>
            IMAGE_SUBSYSTEM_NATIVE_WINDOWS = 8,
            /// <summary>
            /// Image runs in the Windows CE subsystem.
            /// </summary>
            IMAGE_SUBSYSTEM_WINDOWS_CE_GUI = 9,
            IMAGE_SUBSYSTEM_EFI_APPLICATION = 10,  //
            IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER = 11,  //
            IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER = 12,  //
            IMAGE_SUBSYSTEM_EFI_ROM = 13,
            IMAGE_SUBSYSTEM_XBOX = 14,
            IMAGE_SUBSYSTEM_WINDOWS_BOOT_APPLICATION = 16,
            IMAGE_SUBSYSTEM_XBOX_CODE_CATALOG = 17,
        }

        [Flags]
        public enum ImageDllCharacteristics : ushort
        {
            /// <summary>
            /// Reserved. IMAGE_LIBRARY_PROCESS_INIT
            /// </summary>
            RESERVED_1 = 0x0001,
            /// <summary>
            /// Reserved. IMAGE_LIBRARY_PROCESS_TERM
            /// </summary>
            RESERVED_2 = 0x0002,
            /// <summary>
            /// Reserved. IMAGE_LIBRARY_THREAD_INIT 
            /// </summary>
            RESERVED_4 = 0x0004,
            /// <summary>
            /// Reserved. IMAGE_LIBRARY_THREAD_TERM 
            /// </summary>
            RESERVED_8 = 0x0008,
            /// <summary>
            /// Image can handle a high entropy 64-bit virtual address space.
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_HIGH_ENTROPY_VA = 0x0020,
            /// <summary>
            /// DLL can move.
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE = 0x0040,
            /// <summary>
            /// Code Integrity Image
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY = 0x0080,
            /// <summary>
            /// Image is NX compatible
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_NX_COMPAT = 0x0100,
            /// <summary>
            /// Image understands isolation and doesn't want it
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_NO_ISOLATION = 0x0200,
            /// <summary>
            /// Image does not use SEH.  No SE handler may reside in this image
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_NO_SEH = 0x0400,
            /// <summary>
            /// Do not bind this image.
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_NO_BIND = 0x0800,
            /// <summary>
            /// Image should execute in an AppContainer
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_APPCONTAINER = 0x1000,
            /// <summary>
            /// Driver uses WDM model
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_WDM_DRIVER = 0x2000,
            /// <summary>
            /// Image supports Control Flow Guard.
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_GUARD_CF = 0x4000,
            IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE = 0x8000,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct IMAGE_DATA_DIRECTORY
        {
            public UInt32 VirtualAddress;
            public UInt32 Size;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_OPTIONAL_HEADER32
        {
            public OptionalHeaderMagic Magic;
            public Byte MajorLinkerVersion;
            public Byte MinorLinkerVersion;
            public UInt32 SizeOfCode;
            public UInt32 SizeOfInitializedData;
            public UInt32 SizeOfUninitializedData;
            public UInt32 AddressOfEntryPoint;
            public UInt32 BaseOfCode;
            public UInt32 BaseOfData;
            public UInt32 ImageBase;
            public UInt32 SectionAlignment;
            public UInt32 FileAlignment;
            public UInt16 MajorOperatingSystemVersion;
            public UInt16 MinorOperatingSystemVersion;
            public UInt16 MajorImageVersion;
            public UInt16 MinorImageVersion;
            public UInt16 MajorSubsystemVersion;
            public UInt16 MinorSubsystemVersion;
            public UInt32 Win32VersionValue;
            public UInt32 SizeOfImage;
            public UInt32 SizeOfHeaders;
            public UInt32 CheckSum;
            public ImageSubsystem Subsystem;
            public ImageDllCharacteristics DllCharacteristics;
            public UInt32 SizeOfStackReserve;
            public UInt32 SizeOfStackCommit;
            public UInt32 SizeOfHeapReserve;
            public UInt32 SizeOfHeapCommit;
            public UInt32 LoaderFlags;
            public UInt32 NumberOfRvaAndSizes;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = IMAGE_NUMBEROF_DIRECTORY_ENTRIES)]
            public IMAGE_DATA_DIRECTORY[] DataDirectory;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_OPTIONAL_HEADER64
        {
            public OptionalHeaderMagic Magic;
            public Byte MajorLinkerVersion;
            public Byte MinorLinkerVersion;
            public UInt32 SizeOfCode;
            public UInt32 SizeOfInitializedData;
            public UInt32 SizeOfUninitializedData;
            public UInt32 AddressOfEntryPoint;
            public UInt32 BaseOfCode;
            public UInt64 ImageBase;
            public UInt32 SectionAlignment;
            public UInt32 FileAlignment;
            public UInt16 MajorOperatingSystemVersion;
            public UInt16 MinorOperatingSystemVersion;
            public UInt16 MajorImageVersion;
            public UInt16 MinorImageVersion;
            public UInt16 MajorSubsystemVersion;
            public UInt16 MinorSubsystemVersion;
            public UInt32 Win32VersionValue;
            public UInt32 SizeOfImage;
            public UInt32 SizeOfHeaders;
            public UInt32 CheckSum;
            public ImageSubsystem Subsystem;
            public ImageDllCharacteristics DllCharacteristics;
            public UInt64 SizeOfStackReserve;
            public UInt64 SizeOfStackCommit;
            public UInt64 SizeOfHeapReserve;
            public UInt64 SizeOfHeapCommit;
            public UInt32 LoaderFlags;
            public UInt32 NumberOfRvaAndSizes;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = IMAGE_NUMBEROF_DIRECTORY_ENTRIES)]
            public IMAGE_DATA_DIRECTORY[] DataDirectory;
        }

        public enum ImageFileMachine : ushort
        {
            IMAGE_FILE_MACHINE_UNKNOWN     = 0,
            /// <summary>
            /// Useful for indicating we want to interact with the host and not a WoW guest.
            /// </summary>
            IMAGE_FILE_MACHINE_TARGET_HOST = 0x0001,
            /// <summary>
            /// Intel 386.
            /// </summary>
            IMAGE_FILE_MACHINE_I386        = 0x014c,
            /// <summary>
            /// MIPS little-endian, 0x160 big-endian
            /// </summary>
            IMAGE_FILE_MACHINE_R3000       = 0x0162,
            /// <summary>
            /// MIPS little-endian
            /// </summary>
            IMAGE_FILE_MACHINE_R4000       = 0x0166,
            /// <summary>
            /// MIPS little-endian
            /// </summary>
            IMAGE_FILE_MACHINE_R10000      = 0x0168,
            /// <summary>
            /// MIPS little-endian WCE v2
            /// </summary>
            IMAGE_FILE_MACHINE_WCEMIPSV2   = 0x0169,
            /// <summary>
            /// Alpha_AXP
            /// </summary>
            IMAGE_FILE_MACHINE_ALPHA       = 0x0184,
            /// <summary>
            /// SH3 little-endian
            /// </summary>
            IMAGE_FILE_MACHINE_SH3         = 0x01a2,
            IMAGE_FILE_MACHINE_SH3DSP      = 0x01a3,
            /// <summary>
            /// SH3E little-endian
            /// </summary>
            IMAGE_FILE_MACHINE_SH3E        = 0x01a4,
            /// <summary>
            /// SH4 little-endian
            /// </summary>
            IMAGE_FILE_MACHINE_SH4         = 0x01a6,
            /// <summary>
            /// SH5
            /// </summary>
            IMAGE_FILE_MACHINE_SH5         = 0x01a8,
            /// <summary>
            /// ARM Little-Endian
            /// </summary>
            IMAGE_FILE_MACHINE_ARM         = 0x01c0,
            /// <summary>
            /// ARM Thumb/Thumb-2 Little-Endian
            /// </summary>
            IMAGE_FILE_MACHINE_THUMB       = 0x01c2,
            /// <summary>
            /// ARM Thumb-2 Little-Endian
            /// </summary>
            IMAGE_FILE_MACHINE_ARMNT       = 0x01c4,
            IMAGE_FILE_MACHINE_AM33        = 0x01d3,
            /// <summary>
            /// IBM PowerPC Little-Endian
            /// </summary>
            IMAGE_FILE_MACHINE_POWERPC     = 0x01F0,
            IMAGE_FILE_MACHINE_POWERPCFP   = 0x01f1,
            /// <summary>
            /// Intel 64
            /// </summary>
            IMAGE_FILE_MACHINE_IA64        = 0x0200,
            /// <summary>
            /// MIPS
            /// </summary>
            IMAGE_FILE_MACHINE_MIPS16      = 0x0266,
            /// <summary>
            /// ALPHA64
            /// </summary>
            IMAGE_FILE_MACHINE_ALPHA64     = 0x0284,
            /// <summary>
            /// MIPS
            /// </summary>
            IMAGE_FILE_MACHINE_MIPSFPU     = 0x0366,
            /// <summary>
            /// MIPS
            /// </summary>
            IMAGE_FILE_MACHINE_MIPSFPU16   = 0x0466,
            IMAGE_FILE_MACHINE_AXP64       = IMAGE_FILE_MACHINE_ALPHA64,
            /// <summary>
            /// Infineon
            /// </summary>
            IMAGE_FILE_MACHINE_TRICORE     = 0x0520,
            IMAGE_FILE_MACHINE_CEF         = 0x0CEF,
            /// <summary>
            /// EFI Byte Code
            /// </summary>
            IMAGE_FILE_MACHINE_EBC         = 0x0EBC,
            /// <summary>
            /// AMD64 (K8)
            /// </summary>
            IMAGE_FILE_MACHINE_AMD64       = 0x8664,
            /// <summary>
            /// M32R little-endian
            /// </summary>
            IMAGE_FILE_MACHINE_M32R        = 0x9041,
            /// <summary>
            /// ARM64 Little-Endian
            /// </summary>
            IMAGE_FILE_MACHINE_ARM64       = 0xAA64,
            IMAGE_FILE_MACHINE_CEE         = 0xC0EE,
        }

        [Flags]
        public enum ImageFileFlags : ushort
        {
            /// <summary>
            /// Relocation info stripped from file.
            /// </summary>
            IMAGE_FILE_RELOCS_STRIPPED         = 0x0001,
            /// <summary>
            /// File is executable  (i.e. no unresolved external references).
            /// </summary>
            IMAGE_FILE_EXECUTABLE_IMAGE        = 0x0002,
            /// <summary>
            /// Line nunbers stripped from file.
            /// </summary>
            IMAGE_FILE_LINE_NUMS_STRIPPED = 0x0004,
            /// <summary>
            /// Local symbols stripped from file.
            /// </summary>
            IMAGE_FILE_LOCAL_SYMS_STRIPPED     = 0x0008,
            /// <summary>
            /// Aggressively trim working set
            /// </summary>
            IMAGE_FILE_AGGRESIVE_WS_TRIM       = 0x0010,
            /// <summary>
            /// App can handle >2gb addresses
            /// </summary>
            IMAGE_FILE_LARGE_ADDRESS_AWARE     = 0x0020,
            /// <summary>
            /// Bytes of machine word are reversed.
            /// </summary>
            IMAGE_FILE_BYTES_REVERSED_LO       = 0x0080,
            /// <summary>
            /// 32 bit word machine.
            /// </summary>
            IMAGE_FILE_32BIT_MACHINE           = 0x0100,
            /// <summary>
            /// Debugging info stripped from file in .DBG file
            /// </summary>
            IMAGE_FILE_DEBUG_STRIPPED          = 0x0200,
            /// <summary>
            /// If Image is on removable media, copy and run from the swap file.
            /// </summary>
            IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP = 0x0400,
            /// <summary>
            /// If Image is on Net, copy and run from the swap file.
            /// </summary>
            IMAGE_FILE_NET_RUN_FROM_SWAP       = 0x0800,
            /// <summary>
            /// System File.
            /// </summary>
            IMAGE_FILE_SYSTEM                  = 0x1000,
            /// <summary>
            /// File is a DLL.
            /// </summary>
            IMAGE_FILE_DLL                     = 0x2000,
            /// <summary>
            /// File should only be run on a UP machine
            /// </summary>
            IMAGE_FILE_UP_SYSTEM_ONLY          = 0x4000,
            /// <summary>
            /// Bytes of machine word are reversed.
            /// </summary>
            IMAGE_FILE_BYTES_REVERSED_HI       = 0x8000,
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_FILE_HEADER
        {
            public ImageFileMachine Machine;
            public UInt16           NumberOfSections;
            public UInt32           TimeDateStamp;
            public UInt32           PointerToSymbolTable;
            public UInt32           NumberOfSymbols;
            public UInt16           SizeOfOptionalHeader;
            public ImageFileFlags   Characteristics;
        }

        const int IMAGE_SIZEOF_SHORT_NAME = 8;

        [Flags]
        public enum DataSectionFlags : uint
        {
            /// <summary>
            /// Reserved for future use.
            /// </summary>
            TypeReg = 0x00000000,
            /// <summary>
            /// Reserved for future use.
            /// </summary>
            TypeDsect = 0x00000001,
            /// <summary>
            /// Reserved for future use.
            /// </summary>
            TypeNoLoad = 0x00000002,
            /// <summary>
            /// Reserved for future use.
            /// </summary>
            TypeGroup = 0x00000004,
            /// <summary>
            /// The section should not be padded to the next boundary. This flag is obsolete and is replaced by IMAGE_SCN_ALIGN_1BYTES. This is valid only for object files.
            /// </summary>
            TypeNoPadded = 0x00000008,
            /// <summary>
            /// Reserved for future use.
            /// </summary>
            TypeCopy = 0x00000010,
            /// <summary>
            /// The section contains executable code.
            /// </summary>
            ContentCode = 0x00000020,
            /// <summary>
            /// The section contains initialized data.
            /// </summary>
            ContentInitializedData = 0x00000040,
            /// <summary>
            /// The section contains uninitialized data.
            /// </summary>
            ContentUninitializedData = 0x00000080,
            /// <summary>
            /// Reserved for future use.
            /// </summary>
            LinkOther = 0x00000100,
            /// <summary>
            /// The section contains comments or other information. The .drectve section has this type. This is valid for object files only.
            /// </summary>
            LinkInfo = 0x00000200,
            /// <summary>
            /// Reserved for future use.
            /// </summary>
            TypeOver = 0x00000400,
            /// <summary>
            /// The section will not become part of the image. This is valid only for object files.
            /// </summary>
            LinkRemove = 0x00000800,
            /// <summary>
            /// The section contains COMDAT data. For more information, see section 5.5.6, COMDAT Sections (Object Only). This is valid only for object files.
            /// </summary>
            LinkComDat = 0x00001000,
            /// <summary>
            /// Reset speculative exceptions handling bits in the TLB entries for this section.
            /// </summary>
            NoDeferSpecExceptions = 0x00004000,
            /// <summary>
            /// The section contains data referenced through the global pointer (GP).
            /// </summary>
            RelativeGP = 0x00008000,
            /// <summary>
            /// Reserved for future use.
            /// </summary>
            MemPurgeable = 0x00020000,
            /// <summary>
            /// Reserved for future use.
            /// </summary>
            Memory16Bit = 0x00020000,
            /// <summary>
            /// Reserved for future use.
            /// </summary>
            MemoryLocked = 0x00040000,
            /// <summary>
            /// Reserved for future use.
            /// </summary>
            MemoryPreload = 0x00080000,
            /// <summary>
            /// Align data on a 1-byte boundary. Valid only for object files.
            /// </summary>
            Align1Bytes = 0x00100000,
            /// <summary>
            /// Align data on a 2-byte boundary. Valid only for object files.
            /// </summary>
            Align2Bytes = 0x00200000,
            /// <summary>
            /// Align data on a 4-byte boundary. Valid only for object files.
            /// </summary>
            Align4Bytes = 0x00300000,
            /// <summary>
            /// Align data on an 8-byte boundary. Valid only for object files.
            /// </summary>
            Align8Bytes = 0x00400000,
            /// <summary>
            /// Align data on a 16-byte boundary. Valid only for object files.
            /// </summary>
            Align16Bytes = 0x00500000,
            /// <summary>
            /// Align data on a 32-byte boundary. Valid only for object files.
            /// </summary>
            Align32Bytes = 0x00600000,
            /// <summary>
            /// Align data on a 64-byte boundary. Valid only for object files.
            /// </summary>
            Align64Bytes = 0x00700000,
            /// <summary>
            /// Align data on a 128-byte boundary. Valid only for object files.
            /// </summary>
            Align128Bytes = 0x00800000,
            /// <summary>
            /// Align data on a 256-byte boundary. Valid only for object files.
            /// </summary>
            Align256Bytes = 0x00900000,
            /// <summary>
            /// Align data on a 512-byte boundary. Valid only for object files.
            /// </summary>
            Align512Bytes = 0x00A00000,
            /// <summary>
            /// Align data on a 1024-byte boundary. Valid only for object files.
            /// </summary>
            Align1024Bytes = 0x00B00000,
            /// <summary>
            /// Align data on a 2048-byte boundary. Valid only for object files.
            /// </summary>
            Align2048Bytes = 0x00C00000,
            /// <summary>
            /// Align data on a 4096-byte boundary. Valid only for object files.
            /// </summary>
            Align4096Bytes = 0x00D00000,
            /// <summary>
            /// Align data on an 8192-byte boundary. Valid only for object files.
            /// </summary>
            Align8192Bytes = 0x00E00000,
            /// <summary>
            /// The section contains extended relocations.
            /// </summary>
            LinkExtendedRelocationOverflow = 0x01000000,
            /// <summary>
            /// The section can be discarded as needed.
            /// </summary>
            MemoryDiscardable = 0x02000000,
            /// <summary>
            /// The section cannot be cached.
            /// </summary>
            MemoryNotCached = 0x04000000,
            /// <summary>
            /// The section is not pageable.
            /// </summary>
            MemoryNotPaged = 0x08000000,
            /// <summary>
            /// The section can be shared in memory.
            /// </summary>
            MemoryShared = 0x10000000,
            /// <summary>
            /// The section can be executed as code.
            /// </summary>
            MemoryExecute = 0x20000000,
            /// <summary>
            /// The section can be read.
            /// </summary>
            MemoryRead = 0x40000000,
            /// <summary>
            /// The section can be written to.
            /// </summary>
            MemoryWrite = 0x80000000
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IMAGE_SECTION_HEADER
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = IMAGE_SIZEOF_SHORT_NAME)]
            public char[] Name;
            public UInt32 VirtualSize;
            public UInt32 VirtualAddress;
            public UInt32 SizeOfRawData;
            public UInt32 PointerToRawData;
            public UInt32 PointerToRelocations;
            public UInt32 PointerToLinenumbers;
            public UInt16 NumberOfRelocations;
            public UInt16 NumberOfLinenumbers;
            public DataSectionFlags Characteristics;
        }

        #endregion File Header Structures

        #region Private Fields

        /// <summary>
        /// The DOS header
        /// </summary>
        private IMAGE_DOS_HEADER dosHeader;
        /// <summary>
        /// NT 32 bit file header 
        /// </summary>
        private IMAGE_NT_HEADERS32 ntHeader32;
        /// <summary>
        /// NT 64 bit file header 
        /// </summary>
        private IMAGE_NT_HEADERS64 ntHeader64;
        /// <summary>
        /// Image Section headers. Number of sections is in the file header.
        /// </summary>
        private IMAGE_SECTION_HEADER[] imageSectionHeaders;

        #endregion Private Fields

        #region Public Methods

        public PeHeaderReader()
        { }

        public PeHeaderReader(string filePath)
        {
            Parse(filePath);
        }

        public override void Parse(string filePath)
        {
            _TargetOS = OsId.Unknown;
            _ExecutableType = ExecutableType.Unknown;

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return;

            using (FileStream stream = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                BinaryReader reader = new BinaryReader(stream);

                dosHeader = FromBinaryReader<IMAGE_DOS_HEADER>(reader);
                if (dosHeader.e_magic == HeaderMagic.IMAGE_DOS_SIGNATURE)
                {
                    stream.Seek(dosHeader.e_lfanew, SeekOrigin.Begin);
                    NTHeaderMagic ntHeaderMagic = FromBinaryReader<NTHeaderMagic>(reader);
                    IMAGE_FILE_HEADER fileHeader = FromBinaryReader<IMAGE_FILE_HEADER>(reader);

                    if (ntHeaderMagic == NTHeaderMagic.IMAGE_NT_SIGNATURE)
                    {
                        int numberOfSections = 0;
                        stream.Seek(dosHeader.e_lfanew, SeekOrigin.Begin);
                        if ((ImageFileFlags.IMAGE_FILE_32BIT_MACHINE & fileHeader.Characteristics) == ImageFileFlags.IMAGE_FILE_32BIT_MACHINE)
                        {
                            ntHeader32 = FromBinaryReader<IMAGE_NT_HEADERS32>(reader);
                            if (ntHeader32.OptionalHeader.Magic == OptionalHeaderMagic.IMAGE_NT_OPTIONAL_HDR32_MAGIC)
                            {
                                numberOfSections = ntHeader32.FileHeader.NumberOfSections;

                                if ((ntHeader32.FileHeader.Characteristics & ImageFileFlags.IMAGE_FILE_DLL) == ImageFileFlags.IMAGE_FILE_DLL)
                                    _ExecutableType = ExecutableType.Library;
                                else
                                {
                                    if ((ntHeader32.FileHeader.Characteristics & ImageFileFlags.IMAGE_FILE_EXECUTABLE_IMAGE) == ImageFileFlags.IMAGE_FILE_EXECUTABLE_IMAGE)
                                        _ExecutableType = ExecutableType.Executable;
                                    else
                                    {
                                        _ExecutableType = ExecutableType.Unknown;
                                    }
                                }

                                _IsValidHeader = true;
                                _Is32BitHeader = true;
                                _TargetOS = OsId.Windows;
                            }
                        }
                        else
                        {
                            ntHeader64 = FromBinaryReader<IMAGE_NT_HEADERS64>(reader);
                            if (ntHeader64.OptionalHeader.Magic == OptionalHeaderMagic.IMAGE_NT_OPTIONAL_HDR64_MAGIC)
                            {
                                numberOfSections = ntHeader64.FileHeader.NumberOfSections;

                                if ((ntHeader64.FileHeader.Characteristics & ImageFileFlags.IMAGE_FILE_DLL) == ImageFileFlags.IMAGE_FILE_DLL)
                                    _ExecutableType = ExecutableType.Library;
                                else
                                {
                                    if ((ntHeader64.FileHeader.Characteristics & ImageFileFlags.IMAGE_FILE_EXECUTABLE_IMAGE) == ImageFileFlags.IMAGE_FILE_EXECUTABLE_IMAGE)
                                        _ExecutableType = ExecutableType.Executable;
                                    else
                                    {
                                        _ExecutableType = ExecutableType.Unknown;
                                    }
                                }

                                _IsValidHeader = true;
                                _Is32BitHeader = false;
                                _TargetOS = OsId.Windows;
                            }
                        }

                        if (IsValidHeader)
                        {
                            imageSectionHeaders = new IMAGE_SECTION_HEADER[numberOfSections];
                            for (int i = 0; i < imageSectionHeaders.Length; ++i)
                            {
                                imageSectionHeaders[i] = FromBinaryReader<IMAGE_SECTION_HEADER>(reader);
                            }
                        }
                    }
                }
            }
        }

        #endregion Public Methods

        #region Properties

        /// <summary>
        /// Gets the file dos header
        /// </summary>
        public IMAGE_DOS_HEADER DosHeader
        {
            get
            {
                return dosHeader;
            }
        }

        /// <summary>
        /// Gets the optional header
        /// </summary>
        public IMAGE_NT_HEADERS32 NtHeader32
        {
            get
            {
                return ntHeader32;
            }
        }

        /// <summary>
        /// Gets the optional header
        /// </summary>
        public IMAGE_NT_HEADERS64 NtHeader64
        {
            get
            {
                return ntHeader64;
            }
        }

        public IMAGE_SECTION_HEADER[] ImageSectionHeaders
        {
            get
            {
                return imageSectionHeaders;
            }
        }

        #endregion Properties
    }
}