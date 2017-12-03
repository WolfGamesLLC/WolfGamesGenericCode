using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WGXUnit.XUnitTest.Facts
{
    /// <summary>
    /// Verify facts related to a fact that should write data to 
    /// stdout
    /// </summary>
    public class FactWriteToStdOutShould
    {
        [Fact]
        public void RequireITestOutputHelperAtConstruction()
        {
            var factWriteToStdOut = new FactWriteToStdOut();
        }
    }
}
