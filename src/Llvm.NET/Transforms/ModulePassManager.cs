﻿// -----------------------------------------------------------------------
// <copyright file="ModulePassManager.cs" company="Ubiquity.NET Contributors">
// Copyright (c) Ubiquity.NET Contributors. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Ubiquity.ArgValidators;

using static Llvm.NET.Interop.NativeMethods;

namespace Llvm.NET.Transforms
{
    /// <summary>Pass manager for running passes against an entire module</summary>
    public sealed class ModulePassManager
        : PassManager
    {
        /// <summary>Initializes a new instance of the <see cref="ModulePassManager"/> class.</summary>
        public ModulePassManager( )
            : base( LLVMCreatePassManager( ) )
        {
        }

        /// <summary>Runs the passes added to this manager for the target module</summary>
        /// <param name="target">Module to run the passes on</param>
        /// <returns><see langword="true"/> if one of the passes modified the module</returns>
        public bool Run( BitcodeModule target )
        {
            target.ValidateNotNull( nameof( target ) );
            return LLVMRunPassManager( Handle, target.ModuleHandle );
        }
    }
}
