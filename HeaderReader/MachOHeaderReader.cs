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
    /// Reads in the header information of the Mach OS format.
    /// </summary>
    public class MachOHeaderReader : ExecutableHeaderReader
    {
        #region File Header Structures

        public enum HeaderMagic : uint
        {
            /// <summary>
            /// the mach magic number
            /// </summary>
            MH_MAGIC    = 0xfeedface,
            /// <summary>
            /// NXSwapInt(MH_MAGIC)
            /// </summary>
            MH_CIGAM    = 0xcefaedfe,
            /// <summary>
            /// the 64-bit mach magic number
            /// </summary>
            MH_MAGIC_64 = 0xfeedfacf,
            /// <summary>
            /// NXSwapInt(MH_MAGIC_64)
            /// </summary>
            MH_CIGAM_64 = 0xcffaedfe, 
        }

        public enum CpuArch : uint
        {
            /// <summary>
            /// mask for architecture bits
            /// </summary>
            CPU_ARCH_MASK  = 0xff000000,
            /// <summary>
            /// 64 bit ABI
            /// </summary>
            CPU_ARCH_ABI64 = 0x01000000,
        }

        public enum CpuType : int
        {
            CPU_TYPE_ANY       = -1,
            CPU_TYPE_VAX       = 1,
            /* skip                     ((cpu_type_t) 2)    */
            /* skip                     ((cpu_type_t) 3)    */
            /* skip                     ((cpu_type_t) 4)    */
            /* skip                     ((cpu_type_t) 5)    */
            CPU_TYPE_MC680x0   = 6,
            CPU_TYPE_X86       = 7,
            /// <summary>
            /// compatibility
            /// </summary>
            CPU_TYPE_I386      = CPU_TYPE_X86, 
            CPU_TYPE_X86_64    = (CPU_TYPE_X86 | (int)CpuArch.CPU_ARCH_ABI64),
            /* skip CPU_TYPE_MIPS       ((cpu_type_t) 8)    */
            /* skip                     ((cpu_type_t) 9)    */
            CPU_TYPE_MC98000   = 10,
            CPU_TYPE_HPPA      = 11,
            CPU_TYPE_ARM       = 12,
            CPU_TYPE_ARM64     = (CPU_TYPE_ARM | (int)CpuArch.CPU_ARCH_ABI64),
            CPU_TYPE_MC88000   = 13,
            CPU_TYPE_SPARC     = 14,
            CPU_TYPE_I860      = 15,
            /* skip CPU_TYPE_ALPHA      ((cpu_type_t) 16)   */
            /* skip                     ((cpu_type_t) 17)   */
            CPU_TYPE_POWERPC   = 18,
            CPU_TYPE_POWERPC64 = (CPU_TYPE_POWERPC | (int)CpuArch.CPU_ARCH_ABI64),
        }

        /// <summary>
        /// Capability bits used in the definition of cpu_subtype.
        /// </summary>
        public enum CpuSubArch : uint
        {
            /// <summary>
            /// mask for feature flags
            /// </summary>
            CPU_SUBTYPE_MASK  = 0xff000000,
            /// <summary>
            /// 64 bit libraries
            /// </summary>
            CPU_SUBTYPE_LIB64 = 0x80000000,
        }

        public enum CpuSubType : int
        {
            /*
             *  Object files that are hand-crafted to run on any
             *  implementation of an architecture are tagged with
             *  CPU_SUBTYPE_MULTIPLE.  This functions essentially the same as
             *  the "ALL" subtype of an architecture except that it allows us
             *  to easily find object files that may need to be modified
             *  whenever a new implementation of an architecture comes out.
             *
             *  It is the responsibility of the implementor to make sure the
             *  software handles unsupported implementations elegantly.
             */
            CPU_SUBTYPE_MULTIPLE      = -1,
            CPU_SUBTYPE_LITTLE_ENDIAN = 0,
            CPU_SUBTYPE_BIG_ENDIAN    = 1,
            /*
             *     Machine threadtypes.
             *     This is none - not defined - for most machine types/subtypes.
             */
            CPU_THREADTYPE_NONE       = 0,
            /*
             *  VAX subtypes (these do *not* necessary conform to the actual cpu
             *  ID assigned by DEC available via the SID register).
             */
            CPU_SUBTYPE_VAX_ALL = 0,
            CPU_SUBTYPE_VAX780  = 1,
            CPU_SUBTYPE_VAX785  = 2,
            CPU_SUBTYPE_VAX750  = 3,
            CPU_SUBTYPE_VAX730  = 4,
            CPU_SUBTYPE_UVAXI   = 5,
            CPU_SUBTYPE_UVAXII  = 6,
            CPU_SUBTYPE_VAX8200 = 7,
            CPU_SUBTYPE_VAX8500 = 8,
            CPU_SUBTYPE_VAX8600 = 9,
            CPU_SUBTYPE_VAX8650 = 10,
            CPU_SUBTYPE_VAX8800 = 11,
            CPU_SUBTYPE_UVAXIII = 12,
            /*
             *  680x0 subtypes
             *
             * The subtype definitions here are unusual for historical reasons.
             * NeXT used to consider 68030 code as generic 68000 code.  For
             * backwards compatability:
             *
             *  CPU_SUBTYPE_MC68030 symbol has been preserved for source code
             *  compatability.
             *
             *  CPU_SUBTYPE_MC680x0_ALL has been defined to be the same
             *  subtype as CPU_SUBTYPE_MC68030 for binary comatability.
             *
             *  CPU_SUBTYPE_MC68030_ONLY has been added to allow new object
             *  files to be tagged as containing 68030-specific instructions.
             */
            CPU_SUBTYPE_MC680x0_ALL  = 1,
            CPU_SUBTYPE_MC68030      = 1, /* compat */
            CPU_SUBTYPE_MC68040      = 2,
            CPU_SUBTYPE_MC68030_ONLY = 3,
            /*
             *  I386 subtypes
             */
            // CPU_SUBTYPE_INTEL(f, m) ((cpu_subtype_t) (f) + ((m) << 4))
            CPU_SUBTYPE_I386_ALL       = (3  + (0 << 4)),
            CPU_SUBTYPE_386            = (3  + (0 << 4)),
            CPU_SUBTYPE_486            = (4  + (0 << 4)),
            CPU_SUBTYPE_486SX          = (4  + (8 << 4)), // 8 << 4 = 128
            CPU_SUBTYPE_586            = (5  + (0 << 4)),
            CPU_SUBTYPE_PENT           = (5  + (0 << 4)),
            CPU_SUBTYPE_PENTPRO        = (6  + (1 << 4)),
            CPU_SUBTYPE_PENTII_M3      = (6  + (3 << 4)),
            CPU_SUBTYPE_PENTII_M5      = (6  + (5 << 4)),
            CPU_SUBTYPE_CELERON        = (7  + (6 << 4)),
            CPU_SUBTYPE_CELERON_MOBILE = (7  + (7 << 4)),
            CPU_SUBTYPE_PENTIUM_3      = (8  + (0 << 4)),
            CPU_SUBTYPE_PENTIUM_3_M    = (8  + (1 << 4)),
            CPU_SUBTYPE_PENTIUM_3_XEON = (8  + (2 << 4)),
            CPU_SUBTYPE_PENTIUM_M      = (9  + (0 << 4)),
            CPU_SUBTYPE_PENTIUM_4      = (10 + (0 << 4)),
            CPU_SUBTYPE_PENTIUM_4_M    = (10 + (1 << 4)),
            CPU_SUBTYPE_ITANIUM        = (11 + (0 << 4)),
            CPU_SUBTYPE_ITANIUM_2      = (11 + (1 << 4)),
            CPU_SUBTYPE_XEON           = (12 + (0 << 4)),
            CPU_SUBTYPE_XEON_MP        = (12 + (1 << 4)),

            // CPU_SUBTYPE_INTEL_FAMILY(x) ((x) & 15)
            CPU_SUBTYPE_INTEL_FAMILY_MAX = 15,

            // CPU_SUBTYPE_INTEL_MODEL(x)  ((x) >> 4)
            CPU_SUBTYPE_INTEL_MODEL_ALL = 0,

            /*
             *  X86 subtypes.
             */
            CPU_SUBTYPE_X86_ALL = 3,
            CPU_SUBTYPE_X86_64_ALL = 3,
            CPU_SUBTYPE_X86_ARCH1  = 4,
            CPU_SUBTYPE_X86_64_H   = 8,  /* Haswell feature subset */

            CPU_THREADTYPE_INTEL_HTT = 1,

            /*
             *  Mips subtypes.
             */
            CPU_SUBTYPE_MIPS_ALL    = 0,
            CPU_SUBTYPE_MIPS_R2300  = 1,
            CPU_SUBTYPE_MIPS_R2600  = 2,
            CPU_SUBTYPE_MIPS_R2800  = 3,
            CPU_SUBTYPE_MIPS_R2000a = 4, /* pmax */
            CPU_SUBTYPE_MIPS_R2000  = 5,
            CPU_SUBTYPE_MIPS_R3000a = 6, /* 3max */
            CPU_SUBTYPE_MIPS_R3000  = 7,
            /*
             *  MC98000 (PowerPC) subtypes
             */
            CPU_SUBTYPE_MC98000_ALL = 0,
            CPU_SUBTYPE_MC98601     = 1,
            /*
             *  HPPA subtypes for Hewlett-Packard HP-PA family of
             *  risc processors. Port by NeXT to 700 series.
             */
            CPU_SUBTYPE_HPPA_ALL = 0,
            CPU_SUBTYPE_HPPA_7100   = 0, /* compat */
            CPU_SUBTYPE_HPPA_7100LC = 1,
            /*
             *  MC88000 subtypes.
             */
            CPU_SUBTYPE_MC88000_ALL = 0,
            CPU_SUBTYPE_MC88100     = 1,
            CPU_SUBTYPE_MC88110     = 2,
            /*
             *  SPARC subtypes
             */
            CPU_SUBTYPE_SPARC_ALL = 0,
            /*
             *  I860 subtypes
             */
            CPU_SUBTYPE_I860_ALL = 0,
            CPU_SUBTYPE_I860_860 = 1,
            /*
             *  PowerPC subtypes
             */
            CPU_SUBTYPE_POWERPC_ALL   = 0,
            CPU_SUBTYPE_POWERPC_601   = 1,
            CPU_SUBTYPE_POWERPC_602   = 2,
            CPU_SUBTYPE_POWERPC_603   = 3,
            CPU_SUBTYPE_POWERPC_603e  = 4,
            CPU_SUBTYPE_POWERPC_603ev = 5,
            CPU_SUBTYPE_POWERPC_604   = 6,
            CPU_SUBTYPE_POWERPC_604e  = 7,
            CPU_SUBTYPE_POWERPC_620   = 8,
            CPU_SUBTYPE_POWERPC_750   = 9,
            CPU_SUBTYPE_POWERPC_7400  = 10,
            CPU_SUBTYPE_POWERPC_7450  = 11,
            CPU_SUBTYPE_POWERPC_970   = 100,
            /*
             *  ARM subtypes
             */
            CPU_SUBTYPE_ARM_ALL    = 0,
            CPU_SUBTYPE_ARM_V4T    = 5,
            CPU_SUBTYPE_ARM_V6     = 6,
            CPU_SUBTYPE_ARM_V5TEJ  = 7,
            CPU_SUBTYPE_ARM_XSCALE = 8,
            CPU_SUBTYPE_ARM_V7     = 9,
            CPU_SUBTYPE_ARM_V7F    = 10, /* Cortex A9 */
            CPU_SUBTYPE_ARM_V7S    = 11, /* Swift */
            CPU_SUBTYPE_ARM_V7K    = 12,
            CPU_SUBTYPE_ARM_V6M    = 14, /* Not meant to be run under xnu */
            CPU_SUBTYPE_ARM_V7M    = 15, /* Not meant to be run under xnu */
            CPU_SUBTYPE_ARM_V7EM   = 16, /* Not meant to be run under xnu */
            CPU_SUBTYPE_ARM_V8     = 13,
            /*
             *  ARM64 subtypes
             */
            CPU_SUBTYPE_ARM64_ALL = 0,
            CPU_SUBTYPE_ARM64_V8  = 1,
        }

        /// <summary>
        /// Constants for the filetype field of the mach_header
        /// </summary>
        public enum FileType : uint
        {
            /// <summary>
            /// relocatable object file
            /// </summary>
            MH_OBJECT      = 0x1,
            /// <summary>
            /// demand paged executable file
            /// </summary>
            MH_EXECUTE     = 0x2,
            /// <summary>
            /// fixed VM shared library file
            /// </summary>
            MH_FVMLIB      = 0x3,
            /// <summary>
            /// core file
            /// </summary>
            MH_CORE        = 0x4,
            /// <summary>
            /// preloaded executable file
            /// </summary>
            MH_PRELOAD     = 0x5,
            /// <summary>
            /// dynamically bound shared library
            /// </summary>
            MH_DYLIB       = 0x6,
            /// <summary>
            /// dynamic link editor
            /// </summary>
            MH_DYLINKER    = 0x7,
            /// <summary>
            /// dynamically bound bundle file
            /// </summary>
            MH_BUNDLE      = 0x8,
            /// <summary>
            /// shared library stub for static
            /// </summary>
            MH_DYLIB_STUB  = 0x9,
            /// <summary>
            /// linking only, no section contents
            /// companion file with only debug
            /// </summary>
            MH_DSYM        = 0xa,
            /// <summary>
            /// sections
            /// x86_64 kexts
            /// </summary>
            MH_KEXT_BUNDLE = 0xb,
        }

        /// <summary>
        /// Constants for the flags field of the mach_header
        /// </summary>
        [Flags]
        public enum HeaderFlags : uint
        {
            /// <summary>
            /// the object file has no undefined references
            /// </summary>
            MH_NOUNDEFS                      = 0x1,
            /// <summary>
            /// the object file is the output of an incremental link against a base file and can't be link edited again
            /// </summary>
            MH_INCRLINK                      = 0x2,
            /// <summary>
            /// the object file is input for the dynamic linker and can't be staticly link edited again
            /// </summary>
            MH_DYLDLINK                      = 0x4,
            /// <summary>
            /// the object file's undefined references are bound by the dynamic linker when loaded.
            /// </summary>
            MH_BINDATLOAD                    = 0x8,
            /// <summary>
            /// the file has its dynamic undefined references prebound.
            /// </summary>
            MH_PREBOUND                      = 0x10,
            /// <summary>
            /// the file has its read-only and read-write segments split
            /// </summary>
            MH_SPLIT_SEGS                    = 0x20,
            /// <summary>
            /// the shared library init routine is to be run lazily via catching memory faults to its writeable segments (obsolete)
            /// </summary>
            MH_LAZY_INIT                     = 0x40,
            /// <summary>
            /// the image is using two-level name space bindings
            /// </summary>
            MH_TWOLEVEL                      = 0x80,
            /// <summary>
            /// the executable is forcing all images to use flat name space bindings
            /// </summary>
            MH_FORCE_FLAT                    = 0x100,
            /// <summary>
            /// this umbrella guarantees no multiple defintions of symbols in its sub-images so the two-level namespace hints can always be used.
            /// </summary>
            MH_NOMULTIDEFS                   = 0x200,
            /// <summary>
            /// do not have dyld notify the prebinding agent about this executable
            /// </summary>
            MH_NOFIXPREBINDING               = 0x400,
            /// <summary>
            /// the binary is not prebound but can have its prebinding redone. only used when MH_PREBOUND is not set.
            /// </summary>
            MH_PREBINDABLE                   = 0x800,
            /// <summary>
            /// indicates that this binary binds to all two-level namespace modules of its dependent libraries.only used when MH_PREBINDABLE and MH_TWOLEVEL are both set.
            /// </summary>
            MH_ALLMODSBOUND                  = 0x1000,
            /// <summary>
            /// safe to divide up the sections into sub-sections via symbols for dead code stripping
            /// </summary>
            MH_SUBSECTIONS_VIA_SYMBOLS       = 0x2000,
            /// <summary>
            /// the binary has been canonicalized via the unprebind operation
            /// </summary>
            MH_CANONICAL                     = 0x4000,
            /// <summary>
            /// the final linked image contains external weak symbols
            /// </summary>
            MH_WEAK_DEFINES                  = 0x8000,
            /// <summary>
            /// the final linked image uses weak symbols
            /// </summary>
            MH_BINDS_TO_WEAK                 = 0x10000,
            /// <summary>
            /// When this bit is set, all stacks in the task will be given stack execution privilege. Only used in MH_EXECUTE filetypes.
            /// </summary>
            MH_ALLOW_STACK_EXECUTION         = 0x20000,
            /// <summary>
            /// When this bit is set, the binary declares it is safe for use in processes with uid zero
            /// </summary>
            MH_ROOT_SAFE                     = 0x40000,
            /// <summary>
            /// When this bit is set, the binary declares it is safe for use in processes when issetugid() is true
            /// </summary>
            MH_SETUID_SAFE                   = 0x80000,
            /// <summary>
            /// When this bit is set on a dylib, the static linker does not need to examine dependent dylibs to see if any are re-exporte
            /// </summary>
            MH_NO_REEXPORTED_DYLIBS          = 0x100000,
            /// <summary>
            /// When this bit is set, the OS will load the main executable at a random address.Only used in MH_EXECUTE filetypes.
            /// </summary>
            MH_PIE                           = 0x200000,
            /// <summary>
            /// Only for use on dylibs. When linking against a dylib that has this bit set, the static linker will automatically not create a LC_LOAD_DYLIB load command to the dylib if no symbols are being referenced from the dylib.
            /// </summary>
            MH_DEAD_STRIPPABLE_DYLIB         = 0x400000,
            /// <summary>
            /// Contains a section of type S_THREAD_LOCAL_VARIABLES
            /// </summary>
            MH_HAS_TLV_DESCRIPTORS           = 0x800000,
            /// <summary>
            /// When this bit is set, the OS will run the main executable with a non-executable heap even on platforms (e.g.i386) that don't require it. Only used in MH_EXECUTE filetypes.
            /// </summary>
            MH_NO_HEAP_EXECUTION             = 0x1000000,
            /// <summary>
            /// The code was linked for use in an application extension.
            /// </summary>
            MH_APP_EXTENSION_SAFE            = 0x02000000,
            /// <summary>
            /// The external symbols listed in the nlist symbol table do not include all the symbols listed in the dyld info.
            /// </summary>
            MH_NLIST_OUTOFSYNC_WITH_DYLDINFO = 0x04000000,
    }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MACHO32_HDR
        {
            /// <summary>
            /// mach magic number identifier
            /// </summary>
            public HeaderMagic magic;
            /// <summary>
            /// cpu specifier
            /// </summary>
            public CpuType     cputype;
            /// <summary>
            /// machine specifier
            /// </summary>
            public CpuSubType  cpusubtype;
            /// <summary>
            /// type of file
            /// </summary>
            public FileType    filetype;
            /// <summary>
            /// number of load commands
            /// </summary>
            public uint        ncmds;
            /// <summary>
            /// the size of all the load commands
            /// </summary>
            public uint        sizeofcmds;
            /// <summary>
            /// flags
            /// </summary>
            public HeaderFlags       flags;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MACHO64_HDR
        {
            /// <summary>
            /// mach magic number identifier
            /// </summary>
            public HeaderMagic magic;
            /// <summary>
            /// cpu specifier
            /// </summary>
            public CpuType     cputype;
            /// <summary>
            /// machine specifier
            /// </summary>
            public CpuSubType  cpusubtype;
            /// <summary>
            /// type of file
            /// </summary>
            public FileType    filetype;
            /// <summary>
            /// number of load commands
            /// </summary>
            public uint        ncmds;
            /// <summary>
            /// the size of all the load commands
            /// </summary>
            public uint        sizeofcmds;
            /// <summary>
            /// flags
            /// </summary>
            public HeaderFlags       flags;
            /// <summary>
            /// reserved
            /// </summary>
            public uint        reserved;
        }

        /// <summary>
        /// Constants for the cmd field of all load commands, the type
        /// </summary>
        public enum Cmd : uint
        {
            /// <summary>
            /// After MacOS X 10.1 when a new load command is added that is required to be
            /// understood by the dynamic linker for the image to execute properly the
            /// LC_REQ_DYLD bit will be or'ed into the load command constant.  If the dynamic
            /// linker sees such a load command it it does not understand will issue a
            /// "unknown load command required for execution" error and refuse to use the
            /// image.  Other load commands without this bit that are not understood will
            /// simply be ignored.
            /// </summary>
            LC_REQ_DYLD                 = 0x80000000,

            /// <summary>
            /// segment of this file to be mapped
            /// </summary>
            LC_SEGMENT                  = 0x1,
            /// <summary>
            /// link-edit stab symbol table info
            /// </summary>
            LC_SYMTAB                   = 0x2,
            /// <summary>
            /// link-edit gdb symbol table info (obsolete)
            /// </summary>
            LC_SYMSEG                   = 0x3,
            /// <summary>
            /// thread
            /// </summary>
            LC_THREAD                   = 0x4,
            /// <summary>
            /// unix thread (includes a stack)
            /// </summary>
            LC_UNIXTHREAD               = 0x5,
            /// <summary>
            /// load a specified fixed VM shared library
            /// </summary>
            LC_LOADFVMLIB               = 0x6,
            /// <summary>
            /// fixed VM shared library identification
            /// </summary>
            LC_IDFVMLIB                 = 0x7,
            /// <summary>
            /// object identification info (obsolete)
            /// </summary>
            LC_IDENT                    = 0x8,
            /// <summary>
            /// fixed VM file inclusion (internal use)
            /// </summary>
            LC_FVMFILE                  = 0x9,
            /// <summary>
            /// prepage command (internal use)
            /// </summary>
            LC_PREPAGE                  = 0xa,
            /// <summary>
            /// dynamic link-edit symbol table info
            /// </summary>
            LC_DYSYMTAB                 = 0xb,
            /// <summary>
            /// load a dynamically linked shared library
            /// </summary>
            LC_LOAD_DYLIB               = 0xc,
            /// <summary>
            /// dynamically linked shared lib ident
            /// </summary>
            LC_ID_DYLIB                 = 0xd,
            /// <summary>
            /// load a dynamic linker
            /// </summary>
            LC_LOAD_DYLINKER            = 0xe,
            /// <summary>
            /// dynamic linker identification
            /// </summary>
            LC_ID_DYLINKER              = 0xf,
            /// <summary>
            /// modules prebound for a dynamically
            /// </summary>
            LC_PREBOUND_DYLIB           = 0x10,
            // linked shared library
            /// <summary>
            /// image routines
            /// </summary>
            LC_ROUTINES                 = 0x11,
            /// <summary>
            /// sub framework
            /// </summary>
            LC_SUB_FRAMEWORK            = 0x12,
            /// <summary>
            /// sub umbrella
            /// </summary>
            LC_SUB_UMBRELLA             = 0x13,
            /// <summary>
            /// sub client
            /// </summary>
            LC_SUB_CLIENT               = 0x14,
            /// <summary>
            /// sub library
            /// </summary>
            LC_SUB_LIBRARY              = 0x15,
            /// <summary>
            /// two-level namespace lookup hints
            /// </summary>
            LC_TWOLEVEL_HINTS           = 0x16,
            /// <summary>
            /// prebind checksum
            /// </summary>
            LC_PREBIND_CKSUM            = 0x17,
            /// <summary>
            /// load a dynamically linked shared library that is allowed to be missing all symbols are weak imported).
            /// </summary>
            LC_LOAD_WEAK_DYLIB          = (0x18 | LC_REQ_DYLD),
            /// <summary>
            /// 64-bit segment of this file to be mapped
            /// </summary>
            LC_SEGMENT_64               = 0x19,
            /// <summary>
            /// 64-bit image routines
            /// </summary>
            LC_ROUTINES_64              = 0x1a,
            /// <summary>
            /// the uuid
            /// </summary>
            LC_UUID                     = 0x1b,
            /// <summary>
            /// runpath additions
            /// </summary>
            LC_RPATH                    = (0x1c | LC_REQ_DYLD),
            /// <summary>
            /// local of code signature
            /// </summary>
            LC_CODE_SIGNATURE           = 0x1d,
            /// <summary>
            /// local of info to split segments
            /// </summary>
            LC_SEGMENT_SPLIT_INFO       = 0x1e,
            /// <summary>
            /// load and re-export dylib
            /// </summary>
            LC_REEXPORT_DYLIB           = (0x1f | LC_REQ_DYLD),
            /// <summary>
            ///  */
            /// </summary>
            LC_LAZY_LOAD_DYLIB          = 0x20,
            /// <summary>
            /// encrypted segment information
            /// </summary>
            LC_ENCRYPTION_INFO          = 0x21,
            /// <summary>
            /// compressed dyld information
            /// </summary>
            LC_DYLD_INFO                = 0x22,
            /// <summary>
            /// compressed dyld information only
            /// </summary>
            LC_DYLD_INFO_ONLY           = (0x22|LC_REQ_DYLD),
            /// <summary>
            /// load upward dylib
            /// </summary>
            LC_LOAD_UPWARD_DYLIB        = (0x23 | LC_REQ_DYLD),
            /// <summary>
            /// build for MacOSX min OS version
            /// </summary>
            LC_VERSION_MIN_MACOSX       = 0x24,
            /// <summary>
            /// build for iPhoneOS min OS version
            /// </summary>
            LC_VERSION_MIN_IPHONEOS     = 0x25,
            /// <summary>
            /// compressed table of function start addresses
            /// </summary>
            LC_FUNCTION_STARTS          = 0x26,
            /// <summary>
            /// string for dyld to treat like environment variable
            /// </summary>
            LC_DYLD_ENVIRONMENT         = 0x27,
            /// <summary>
            /// replacement for LC_UNIXTHREAD
            /// </summary>
            LC_MAIN                     = (0x28|LC_REQ_DYLD),
            /// <summary>
            /// table of non-instructions in __text
            /// </summary>
            LC_DATA_IN_CODE             = 0x29,
            /// <summary>
            /// source version used to build binary
            /// </summary>
            LC_SOURCE_VERSION           = 0x2A,
            /// <summary>
            /// Code signing DRs copied from linked dylibs
            /// </summary>
            LC_DYLIB_CODE_SIGN_DRS      = 0x2B,
            /// <summary>
            /// 64-bit encrypted segment information
            /// </summary>
            LC_ENCRYPTION_INFO_64       = 0x2C,
            /// <summary>
            /// linker options in MH_OBJECT files
            /// </summary>
            LC_LINKER_OPTION            = 0x2D,
            /// <summary>
            /// optimization hints in MH_OBJECT files
            /// </summary>
            LC_LINKER_OPTIMIZATION_HINT = 0x2E,
            /// <summary>
            /// build for AppleTV min OS version
            /// </summary>
            LC_VERSION_MIN_TVOS         = 0x2F,
            /// <summary>
            /// build for Watch min OS version
            /// </summary>
            LC_VERSION_MIN_WATCHOS      = 0x30,
            /// <summary>
            /// arbitrary data included within a Mach-O file
            /// </summary>
            LC_NOTE                     = 0x31,
            /// <summary>
            ///  */
            /// </summary>
            LC_BUILD_VERSION            = 0x32,
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct LoadCommand
        {
            /// <summary>
            /// type of load command
            /// </summary>
            Cmd cmd;
            /// <summary>
            /// total size of command in bytes
            /// </summary>
            uint cmdsize;
        };

        /// <summary>
        /// VM protection values.
        /// </summary>
        public enum VmProt : int
        {
            VM_PROT_NONE       = 0x00,
            /// <summary>
            /// read permission
            /// </summary>
            VM_PROT_READ       = 0x01,
            /// <summary>
            /// write permission
            /// </summary>
            VM_PROT_WRITE      = 0x02,
            /// <summary>
            /// execute permission
            /// </summary>
            VM_PROT_EXECUTE    = 0x04,
            /// <summary>
            /// The default protection for newly-created virtual memory
            /// </summary>
            VM_PROT_DEFAULT    = (VM_PROT_READ|VM_PROT_WRITE),
            /// <summary>
            /// The maximum privileges possible, for parameter checking.
            /// </summary>
            VM_PROT_ALL        = (VM_PROT_READ|VM_PROT_WRITE|VM_PROT_EXECUTE),
            /// <summary>
            /// An invalid protection value. Used only by memory_object_lock_request to indicate no change to page locks.
            /// Using -1 here is a bad idea because it looks like VM_PROT_ALL and then some.
            /// </summary>
            VM_PROT_NO_CHANGE  = 0x08,
            /// <summary>
            /// When a caller finds that he cannot obtain write permission on a
            /// mapped entry, the following flag can be used.  The entry will
            /// be made "needs copy" effectively copying the object (using COW),
            /// and write permission will be added to the maximum protections
            /// for the associated entry.
            /// </summary>
            VM_PROT_COPY       = 0x10,
            /// <summary>
            /// Another invalid protection value.
            /// Used only by memory_object_data_request upon an object
            /// which has specified a copy_call copy strategy. It is used
            /// when the kernel wants a page belonging to a copy of the
            /// object, and is only asking the object as a result of
            /// following a shadow chain. This solves the race between pages
            /// being pushed up by the memory manager and the kernel
            /// walking down the shadow chain.
            /// </summary>
            VM_PROT_WANTS_COPY  = 0x10,
            /// <summary>
            /// Another invalid protection value.
            /// Indicates that the other protection bits are to be applied as a mask
            /// against the actual protection bits of the map entry.
            /// </summary>
            VM_PROT_IS_MASK     = 0x40,
            /// <summary>
            /// Another invalid protection value to support execute-only protection.
            /// VM_PROT_STRIP_READ is a special marker that tells mprotect to not
            /// set VM_PROT_READ. We have to do it this way because existing code
            /// expects the system to set VM_PROT_READ if VM_PROT_EXECUTE is set.
            /// VM_PROT_EXECUTE_ONLY is just a convenience value to indicate that
            /// the memory should be executable and explicitly not readable. It will
            /// be ignored on platforms that do not support this type of protection.
            /// </summary>
            VM_PROT_STRIP_READ   = 0x80,
            VM_PROT_EXECUTE_ONLY = (VM_PROT_EXECUTE|VM_PROT_STRIP_READ),
        }

        /// <summary>
        /// Constants for the flags field of the segment_command
        /// </summary>
        [Flags]
        public enum SGFlags : uint
        {
            /// <summary>
            /// the file contents for this segment is for the high part of the VM space, the low part is zero filled (for stacks in core files)
            /// </summary>
            SG_HIGHVM   = 0x1,
            /// <summary>
            /// this segment is the VM that is allocated by a fixed VM library, for overlap checking in the link editor
            /// </summary>
            SG_FVMLIB   = 0x2,
            /// <summary>
            /// this segment has nothing that was relocated in it and nothing relocated to it, that is it maybe safely replaced without relocation
            /// </summary>
            SG_NORELOC = 0x4,
            /// <summary>
            /// This segment is protected.  If the segment starts at file offset 0, the first page of the segment is not
            /// protected. All other pages of the segment are protected.
            /// </summary>
            SG_PROTECTED_VERSION_1 = 0x8,
        }

        /// <summary>
        /// The segment load command indicates that a part of this file is to be
        /// mapped into the task's address space.  The size of this segment in memory,
        /// vmsize, maybe equal to or larger than the amount to map from this file,
        /// filesize.  The file is mapped starting at fileoff to the beginning of
        /// the segment in memory, vmaddr.The rest of the memory of the segment,
        /// if any, is allocated zero fill on demand.The segment's maximum virtual
        /// memory protection and initial virtual memory protection are specified
        /// by the maxprot and initprot fields.If the segment has sections then the
        /// section structures directly follow the segment command and their size is
        /// reflected in cmdsize.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SegmentCommand32
        {
            /// <summary>
            /// LC_SEGMENT
            /// </summary>
            public Cmd     cmd;
            /// <summary>
            /// includes sizeof section_64 structs
            /// </summary>
            public uint cmdsize;
            /// <summary>
            /// segment name
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[]   segname;
            /// <summary>
            /// memory address of this segment
            /// </summary>
            public uint vmaddr;
            /// <summary>
            /// memory size of this segment
            /// </summary>
            public uint vmsize;
            /// <summary>
            /// file offset of this segment
            /// </summary>
            public uint fileoff;
            /// <summary>
            /// amount to map from the file
            /// </summary>
            public uint filesize;
            /// <summary>
            /// maximum VM protection
            /// </summary>
            public VmProt maxprot;
            /// <summary>
            /// initial VM protection
            /// </summary>
            public VmProt initprot;
            /// <summary>
            /// number of sections in segment
            /// </summary>
            public uint nsects;
            /// <summary>
            /// flags
            /// </summary>
            public SGFlags flags;
        };

        /// <summary>
        /// The 64-bit segment load command indicates that a part of this file is to be
        /// mapped into a 64-bit task's address space.  If the 64-bit segment has
        /// sections then section_64 structures directly follow the 64-bit segment
        /// command and their size is reflected in cmdsize.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SegmentCommand64
        {
            /// <summary>
            /// LC_SEGMENT_64
            /// </summary>
            public Cmd cmd;
            /// <summary>
            /// includes sizeof section_64 structs
            /// </summary>
            public uint cmdsize;
            /// <summary>
            /// segment name
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] segname;
            /// <summary>
            /// memory address of this segment
            /// </summary>
            public ulong  vmaddr;
            /// <summary>
            /// memory size of this segment
            /// </summary>
            public ulong  vmsize;
            /// <summary>
            /// file offset of this segment
            /// </summary>
            public ulong  fileoff;
            /// <summary>
            /// amount to map from the file
            /// </summary>
            public ulong  filesize;
            /// <summary>
            /// maximum VM protection
            /// </summary>
            public VmProt maxprot;
            /// <summary>
            /// initial VM protection
            /// </summary>
            public VmProt initprot;
            /// <summary>
            /// number of sections in segment
            /// </summary>
            public uint nsects;
            /// <summary>
            /// flags
            /// </summary>
            public SGFlags flags;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Section32
        {
            /// <summary>
            /// name of this section
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] sectname;
            /// <summary>
            /// segment this section goes in
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] segname;
            /// <summary>
            /// memory address of this section
            /// </summary>
            public uint addr;
            /// <summary>
            /// size in bytes of this section
            /// </summary>
            public uint size;
            /// <summary>
            /// file offset of this section
            /// </summary>
            public uint offset;
            /// <summary>
            /// section alignment (power of 2)
            /// </summary>
            public uint align;
            /// <summary>
            /// file offset of relocation entries
            /// </summary>
            public uint reloff;
            /// <summary>
            /// number of relocation entries
            /// </summary>
            public uint nreloc;
            /// <summary>
            /// flags (section type and attributes)
            /// </summary>
            public uint flags;
            /// <summary>
            /// reserved (for offset or index)
            /// </summary>
            public uint reserved1;
            /// <summary>
            /// reserved (for count or sizeof)
            /// </summary>
            public uint reserved2;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Section64
        {
            /// <summary>
            /// name of this section
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] sectname;
            /// <summary>
            /// segment this section goes in
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] segname;
            /// <summary>
            /// memory address of this section
            /// </summary>
            public ulong addr;
            /// <summary>
            /// size in bytes of this section
            /// </summary>
            public ulong size;
            /// <summary>
            /// file offset of this section
            /// </summary>
            public uint offset;
            /// <summary>
            /// section alignment (power of 2)
            /// </summary>
            public uint align;
            /// <summary>
            /// file offset of relocation entries
            /// </summary>
            public uint reloff;
            /// <summary>
            /// number of relocation entries
            /// </summary>
            public uint nreloc;
            /// <summary>
            /// flags (section type and attributes)
            /// </summary>
            public uint flags;
            /// <summary>
            /// reserved (for offset or index)
            /// </summary>
            public uint reserved1;
            /// <summary>
            /// reserved (for count or sizeof)
            /// </summary>
            public uint reserved2;
            /// <summary>
            /// reserved
            /// </summary>
            public uint reserved3;
        };

        public struct MachO32_Reader_Section
        {
            public SegmentCommand32 segment;
            public Section32[] sections;
        }

        public struct MachO64_Reader_Section
        {
            public SegmentCommand64 segment;
            public Section64[] sections;
        }

        #endregion File Header Structures

        #region Private Fields

        /// <summary>
        /// The MACHO32 Header
        /// </summary>
        private MACHO32_HDR macho32_hdr;
        /// <summary>
        /// The MACHO64 Header
        /// </summary>
        private MACHO64_HDR macho64_hdr;
        /// <summary>
        /// 
        /// </summary>
        private MachO32_Reader_Section[] macho32_sections_hdr;
        /// <summary>
        /// 
        /// </summary>
        private MachO64_Reader_Section[] macho64_sections_hdr;

        #endregion Private Fields

        #region Public Methods

        public MachOHeaderReader()
        { }

        public MachOHeaderReader(string filePath)
        {
            Parse(filePath);
        }

        /// <summary>
        /// Read the MachO Header
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
                HeaderMagic macho_magic = FromBinaryReader<HeaderMagic>(reader);

                stream.Seek(0, SeekOrigin.Begin);
                if (macho_magic == HeaderMagic.MH_MAGIC)
                {
                    macho32_hdr = FromBinaryReader<MACHO32_HDR>(reader);

                    macho32_sections_hdr = new MachO32_Reader_Section[macho32_hdr.ncmds];
                    for (int i = 0; i < macho32_hdr.ncmds; ++i)
                    {
                        macho32_sections_hdr[i].segment = FromBinaryReader<SegmentCommand32>(reader);
                        macho32_sections_hdr[i].sections = new Section32[macho32_sections_hdr[i].segment.nsects];
                        for (int j = 0; j < macho32_sections_hdr[i].segment.nsects; ++j)
                        {
                            macho32_sections_hdr[i].sections[j] = FromBinaryReader<Section32>(reader);
                        }
                    }

                    switch(macho32_hdr.filetype)
                    {
                        case FileType.MH_EXECUTE: _ExecutableType = ExecutableType.Executable; break;
                        case FileType.MH_DYLIB  : _ExecutableType = ExecutableType.Library; break;
                        default                 : _ExecutableType = ExecutableType.Unknown; break;
                    }

                    _IsValidHeader = true;
                    _Is32BitHeader = true;
                    _TargetOS = OsId.MacOSX;
                }
                else if(macho_magic == HeaderMagic.MH_MAGIC_64)
                {
                    macho64_hdr = FromBinaryReader<MACHO64_HDR>(reader);

                    macho64_sections_hdr = new MachO64_Reader_Section[macho64_hdr.ncmds];
                    for (int i = 0; i < macho64_hdr.ncmds; ++i)
                    {
                        macho64_sections_hdr[i].segment = FromBinaryReader<SegmentCommand64>(reader);
                        macho64_sections_hdr[i].sections = new Section64[macho64_sections_hdr[i].segment.nsects];
                        for (int j = 0; j < macho64_sections_hdr[i].segment.nsects; ++j)
                        {
                            macho64_sections_hdr[i].sections[j] = FromBinaryReader<Section64>(reader);
                        }
                    }

                    switch (macho64_hdr.filetype)
                    {
                        case FileType.MH_EXECUTE: _ExecutableType = ExecutableType.Executable; break;
                        case FileType.MH_DYLIB  : _ExecutableType = ExecutableType.Library; break;
                        default                 : _ExecutableType = ExecutableType.Unknown; break;
                    }

                    _IsValidHeader = true;
                    _Is32BitHeader = true;
                    _TargetOS = OsId.MacOSX;
                }
            }
        }

        #endregion Public Methods

        #region Properties

        /// <summary>
        /// Gets the MachO32 Header
        /// </summary>
        public MACHO32_HDR MachO32Header
        {
            get
            {
                return macho32_hdr;
            }
        }

        /// <summary>
        /// Gets the MachO64 Header
        /// </summary>
        public MACHO64_HDR MachO64Header
        {
            get
            {
                return macho64_hdr;
            }
        }

        public MachO32_Reader_Section[] MachO32SectionsHeader
        {
            get
            {
                return macho32_sections_hdr;
            }
        }

        public MachO64_Reader_Section[] MachO64SectionsHeader
        {
            get
            {
                return macho64_sections_hdr;
            }
        }

        #endregion Properties
    }
}