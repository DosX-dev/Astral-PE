/*
 * This file is part of the Astral-PE project.
 * Copyright (c) 2025 DosX. All rights reserved.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
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

using System;

namespace AstralPE.Obfuscator {
    /// <summary>
    /// Exception thrown when the PE image is invalid or incomplete.
    /// Used to halt obfuscation safely if a structural inconsistency is detected.
    /// </summary>
    public class InvalidPeImageException : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPeImageException"/> class.
        /// </summary>
        public InvalidPeImageException() : base("The PE image is invalid or corrupted.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPeImageException"/> class with a custom message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidPeImageException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPeImageException"/> class with a custom message and inner exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidPeImageException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}