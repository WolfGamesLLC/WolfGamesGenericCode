using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WGSystem.Collections.Generic;
using System.Collections;

namespace WGSystem.XUnitTest.Collections.Generic
{
    /// <summary>
    /// Test suite for the WGGenericCollectionsFactory 
    /// </summary>
    public class WGGenericCollectionsFactoryShould
    {
        /// <summary>
        /// Should create an instance of the WGGenericCollectionsFactory class
        /// </summary>
        [Fact]
        public void ShouldCreateWGGenericCollectionsFactory()
        {
            Assert.NotNull(new WGGenericCollectionsFactory());
        }

        /// <summary>
        /// Should create an instance of an obejct that implements the IList generic interface
        /// </summary>
        [Fact]
        public void ShouldCreateIListObject()
        {
            Assert.IsAssignableFrom<IList<int>>(new WGGenericCollectionsFactory().CreateList<int>());
        }
    }
}
