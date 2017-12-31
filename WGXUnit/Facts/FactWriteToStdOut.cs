using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace WGXUnit.Facts
{
    /// <summary>
    /// Base fact object that allows writing from 
    /// tests to std out
    /// </summary>
    public class FactWriteToStdOut : IDisposable
    {
        /// <summary>
        /// Exposes the output helper
        /// </summary>
        public ITestOutputHelper OutputHelper { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="outputHelper">An object that implements ITestOutputHelper</param>
        public FactWriteToStdOut(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }

        /// <summary>
        /// Allow test suites to dispose of test objects 
        /// </summary>
        public void Dispose()
        {
        }
    }
}
