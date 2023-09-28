﻿using Bonsai;
using System;
using System.ComponentModel;
using System.Reactive.Linq;
using LibGit2Sharp;

namespace AllenNeuralDynamics.Git
{
    /// <summary>
    /// Represents an operator that populates a Repository object from a target folder path
    /// </summary>
    [DefaultProperty("Path")]
    [Description("Returns a new Repository object (LibGit2Sharp) for the specified repository root path. Accepts relative or absolute paths.")]
    public class CreateRepository : Source<Repository>
    {
        /// <summary>
        /// Gets or sets path for the targeted repository.
        /// </summary>
        [Editor("Bonsai.Design.FolderNameEditor, Bonsai.Design", DesignTypes.UITypeEditor)]
        [Description("The relative or absolute path of the selected repository root.")]
        public string Path { get; set; } = "../.";

        /// <summary>
        /// Generates an observable with a single Repository object from a given root path.
        /// </summary>
        /// <returns>
        /// A sequence of <see cref="Repository"/> objects representing a git repository.
        /// </returns>
        public override IObservable<Repository> Generate()
        {
            return Observable.Defer(() => {
                return Observable.Return(new Repository(Path));
                });
        }
    }
}

/*
This file was adapted from https://github.com/SainsburyWellcomeCentre/aeon_acquisition under the following license:
BSD 3-Clause License

Copyright (c) 2023 University College London
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its
   contributors may be used to endorse or promote products derived from
   this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
