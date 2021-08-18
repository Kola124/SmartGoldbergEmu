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

namespace HeaderReader
{
    /// <summary>
    /// Abstract class about a file header
    /// </summary>
    public abstract class BaseHeaderReader
    {
        protected bool _IsValidHeader = false;

        /// <summary>
        /// Reads in a block from a file and converts it to the struct
        /// type specified by the template parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static T FromBinaryReader<T>(BinaryReader reader)
        {
            Type OutType = typeof(T).IsEnum ? Enum.GetUnderlyingType(typeof(T)) : typeof(T);
            // Read in a byte array
            byte[] bytes = reader.ReadBytes(Marshal.SizeOf(OutType));

            // Pin the managed memory while, copy it out the data, then unpin it
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), OutType);
            handle.Free();

            return theStructure;
        }

        /// <summary>
        /// Read the File Header
        /// </summary>
        /// <returns></returns>
        public abstract void Parse(string filePath);

        /// <summary>
        /// Gets if the header is valid
        /// </summary>
        /// <returns></returns>
        public bool IsValidHeader
        {
            get { return _IsValidHeader; }
        }
    }
}