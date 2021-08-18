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
using OSUtility;

namespace HeaderReader
{
    /// <summary>
    /// Abstract class to read an Executable Header
    /// </summary>
    public abstract class ExecutableHeaderReader : BaseHeaderReader
    {
        protected OsId _TargetOS = OsId.Unknown;

        public enum ExecutableType
        {
            Unknown    = 0x00,
            Executable = 0x01,
            Library    = 0x02,
        }

        protected bool _Is32BitHeader;
        protected ExecutableType _ExecutableType = ExecutableType.Unknown;

        /// <summary>
        /// Gets if the file header is 32 bit or not
        /// </summary>
        public bool Is32BitHeader
        {
            get { return _Is32BitHeader; }
        }

        public bool IsExecutable
        {
            get { return (_ExecutableType & ExecutableType.Executable) == ExecutableType.Executable; }
        }

        public bool IsLibrary
        {
            get { return (_ExecutableType & ExecutableType.Library) == ExecutableType.Library; }
        }

        public OsId TargetOS
        {
            get { return _TargetOS; }
        }
    }
}