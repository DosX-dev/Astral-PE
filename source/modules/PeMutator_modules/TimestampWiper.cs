/*
 * This file is part of the Astral-PE project.
 * Copyright (c) 2025 DosX. All rights reserved.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the �Software�), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 * Astral-PE is a low-level post-compilation PE header mutator (obfuscator) for native
 * Windows x86/x64 binaries. It modifies structural metadata while preserving execution integrity.
 *
 * For source code, updates, and documentation, visit:
 * https://github.com/DosX-dev/Astral-PE
 */

using PeNet;

namespace AstralPE.Obfuscator.Modules {
    public class TimestampWiper : IAstralPeModule {

        /// <summary>
        /// Erases the TimeDateStamp from IMAGE_FILE_HEADER at offset (e_lfanew + 8).
        /// This removes the build timestamp metadata used for file versioning.
        /// </summary>
        /// <param name="raw">The raw byte array of the PE file.</param>
        /// <param name="pe">Parsed PE file structure (not directly used here).</param>
        /// <param name="e_lfanew">Offset to IMAGE_NT_HEADERS.</param>
        /// <param name="optStart">Offset to IMAGE_OPTIONAL_HEADER.</param>
        /// <param name="sectionTableOffset">Offset to section headers.</param>
        /// <param name="rnd">Random instance (not used).</param>
        public void Apply(ref byte[] raw, PeFile pe, int e_lfanew, int optStart, int sectionTableOffset, Random rnd) {
            int offset = e_lfanew + 8;

            // Offset sanity check
            if (e_lfanew <= 0 || e_lfanew > raw.Length)
                throw new InvalidPeImageException();

            // Ensure the field lies within bounds
            if (offset + 4 > raw.Length)
                throw new IndexOutOfRangeException("TimeDateStamp offset exceeds file size.");

            // Apply mutation
            Array.Clear(raw, offset, 4);
        }
    }
}
