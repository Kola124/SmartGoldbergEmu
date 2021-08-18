/* Copyright (C) 2019 Nemirtingas
   This file is part of the NemirtingasEmuLauncher Launcher

   The NemirtingasEmuLauncher Launcher is free software; you can redistribute it and/or
   modify it under the terms of the GNU Lesser General Public
   License as published by the Free Software Foundation; either
   version 3 of the License, or (at your option) any later version.

   The NemirtingasEmuLauncher Launcher is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
   Lesser General Public License for more details.

   You should have received a copy of the GNU Lesser General Public
   License along with the NemirtingasEmuLauncher; if not, see
   <http://www.gnu.org/licenses/>.
 */
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

using System.Windows.Forms;
using System.Threading.Tasks;
using System.ComponentModel;

namespace NemirtingasEmuLauncher
{
    public class MacOsIpcServer
    {
        [DllImport("/usr/lib/system/libxpc")]
        static extern kern_return_t bootstrap_check_in(uint bp, string service_name, out uint sp);

        [DllImport("/usr/lib/system/libxpc")]
        static extern kern_return_t bootstrap_register(uint bp, string service_name, uint sp);

        [DllImport("/usr/lib/system/libxpc")]
        static extern kern_return_t mach_msg(IntPtr msg, MACH_MSG_OPTION option, uint send_size, uint rcv_size, uint rcv_name, uint timeout, uint notify);

        [DllImport("libdl")]
        static extern IntPtr dlopen(string name, RTLD_FLAGS mode);

        [DllImport("libdl")]
        static extern IntPtr dlsym(IntPtr lib, string name);

        [DllImport("libdl")]
        static extern void dlclose(IntPtr lib);

        /// <summary>
        /// The MODE argument to `dlopen' contains one of the following:
        /// </summary>
        [Flags]
        public enum RTLD_FLAGS : int
        {
            /// <summary>
            /// Unix98 demands the following flag which is the inverse to RTLD_GLOBAL.
            /// The implementation does this by default and so we can define the
            ///   */
            /// </summary>
            RTLD_LOCAL        = 0x0,
            /// <summary>
            /// Lazy function call binding.
            /// </summary>
            RTLD_LAZY         = 0x00001,
            /// <summary>
            /// Immediate function call binding.
            /// </summary>
            RTLD_NOW          = 0x00002,
            /// <summary>
            /// Mask of binding time value.
            /// </summary>
            RTLD_BINDING_MASK = 0x00003,
            /// <summary>
            /// Do not load the object.
            /// </summary>
            RTLD_NOLOAD       = 0x00004,
            /// <summary>
            /// Use deep binding.
            /// </summary>
            RTLD_DEEPBIND     = 0x00008,
            /// <summary>
            /// If the following bit is set in the MODE argument to `dlopen',
            /// the symbols of the loaded object and its dependencies are made
            /// visible as if the object were linked directly into the program.
            /// </summary>
            RTLD_GLOBAL       = 0x00100,
            /// <summary>
            /// Do not delete object when closed.
            /// </summary>
            RTLD_NODELETE     = 0x01000,
        }

        public enum kern_return_t : uint
        {
            KERN_SUCCESS = 0,
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct mach_msg_header_t
        {
            public uint msgh_bits;
            public uint msgh_size;
            public uint msgh_remote_port;
            public uint msgh_local_port;
            public uint msgh_reserved;
            public uint msgh_id;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct mach_msg_trailer_t
        {
            public uint msgh_trailer_type;
            public uint msgh_trailer_size;
        }

        [Flags]
        public enum MACH_MSG_OPTION : uint
        {
            MACH_MSG_OPTION_NONE    = 0x00000000,
            MACH_SEND_MSG           = 0x00000001,
            MACH_RCV_MSG            = 0x00000002,
            MACH_RCV_LARGE          = 0x00000004, /* report large message sizes */
            MACH_RCV_LARGE_IDENTITY = 0x00000008, /* identify source of large messages */
            MACH_SEND_TIMEOUT       = 0x00000010, /* timeout value applies to send */
            MACH_SEND_OVERRIDE      = 0x00000020, /* priority override for send */
            MACH_SEND_INTERRUPT     = 0x00000040, /* don't restart interrupted sends */
            MACH_SEND_NOTIFY        = 0x00000080, /* arm send-possible notify */
            MACH_RCV_TIMEOUT        = 0x00000100, /* timeout value applies to receive */
            MACH_RCV_NOTIFY         = 0x00000200, /* reserved - legacy */
            MACH_RCV_INTERRUPT      = 0x00000400, /* don't restart interrupted receive */
            MACH_RCV_VOUCHER        = 0x00000800, /* willing to receive voucher port */
            MACH_RCV_OVERWRITE      = 0x00001000, /* scatter receive (deprecated) */
            MACH_RCV_SYNC_WAIT      = 0x00004000, /* sync waiter waiting for rcv */
            MACH_SEND_ALWAYS        = 0x00010000, /* ignore qlimits - kernel only */
            MACH_SEND_TRAILER       = 0x00020000, /* sender-provided trailer */
            MACH_SEND_NOIMPORTANCE  = 0x00040000, /* msg won't carry importance */
            MACH_SEND_NODENAP       = MACH_SEND_NOIMPORTANCE,
            MACH_SEND_IMPORTANCE    = 0x00080000, /* msg carries importance - kernel only */
            MACH_SEND_SYNC_OVERRIDE = 0x00100000,
        }

        public enum STEAM_IPC : uint
        {
            STEAM_IPC5         = 5,
            GETSTEAMPID        = 11,
            SETSTEAMPID        = 12,
            GETSTEAMPATH       = 13,
            GETSTEAMCLIENTPATH = 14,
            KILLCMD            = 100000,
            GETVERSION         = 100001,
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public unsafe struct steam_ipc_cmd
        {
            public mach_msg_header_t msg;
            public STEAM_IPC msg_type;
            public int arg1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
            public fixed byte buff[512];
            public mach_msg_trailer_t trailer;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct SteamMachMsg5Send
        {
            public mach_msg_header_t msg;
            public int unknown1;
            public int unknown2;
            public int unknown3;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct SteamMachMsgVersionSend
        {
            public mach_msg_header_t msg;
            public int unused;
            public int version;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public unsafe struct SteamMachMsgPathSend
        {
            public mach_msg_header_t msg;
            public int unused;
            public int pid;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
            public fixed byte buff[512];
        }

        private string steam_ipc_server = "com.valvesoftware.steam.ipctool";
        private uint steam_ipc_version = 104;

        IntPtr bootstrap_port_addr = IntPtr.Zero;
        uint bootstrap_port = 0;
        uint service_rcv_port = 0;

        IntPtr libsystem_kernel = IntPtr.Zero;

        string steam_path = "";
        int steam_pid = Process.GetCurrentProcess().Id;

        CancellationTokenSource cts;
        public event EventHandler IpcServerStopped;
        public event EventHandler IpcServerStarted;

        public MacOsIpcServer()
        {
            if (OSFuncs.IsMacOS())
            {
                try
                {
                    libsystem_kernel = dlopen("/usr/lib/system/libsystem_kernel.dylib", RTLD_FLAGS.RTLD_NOW);
                    if (libsystem_kernel != IntPtr.Zero)
                    {
                        bootstrap_port_addr = dlsym(libsystem_kernel, "bootstrap_port");
                        int[] variable = new int[1];
                        Marshal.Copy(bootstrap_port_addr, variable, 0, 1);

                        bootstrap_port = (uint)variable[0];

                        dlclose(libsystem_kernel);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public void StartIpcServer()
        {
            if (OSFuncs.IsMacOS())
            {
                if (service_rcv_port == 0)
                {
                    kern_return_t kr = bootstrap_check_in(bootstrap_port, steam_ipc_server, out service_rcv_port);
                    if (kr != kern_return_t.KERN_SUCCESS)
                        return;
                }

                cts = new CancellationTokenSource();
                Task.Factory.StartNew(IpcServerThread, cts.Token)
                    .ContinueWith(t => { OnIpcServerStopped(); });
            }
        }

        public void StopIpcServer()
        {
            if (OSFuncs.IsMacOS())
            {
                cts.Cancel();
            }
        }

        private void RaiseEvent(Delegate[] invocationList)
        {
            if (invocationList == null)
            {
                return;
            }
            //Pour chacun des délégués enregistrés,
            foreach (var del in invocationList)
            {
                //On récupère le contexte de synchronisation
                ISynchronizeInvoke syncer = del.Target as ISynchronizeInvoke;
                if (syncer != null)
                {
                    //si il existe, on invoke le délégué sur ce contexte. Ce qui permet de déclencher l'évènement
                    // sur le thread UI si l'évènement est enregistré dans le thread UI
                    syncer.BeginInvoke(del, new object[] { this, EventArgs.Empty });
                }
                else
                {
                    //s'il n'y a pas de contexte, on invoke simplement le délégué
                    del.DynamicInvoke(this, EventArgs.Empty);
                }
            }
        }

        private void OnIpcServerStarted()
        {
            RaiseEvent(IpcServerStarted?.GetInvocationList());
        }
        private void OnIpcServerStopped()
        {
            RaiseEvent(IpcServerStopped?.GetInvocationList());
        }

        private unsafe void IpcServerThread(object tkn)
        {
            CancellationToken token = (CancellationToken)tkn;
            OnIpcServerStarted();
            while (!token.IsCancellationRequested)
            {
                steam_ipc_cmd ipc_cmd = new steam_ipc_cmd();
                ipc_cmd.msg.msgh_size = (uint)Marshal.SizeOf(ipc_cmd);
                ipc_cmd.msg.msgh_local_port = service_rcv_port;

                GCHandle ipc_handle = GCHandle.Alloc(ipc_cmd, GCHandleType.Pinned);

                if (mach_msg(ipc_handle.AddrOfPinnedObject(), MACH_MSG_OPTION.MACH_RCV_MSG | MACH_MSG_OPTION.MACH_RCV_TIMEOUT, 0, ipc_cmd.msg.msgh_size, ipc_cmd.msg.msgh_local_port, 2000, 0) == kern_return_t.KERN_SUCCESS)
                {
                    ipc_cmd = (steam_ipc_cmd)Marshal.PtrToStructure(ipc_handle.AddrOfPinnedObject(), typeof(steam_ipc_cmd));

                    switch (ipc_cmd.msg_type)
                    {
                        case STEAM_IPC.STEAM_IPC5:
                            {
                                SteamMachMsg5Send buff = new SteamMachMsg5Send();

                                buff.msg.msgh_size = (uint)Marshal.SizeOf(buff);
                                buff.msg.msgh_local_port = 0;
                                buff.msg.msgh_remote_port = ipc_cmd.msg.msgh_remote_port;
                                buff.msg.msgh_bits = (ipc_cmd.msg.msgh_bits >> 8) & 0x1F;
                                buff.msg.msgh_id = steam_ipc_version;
                                buff.unknown1 = 0;
                                buff.unknown2 = 0;

                                GCHandle handle = GCHandle.Alloc(buff, GCHandleType.Pinned);
                                mach_msg(handle.AddrOfPinnedObject(), MACH_MSG_OPTION.MACH_SEND_MSG | MACH_MSG_OPTION.MACH_SEND_TIMEOUT, buff.msg.msgh_size, 0, 0, 2000, 0);
                                handle.Free();
                            }
                            break;

                        case STEAM_IPC.GETVERSION:
                            {
                                SteamMachMsgVersionSend buff = new SteamMachMsgVersionSend();

                                buff.msg.msgh_size = (uint)Marshal.SizeOf(buff);
                                buff.msg.msgh_local_port = 0;
                                buff.msg.msgh_remote_port = ipc_cmd.msg.msgh_remote_port;
                                buff.msg.msgh_bits = (ipc_cmd.msg.msgh_bits >> 8) & 0x1F;
                                buff.msg.msgh_id = steam_ipc_version;
                                buff.version = (int)steam_ipc_version;

                                GCHandle handle = GCHandle.Alloc(buff, GCHandleType.Pinned);
                                mach_msg(handle.AddrOfPinnedObject(), MACH_MSG_OPTION.MACH_SEND_MSG | MACH_MSG_OPTION.MACH_SEND_TIMEOUT, buff.msg.msgh_size, 0, 0, 2000, 0);
                                handle.Free();
                            }
                            break;

                        case STEAM_IPC.KILLCMD:
                            break;

                        case STEAM_IPC.GETSTEAMPID:
                            break;

                        case STEAM_IPC.SETSTEAMPID:
                            {
                                byte[] arr = new byte[512];
                                Marshal.Copy((IntPtr)ipc_cmd.buff, arr, 0, 512);
                                steam_path = Encoding.UTF8.GetString(arr);
                                steam_pid = ipc_cmd.arg1;
                            }
                            break;

                        case STEAM_IPC.GETSTEAMPATH:
                            {
                                SteamMachMsgPathSend buff = new SteamMachMsgPathSend();

                                buff.msg.msgh_size = (uint)Marshal.SizeOf(buff);
                                buff.msg.msgh_local_port = 0;
                                buff.msg.msgh_remote_port = ipc_cmd.msg.msgh_remote_port;
                                buff.msg.msgh_bits = (ipc_cmd.msg.msgh_bits >> 8) & 0x1F;
                                buff.msg.msgh_id = steam_ipc_version;
                                buff.pid = steam_pid;
                                //buff.buff = steam_path;

                                GCHandle handle = GCHandle.Alloc(buff, GCHandleType.Pinned);
                                mach_msg(handle.AddrOfPinnedObject(), MACH_MSG_OPTION.MACH_SEND_MSG | MACH_MSG_OPTION.MACH_SEND_TIMEOUT, buff.msg.msgh_size, 0, 0, 2000, 0);
                                handle.Free();
                            }
                            break;

                        case STEAM_IPC.GETSTEAMCLIENTPATH:
                            {
                                SteamMachMsgPathSend buff = new SteamMachMsgPathSend();

                                buff.msg.msgh_size = (uint)Marshal.SizeOf(buff);
                                buff.msg.msgh_local_port = 0;
                                buff.msg.msgh_remote_port = ipc_cmd.msg.msgh_remote_port;
                                buff.msg.msgh_bits = (ipc_cmd.msg.msgh_bits >> 8) & 0x1F;
                                buff.msg.msgh_id = steam_ipc_version;
                                buff.pid = steam_pid;

                                string apifolder = OSFuncs.GetMacOSEmuApiFolder(false);
                                byte[] apistr = Encoding.UTF8.GetBytes(apifolder);

                                for (int i = 0; i < (apistr.Length > 511 ? 511 : apistr.Length); ++i)
                                {
                                    buff.buff[i] = apistr[i];
                                }
                                buff.buff[apistr.Length] = (byte)0;

                                GCHandle handle = GCHandle.Alloc(buff, GCHandleType.Pinned);
                                mach_msg(handle.AddrOfPinnedObject(), MACH_MSG_OPTION.MACH_SEND_MSG | MACH_MSG_OPTION.MACH_SEND_TIMEOUT, buff.msg.msgh_size, 0, 0, 2000, 0);
                                handle.Free();
                            }
                            break;
                    }
                }
                ipc_handle.Free();
            }
            token.ThrowIfCancellationRequested();
        }
    }
}
