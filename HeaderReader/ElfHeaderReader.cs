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
    /// Reads in the header information of the Elf format.
    /// </summary>
    public class ElfHeaderReader : ExecutableHeaderReader
    {
        #region File Header Structures

        const int EI_NIDENT = 16;
        public enum ElfIdent
        {
            /// <summary>
            /// File identification index
            /// </summary>
            EI_MAGIC = 0,
            /// <summary>
            /// File class byte index
            /// </summary>
            EI_CLASS = 4,
            /// <summary>
            /// Data encoding byte index
            /// </summary>
            EI_DATA = 5,
            /// <summary>
            /// File version byte index
            /// Value must be EV_CURRENT
            /// </summary>
            EI_VERSION = 6,
            /// <summary>
            /// OS ABI identification
            /// </summary>
            EI_OSABI = 7,
            /// <summary>
            /// ABI version
            /// </summary>
            EI_ABIVERSION = 8,
            /// <summary>
            /// Byte index of padding bytes
            /// </summary>
            EI_PAD = 9,
        }

        /// <summary>
        /// Valid Values for e_ident[EI_MAGIC]
        /// </summary>
        public enum HeaderMagic : uint
        {
            /// <summary>
            /// \x7fELF
            /// </summary>
            ELFMAGINT = 0x464C457F,
        }

        /// <summary>
        /// Valid Values for e_ident[EI_CLASS]
        /// </summary>
        public enum ElfClass : byte
        {
            /// <summary>
            /// Invalid class
            /// </summary>
            ELFCLASSNONE = 0,
            /// <summary>
            /// 32-bit objects
            /// </summary>
            ELFCLASS32 = 1,
            /// <summary>
            /// 64-bit objects
            /// </summary>
            ELFCLASS64 = 2,
            ELFCLASSNUM  = 3,
        }

        /// <summary>
        /// Valid Values for e_ident[EI_DATA]
        /// </summary>
        public enum ElfData : byte
        {
            /// <summary>
            /// Invalid data encoding
            /// </summary>
            ELFDATANONE = 0,
            /// <summary>
            /// 2's complement, little endian
            /// </summary>
            ELFDATA2LSB = 1,
            /// <summary>
            /// 2's complement, big endian
            /// </summary>
            ELFDATA2MSB = 2,
            ELFDATANUM  = 3,
        }

        // Valid Values for e_ident[EI_VERSION] and e_version
        // See enum ElfVersion

        /// <summary>
        /// Valid Values for e_ident[EI_OSABI]
        /// </summary>
        public enum ElfOSABI : byte
        {
            /// <summary>
            /// UNIX System V ABI
            /// </summary>
            ELFOSABI_NONE       = 0,
            /// <summary>
            /// Alias.
            /// </summary>
            ELFOSABI_SYSV       = 0,
            /// <summary>
            /// HP-UX
            /// </summary>
            ELFOSABI_HPUX       = 1,
            /// <summary>
            /// NetBSD.
            /// </summary>
            ELFOSABI_NETBSD     = 2,
            /// <summary>
            /// Object uses GNU ELF extensions.
            /// </summary>
            ELFOSABI_GNU        = 3,
            /// <summary>
            /// Compatibility alias.
            /// </summary>
            ELFOSABI_LINUX      = ELFOSABI_GNU,
            /// <summary>
            /// Sun Solaris.
            /// </summary>
            ELFOSABI_SOLARIS    = 6,
            /// <summary>
            /// IBM AIX.
            /// </summary>
            ELFOSABI_AIX        = 7,
            /// <summary>
            ///  SGI Irix.
            /// </summary>
            ELFOSABI_IRIX       = 8,
            /// <summary>
            ///  FreeBSD.
            /// </summary>
            ELFOSABI_FREEBSD    = 9,
            /// <summary>
            /// Compaq TRU64 UNIX.
            /// </summary>
            ELFOSABI_TRU64      = 10,
            /// <summary>
            /// Novell Modesto.
            /// </summary>
            ELFOSABI_MODESTO    = 11,
            /// <summary>
            /// OpenBSD.
            /// </summary>
            ELFOSABI_OPENBSD    = 12,
            /// <summary>
            /// ARM EABI
            /// </summary>
            ELFOSABI_ARM_AEABI  = 64,
            /// <summary>
            /// ARM
            /// </summary>
            ELFOSABI_ARM        = 97,
            /// <summary>
            /// Standalone (embedded) application
            /// </summary>
            ELFOSABI_STANDALONE = 255,
        }

        /// <summary>
        /// Valid Values for e_type
        /// </summary>
        public enum ElfType : ushort
        {
            /// <summary>
            /// No file type
            /// </summary>
            ET_NONE   = 0,
            /// <summary>
            /// Relocatable file
            /// </summary>
            ET_REL    = 1,
            /// <summary>
            /// Executable file
            /// </summary>
            ET_EXEC   = 2,
            /// <summary>
            /// Shared object file
            /// </summary>
            ET_DYN    = 3,
            /// <summary>
            /// Core file
            /// </summary>
            ET_CORE   = 4,
            /// <summary>
            /// Number of defined types
            /// </summary>
            ET_NUM    = 5,
            /// <summary>
            /// OS-specific range start
            /// </summary>
            ET_LOOS   = 0xfe00,
            /// <summary>
            /// OS-specific range end
            /// </summary>
            ET_HIOS   = 0xfeff,
            /// <summary>
            /// Processor-specific range start
            /// </summary>
            ET_LOPROC = 0xff00,
            /// <summary>
            /// Processor-specific range end
            /// </summary>
            ET_HIPROC = 0xffff,
        }

        /// <summary>
        /// Valid Values for e_machine
        /// </summary>
        public enum ElfMachine : ushort
        {
            /// <summary>
            /// No machine
            /// </summary>
            EM_NONE        = 0,
            /// <summary>
            /// AT&T WE 32100
            /// </summary>
            EM_M32         = 1,
            /// <summary>
            /// SUN SPARC
            /// </summary>
            EM_SPARC       = 2,
            /// <summary>
            /// Intel 80386
            /// </summary>
            EM_386         = 3,
            /// <summary>
            /// Motorola m68k family
            /// </summary>
            EM_68K         = 4,
            /// <summary>
            /// Motorola m88k family
            /// </summary>
            EM_88K         = 5,
            /// <summary>
            /// Intel 80860
            /// </summary>
            EM_860         = 7,
            /// <summary>
            /// MIPS R3000 big-endian
            /// </summary>
            EM_MIPS        = 8,
            /// <summary>
            /// IBM System/370
            /// </summary>
            EM_S370        = 9,
            /// <summary>
            /// MIPS R3000 little-endian
            /// </summary>
            EM_MIPS_RS3_LE = 10,
            /// <summary>
            /// HPPA
            /// </summary>
            EM_PARISC      = 15,
            /// <summary>
            /// Fujitsu VPP500
            /// </summary>
            EM_VPP500      = 17,
            /// <summary>
            // Sun's "v8plus"
            /// </summary>
            EM_SPARC32PLUS = 18,
            /// <summary>
            /// Intel 80960
            /// </summary>
            EM_960         = 19,
            /// <summary>
            /// PowerPC
            /// </summary>
            EM_PPC         = 20,
            /// <summary>
            /// PowerPC 64-bit
            /// </summary>
            EM_PPC64       = 21,
            /// <summary>
            /// IBM S390
            /// </summary>
            EM_S390        = 22,
            
            /// <summary>
            /// NEC V800 series
            /// </summary>
            EM_V800        = 36,
            /// <summary>
            /// Fujitsu FR20
            /// </summary>
            EM_FR20        = 37,
            /// <summary>
            /// TRW RH-32
            /// </summary>
            EM_RH32        = 38,
            /// <summary>
            /// Motorola RCE
            /// </summary>
            EM_RCE         = 39,
            /// <summary>
            /// ARM
            /// </summary>
            EM_ARM         = 40,
            /// <summary>
            /// Digital Alpha
            /// </summary>
            EM_FAKE_ALPHA  = 41,
            /// <summary>
            /// Hitachi SH
            /// </summary>
            EM_SH          = 42,
            /// <summary>
            /// SPARC v9 64-bit
            /// </summary>
            EM_SPARCV9     = 43,
            /// <summary>
            /// Siemens Tricore
            /// </summary>
            EM_TRICORE     = 44,
            /// <summary>
            /// Argonaut RISC Core
            /// </summary>
            EM_ARC         = 45,
            /// <summary>
            /// Hitachi H8/300
            /// </summary>
            EM_H8_300      = 46,
            /// <summary>
            /// Hitachi H8/300H
            /// </summary>
            EM_H8_300H     = 47,
            /// <summary>
            /// Hitachi H8S
            /// </summary>
            EM_H8S         = 48,
            /// <summary>
            /// Hitachi H8/500
            /// </summary>
            EM_H8_500      = 49,
            /// <summary>
            /// Intel Merced
            /// </summary>
            EM_IA_64       = 50,
            /// <summary>
            /// Stanford MIPS-X
            /// </summary>
            EM_MIPS_X      = 51,
            /// <summary>
            /// Motorola Coldfire
            /// </summary>
            EM_COLDFIRE    = 52,
            /// <summary>
            /// Motorola M68HC12
            /// </summary>
            EM_68HC12      = 53,
            /// <summary>
            /// Fujitsu MMA Multimedia Accelerator
            /// </summary>
            EM_MMA         = 54,
            /// <summary>
            /// Siemens PCP
            /// </summary>
            EM_PCP         = 55,
            /// <summary>
            /// Sony nCPU embeeded RISC
            /// </summary>
            EM_NCPU        = 56,
            /// <summary>
            /// Denso NDR1 microprocessor
            /// </summary>
            EM_NDR1        = 57,
            /// <summary>
            /// Motorola Start*Core processor
            /// </summary>
            EM_STARCORE    = 58,
            /// <summary>
            /// Toyota ME16 processor
            /// </summary>
            EM_ME16        = 59,
            /// <summary>
            /// STMicroelectronic ST100 processor
            /// </summary>
            EM_ST100       = 60,
            /// <summary>
            /// Advanced Logic Corp. Tinyj emb.fa
            /// </summary>
            EM_TINYJ       = 61,
            /// <summary>
            /// AMD x86-64 architecture
            /// </summary>
            EM_X86_64      = 62,
            /// <summary>
            /// Sony DSP Processor
            /// </summary>
            EM_PDSP        = 63,
            
            /// <summary>
            /// Siemens FX66 microcontroller
            /// </summary>
            EM_FX66       = 66,
            /// <summary>
            /// STMicroelectronics ST9+ 8/16 mc
            /// </summary>
            EM_ST9PLUS    = 67,
            /// <summary>
            /// STmicroelectronics ST7 8 bit mc
            /// </summary>
            EM_ST7        = 68,
            /// <summary>
            /// Motorola MC68HC16 microcontroller
            /// </summary>
            EM_68HC16     = 69,
            /// <summary>
            /// Motorola MC68HC11 microcontroller
            /// </summary>
            EM_68HC11     = 70,
            /// <summary>
            /// Motorola MC68HC08 microcontroller
            /// </summary>
            EM_68HC08     = 71,
            /// <summary>
            /// Motorola MC68HC05 microcontroller
            /// </summary>
            EM_68HC05     = 72,
            /// <summary>
            /// Silicon Graphics SVx
            /// </summary>
            EM_SVX        = 73,
            /// <summary>
            /// STMicroelectronics ST19 8 bit mc
            /// </summary>
            EM_ST19       = 74,
            /// <summary>
            /// Digital VAX
            /// </summary>
            EM_VAX        = 75,
            /// <summary>
            /// Axis Communications 32-bit embedded processor
            /// </summary>
            EM_CRIS       = 76,
            /// <summary>
            /// Infineon Technologies 32-bit embedded processor
            /// </summary>
            EM_JAVELIN    = 77,
            /// <summary>
            /// Element 14 64-bit DSP Processor
            /// </summary>
            EM_FIREPATH   = 78,
            /// <summary>
            /// LSI Logic 16-bit DSP Processor
            /// </summary>
            EM_ZSP        = 79,
            /// <summary>
            /// Donald Knuth's educational 64-bit processor
            /// </summary>
            EM_MMIX       = 80,
            /// <summary>
            /// Harvard University machine-independent object files
            /// </summary>
            EM_HUANY      = 81,
            /// <summary>
            /// SiTera Prism
            /// </summary>
            EM_PRISM      = 82,
            /// <summary>
            /// Atmel AVR 8-bit microcontroller
            /// </summary>
            EM_AVR        = 83,
            /// <summary>
            /// Fujitsu FR30
            /// </summary>
            EM_FR30       = 84,
            /// <summary>
            /// Mitsubishi D10V
            /// </summary>
            EM_D10V       = 85,
            /// <summary>
            /// Mitsubishi D30V
            /// </summary>
            EM_D30V       = 86,
            /// <summary>
            /// NEC v850
            /// </summary>
            EM_V850       = 87,
            /// <summary>
            /// Mitsubishi M32R
            /// </summary>
            EM_M32R       = 88,
            /// <summary>
            /// Matsushita MN10300
            /// </summary>
            EM_MN10300    = 89,
            /// <summary>
            /// Matsushita MN10200
            /// </summary>
            EM_MN10200    = 90,
            /// <summary>
            /// picoJava
            /// </summary>
            EM_PJ         = 91,
            /// <summary>
            /// OpenRISC 32-bit embedded processor
            /// </summary>
            EM_OPENRISC   = 92,
            /// <summary>
            /// ARC Cores Tangent-A5
            /// </summary>
            EM_ARC_A5     = 93,
            /// <summary>
            /// Tensilica Xtensa Architecture
            /// </summary>
            EM_XTENSA     = 94,
            /// <summary>
            /// ARM AARCH64
            /// </summary>
            EM_AARCH64    = 183,
            /// <summary>
            /// Tilera TILEPro
            /// </summary>
            EM_TILEPRO    = 188,
            /// <summary>
            /// Xilinx MicroBlaze
            /// </summary>
            EM_MICROBLAZE = 189,
            /// <summary>
            /// Tilera TILE-Gx
            /// </summary>
            EM_TILEGX     = 191,
            EM_NUM        = 192, 
            EM_ALPHA      = 0x9026,
        }

        /// <summary>
        /// Valid Values for e_ident[EI_VERSION] and e_version
        /// </summary>
        public enum ElfVersion : uint
        {
            /// <summary>
            ///  e_version, EI_VERSION
            /// </summary>
            EV_NONE = 0,
            EV_CURRENT = 1,
            EV_NUM     = 2,
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ELF32_HDR
        {
            /// <summary>
            /// Magic number and other info
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EI_NIDENT)]
            public char[]     e_ident;
            /// <summary>
            /// Object file type
            /// </summary>
            public ElfType    e_type;
            /// <summary>
            /// Architecture
            /// </summary>
            public ElfMachine e_machine;
            /// <summary>
            /// Object file version
            /// </summary>
            public ElfVersion e_version;
            /// <summary>
            /// Entry point virtual address
            /// </summary>
            public uint       e_entry;
            /// <summary>
            /// Program header table file offset
            /// </summary>
            public uint       e_phoff;
            /// <summary>
            /// Section header table file offset
            /// </summary>
            public uint       e_shoff;
            /// <summary>
            /// Processor-specific flags
            /// </summary>
            public uint       e_flags;
            /// <summary>
            /// ELF header size in bytes
            /// </summary>
            public ushort     e_ehsize;
            /// <summary>
            /// Program header table entry size
            /// </summary>
            public ushort     e_phentsize;
            /// <summary>
            /// Program header table entry count
            /// </summary>
            public ushort     e_phnum;
            /// <summary>
            /// Section header table entry size
            /// </summary>
            public ushort     e_shentsize;
            /// <summary>
            /// Section header table entry count
            /// </summary>
            public ushort     e_shnum;
            /// <summary>
            /// Section header string table index
            /// </summary>
            public ushort     e_shstrndx;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ELF64_HDR
        {
            /// <summary>
            /// Magic number and other info
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = EI_NIDENT)]
            public char[]     e_ident;
            /// <summary>
            /// Object file type
            /// </summary>
            public ElfType    e_type;
            /// <summary>
            /// Architecture
            /// </summary>
            public ElfMachine e_machine;
            /// <summary>
            /// Object file version
            /// </summary>
            public ElfVersion e_version;
            /// <summary>
            /// Entry point virtual address
            /// </summary>
            public ulong      e_entry;
            /// <summary>
            /// Program header table file offset
            /// </summary>
            public ulong      e_phoff;
            /// <summary>
            /// Section header table file offset
            /// </summary>
            public ulong      e_shoff;
            /// <summary>
            /// Processor-specific flags
            /// </summary>
            public uint       e_flags;
            /// <summary>
            /// ELF header size in bytes
            /// </summary>
            public ushort     e_ehsize;
            /// <summary>
            /// Program header table entry size
            /// </summary>
            public ushort     e_phentsize;
            /// <summary>
            /// Program header table entry count
            /// </summary>
            public ushort     e_phnum;
            /// <summary>
            /// Section header table entry size
            /// </summary>
            public ushort     e_shentsize;
            /// <summary>
            /// Section header table entry count
            /// </summary>
            public ushort     e_shnum;
            /// <summary>
            /// Section header string table index
            /// </summary>
            public ushort     e_shstrndx;
        }

        // Valid Values for sh_type
        public enum ShType : uint
        {
            /// <summary>
            /// Section header table entry unused
            /// </summary>
            SHT_NULL           = 0,
            /// <summary>
            /// Program data
            /// </summary>
            SHT_PROGBITS       = 1,
            /// <summary>
            /// Symbol table
            /// </summary>
            SHT_SYMTAB         = 2,
            /// <summary>
            /// String table
            /// </summary>
            SHT_STRTAB         = 3,
            /// <summary>
            /// Relocation entries with addends
            /// </summary>
            SHT_RELA           = 4,
            /// <summary>
            /// Symbol hash table
            /// </summary>
            SHT_HASH           = 5,
            /// <summary>
            /// Dynamic linking information
            /// </summary>
            SHT_DYNAMIC        = 6,
            /// <summary>
            /// Notes
            /// </summary>
            SHT_NOTE           = 7,
            /// <summary>
            /// Program space with no data (bss)
            /// </summary>
            SHT_NOBITS         = 8,
            /// <summary>
            /// Relocation entries, no addends
            /// </summary>
            SHT_REL            = 9,
            /// <summary>
            /// Reserved
            /// </summary>
            SHT_SHLIB          = 10,
            /// <summary>
            /// Dynamic linker symbol table
            /// </summary>
            SHT_DYNSYM         = 11,
            /// <summary>
            /// Array of constructors
            /// </summary>
            SHT_INIT_ARRAY     = 14,
            /// <summary>
            /// Array of destructors
            /// </summary>
            SHT_FINI_ARRAY     = 15,
            /// <summary>
            /// Array of pre-constructors
            /// </summary>
            SHT_PREINIT_ARRAY  = 16,
            /// <summary>
            /// Section group
            /// </summary>
            SHT_GROUP          = 17,
            /// <summary>
            /// Extended section indeces
            /// </summary>
            SHT_SYMTAB_SHNDX   = 18,
            /// <summary>
            /// Number of defined types.
            /// </summary>
            SHT_NUM            = 19,
            /// <summary>
            /// Start OS-specific.
            /// </summary>
            SHT_LOOS           = 0x60000000,
            /// <summary>
            /// Object attributes.
            /// </summary>
            SHT_GNU_ATTRIBUTES = 0x6ffffff5,
            /// <summary>
            /// GNU-style hash table.
            /// </summary>
            SHT_GNU_HASH       = 0x6ffffff6,
            /// <summary>
            /// Prelink library list
            /// </summary>
            SHT_GNU_LIBLIST    = 0x6ffffff7,
            /// <summary>
            /// Checksum for DSO content.
            /// </summary>
            SHT_CHECKSUM       = 0x6ffffff8,
            /// <summary>
            /// Sun-specific low bound.
            /// </summary>
            SHT_LOSUNW         = 0x6ffffffa,
            /// <summary>
            /// 
            /// </summary>
            SHT_SUNW_move      = 0x6ffffffa, 
            /// <summary>
            /// 
            /// </summary>
            SHT_SUNW_COMDAT    = 0x6ffffffb, 
            /// <summary>
            /// 
            /// </summary>
            SHT_SUNW_syminfo   = 0x6ffffffc, 
            /// <summary>
            /// Version definition section.
            /// </summary>
            SHT_GNU_verdef     = 0x6ffffffd,
            /// <summary>
            /// Version needs section.
            /// </summary>
            SHT_GNU_verneed    = 0x6ffffffe,
            /// <summary>
            /// Version symbol table.
            /// </summary>
            SHT_GNU_versym     = 0x6fffffff,
            /// <summary>
            /// Sun-specific high bound.
            /// </summary>
            SHT_HISUNW         = 0x6fffffff,
            /// <summary>
            /// End OS-specific type
            /// </summary>
            SHT_HIOS           = 0x6fffffff,
            /// <summary>
            /// Start of processor-specific
            /// </summary>
            SHT_LOPROC         = 0x70000000,
            /// <summary>
            /// End of processor-specific
            /// </summary>
            SHT_HIPROC         = 0x7fffffff,
            /// <summary>
            /// Start of application-specific
            /// </summary>
            SHT_LOUSER         = 0x80000000,
            /// <summary>
            /// End of application-specific
            /// </summary>
            SHT_HIUSER         = 0x8fffffff,
        }

        [Flags]
        // Valid Values for sh_flags
        public enum ShFlags : uint
        {
            /// <summary>
            /// Writable
            /// </summary>
            SHF_WRITE            = 0x00000001,
            /// <summary>
            /// Occupies memory during execution
            /// </summary>
            SHF_ALLOC            = 0x00000002,
            /// <summary>
            /// Executable
            /// </summary>
            SHF_EXECINSTR        = 0x00000004,
            //                   = 0x00000008, /* */
            /// <summary>
            /// Might be merged
            /// </summary>
            SHF_MERGE            = 0x00000010,
            /// <summary>
            /// Contains nul-terminated strings
            /// </summary>
            SHF_STRINGS          = 0x00000020,
            /// <summary>
            /// `sh_info' contains SHT index
            /// </summary>
            SHF_INFO_LINK        = 0x00000040,
            /// <summary>
            /// Preserve order after combining
            /// </summary>
            SHF_LINK_ORDER       = 0x00000080,
            /// <summary>
            /// Non-standard OS specific handling required
            /// </summary>
            SHF_OS_NONCONFORMING = 0x00000100,
            /// <summary>
            /// Section is member of a group.
            /// </summary>
            SHF_GROUP            = 0x00000200,
            /// <summary>
            /// Section hold thread-local data.
            /// </summary>
            SHF_TLS              = 0x00000400,
            /// <summary>
            /// Identifies a section containing compressed data.
            /// </summary>
            SHF_COMPRESSED       = 0x00000800,
            /// <summary>
            /// OS-specific.
            /// </summary>
            SHF_MASKOS           = 0x0ff00000,
            /// <summary>
            /// Processor-specific
            /// </summary>
            SHF_MASKPROC         = 0xf0000000,
            /// <summary>
            /// Special ordering requirement (Solaris).
            /// </summary>
            SHF_ORDERED	         = 0x40000000,
            /// <summary>
            /// Section is excluded unless referenced or allocated(Solaris).
            /// </summary>
            SHF_EXCLUDE          = 0x80000000,
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ELF32_SECTION_HEADER
        {
            /// <summary>
            /// Section name (string tbl index)
            /// </summary>
            public uint    sh_name;
            /// <summary>
            /// Section type
            /// </summary>
            public ShType  sh_type;
            /// <summary>
            /// Section flags
            /// </summary>
            public ShFlags sh_flags;
            /// <summary>
            /// Section virtual addr at execution
            /// </summary>
            public uint    sh_addr;
            /// <summary>
            /// Section file offset
            /// </summary>
            public uint    sh_offset;
            /// <summary>
            /// Section size in bytes
            /// </summary>
            public uint    sh_size;
            /// <summary>
            /// Link to another section
            /// </summary>
            public uint    sh_link;
            /// <summary>
            /// Additional section information
            /// </summary>
            public uint    sh_info;
            /// <summary>
            /// Section alignment
            /// </summary>
            public uint    sh_addralign;
            /// <summary>
            /// Entry size if section holds table
            /// </summary>
            public uint    sh_entsize;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ELF64_SECTION_HEADER
        {
            /// <summary>
            /// Section name (string tbl index)
            /// </summary>
            public uint   sh_name;
            /// <summary>
            /// Section type (ShFlags)
            /// </summary>
            public ShType sh_type;
            /// <summary>
            /// Section flags
            /// </summary>
            public ulong  sh_flags;
            /// <summary>
            /// Section virtual addr at execution
            /// </summary>
            public ulong  sh_addr;
            /// <summary>
            /// Section file offset
            /// </summary>
            public ulong  sh_offset;
            /// <summary>
            /// Section size in bytes
            /// </summary>
            public ulong  sh_size;
            /// <summary>
            /// Link to another section
            /// </summary>
            public uint   sh_link;
            /// <summary>
            /// Additional section information
            /// </summary>
            public uint   sh_info;
            /// <summary>
            /// Section alignment
            /// </summary>
            public ulong  sh_addralign;
            /// <summary>
            /// Entry size if section holds table
            /// </summary>
            public ulong  sh_entsize;
        }

        public struct Elf32_Reader_Section
        {
            public string section_name;
            public ELF32_SECTION_HEADER section_header;
        }

        public struct Elf64_Reader_Section
        {
            public string section_name;
            public ELF64_SECTION_HEADER section_header;
        }

        #endregion File Header Structures

        #region Private Fields

        /// <summary>
        /// The ELF32 Header
        /// </summary>
        private ELF32_HDR elf32_hdr;
        /// <summary>
        /// The ELF64 Header
        /// </summary>
        private ELF64_HDR elf64_hdr;
        /// <summary>
        /// The ELF32 Sections Header
        /// </summary>
        private Elf32_Reader_Section[] elf32_sections_hdr;
        /// <summary>
        /// The ELF64 Sections Header
        /// </summary>
        private Elf64_Reader_Section[] elf64_sections_hdr;

        #endregion Private Fields

        #region Public Methods

        public ElfHeaderReader()
        { }

        public ElfHeaderReader(string filePath)
        {
            Parse(filePath);
        }

        /// <summary>
        /// Read the ELF Header
        /// </summary>
        /// <returns></returns>
        public override void Parse(string filePath)
        {
            _TargetOS = OsId.Unknown;
            _ExecutableType = ExecutableType.Unknown;

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return;

            using (FileStream stream = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                BinaryReader reader = new BinaryReader(stream);
                HeaderMagic elf_magic = FromBinaryReader<HeaderMagic>(reader);
                if (elf_magic == HeaderMagic.ELFMAGINT)
                {
                    ElfClass elf_class = FromBinaryReader<ElfClass>(reader);
                    stream.Seek(0, SeekOrigin.Begin);

                    if (elf_class == ElfClass.ELFCLASS32)
                    {
                        elf32_hdr = FromBinaryReader<ELF32_HDR>(reader);
                        stream.Seek(elf32_hdr.e_shoff, SeekOrigin.Begin);

                        elf32_sections_hdr = new Elf32_Reader_Section[elf32_hdr.e_shnum];

                        for(int i = 0; i < elf32_hdr.e_shnum; ++i)
                        {
                            elf32_sections_hdr[i].section_header = FromBinaryReader<ELF32_SECTION_HEADER>(reader);
                        }

                        ELF32_SECTION_HEADER str_section_hdr = elf32_sections_hdr[elf32_hdr.e_shstrndx].section_header;
                        stream.Seek(str_section_hdr.sh_offset, SeekOrigin.Begin);
                        string names = System.Text.Encoding.ASCII.GetString(reader.ReadBytes((int)str_section_hdr.sh_size));

                        for (int i = 0; i < elf32_hdr.e_shnum; ++i)
                        {
                            int offset = (int)elf32_sections_hdr[i].section_header.sh_name;
                            elf32_sections_hdr[i].section_name = names.Substring(offset, names.IndexOf('\0', offset)-offset);
                        }

                        switch(elf32_hdr.e_type)
                        {
                            case ElfType.ET_EXEC: _ExecutableType = ExecutableType.Executable; break;
                            case ElfType.ET_DYN : _ExecutableType = ExecutableType.Library; break;
                            default             : _ExecutableType = ExecutableType.Unknown; break;
                        }

                        _IsValidHeader = true;
                        _Is32BitHeader = true;
                        _TargetOS = OsId.Linux;
                    }
                    else if (elf_class == ElfClass.ELFCLASS64)
                    {
                        elf64_hdr = FromBinaryReader<ELF64_HDR>(reader);
                        stream.Seek((long)elf64_hdr.e_shoff, SeekOrigin.Begin);

                        elf64_sections_hdr = new Elf64_Reader_Section[elf64_hdr.e_shnum];

                        for (int i = 0; i < elf64_hdr.e_shnum; ++i)
                        {
                            elf64_sections_hdr[i].section_header = FromBinaryReader<ELF64_SECTION_HEADER>(reader);
                        }

                        ELF64_SECTION_HEADER str_section_hdr = elf64_sections_hdr[elf64_hdr.e_shstrndx].section_header;
                        stream.Seek((long)str_section_hdr.sh_offset, SeekOrigin.Begin);
                        string names = System.Text.Encoding.ASCII.GetString(reader.ReadBytes((int)str_section_hdr.sh_size));

                        for (int i = 0; i < elf64_hdr.e_shnum; ++i)
                        {
                            int offset = (int)elf64_sections_hdr[i].section_header.sh_name;
                            elf64_sections_hdr[i].section_name = names.Substring(offset, names.IndexOf('\0', offset) - offset);
                        }

                        switch (elf64_hdr.e_type)
                        {
                            case ElfType.ET_EXEC: _ExecutableType = ExecutableType.Executable; break;
                            case ElfType.ET_DYN : _ExecutableType = ExecutableType.Library; break;
                            default             : _ExecutableType = ExecutableType.Unknown; break;
                        }

                        _IsValidHeader = true;
                        _Is32BitHeader = false;
                        _TargetOS = OsId.Linux;
                    }
                }
            }
        }

        #endregion Public Methods

        #region Properties

        /// <summary>
        /// Gets the Elf32 Header
        /// </summary>
        public ELF32_HDR Elf32Header
        {
            get
            {
                return elf32_hdr;
            }
        }

        /// <summary>
        /// Gets the Elf64 Header
        /// </summary>
        public ELF64_HDR Elf64Header
        {
            get
            {
                return elf64_hdr;
            }
        }

        public Elf32_Reader_Section[] Elf32SectionsHeader
        {
            get
            {
                return elf32_sections_hdr;
            }
        }

        public Elf64_Reader_Section[] Elf64SectionsHeader
        {
            get
            {
                return elf64_sections_hdr;
            }
        }

        #endregion Properties
    }
}