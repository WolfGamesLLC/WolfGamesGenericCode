using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WGXUnit.Facts;
using Xunit;
using Xunit.Abstractions;

namespace WGXUnit.XUnitTest.Facts
{
    /// <summary>
    /// Verify facts related to a fact that should write data to 
    /// stdout
    /// </summary>
    public class FactWriteToStdOutShould
    {
        [Fact]
        public void WriteOutputToStdOut()
        {
            var mockOutputHelper = new Mock<ITestOutputHelper>();
            string message = "Test Output";

            var factWriteToStdOut = new FactWriteToStdOut(mockOutputHelper.Object);
            factWriteToStdOut.OutputHelper.WriteLine(message);
            mockOutputHelper.Verify(mock => mock.WriteLine(message), Times.Once);
        }
    }
}
