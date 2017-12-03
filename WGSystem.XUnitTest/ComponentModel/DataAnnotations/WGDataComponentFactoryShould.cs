using System;
using System.Collections.Generic;
using System.Text;
using WGSystem.Collections.Generic;
using WGSystem.ComponentModel.DataAnnotations;
using Xunit;

namespace WGSystem.XUnitTest.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Test suite for the abstract data annotations component model factory
    /// </summary>
    public class WGDataComponentFactoryShould
    {
        /// <summary>
        /// The object used for testing
        /// </summary>
        public WGDataComponentFactory ComponentFactory { get; private set; }

        /// <summary>
        /// Collection factory to be used in testing
        /// </summary>
        public WGGenericCollectionsFactory CollectionFactory { get; private set; }

        /// <summary>
        /// Test setup
        /// </summary>
        public WGDataComponentFactoryShould()
        {
            ComponentFactory = new WGDataComponentFactory();
            CollectionFactory = new WGGenericCollectionsFactory();
        }

        /// <summary>
        /// Test the default constructor
        /// </summary>
        [Fact]
        public void CreateDefaultFactory()
        {
            Assert.NotNull(new WGDataComponentFactory());
        }

        /// <summary>
        /// Test creation of a validation result with an error message
        /// </summary>
        [Fact]
        public void CreateWGValidationResultWithErrorMessage()
        {
            string expectedString = "Error Message";

            var res = ComponentFactory.CreateValidationResult(expectedString);

            Assert.IsAssignableFrom<IWGValidationResult>(res);
            Assert.Equal(expectedString, res.ErrorMessage);
        }

        /// <summary>
        /// Test creation of a validation result with an error message, list of member names and a success value
        /// </summary>
        [Fact]
        public void CreateWGValidationResultWithErrorMessageMemberNamesAndSuccess()
        {
            string expectedString = "Expected Text";
            IList<string> expectedNames = CollectionFactory.CreateList<string>();
            expectedNames.Add(expectedString);
            bool expectedSuccess = true;

            var res = ComponentFactory.CreateValidationResult(expectedString, expectedNames, expectedSuccess);

            Assert.IsAssignableFrom<IWGValidationResult>(res);
            Assert.Equal(expectedString, res.ErrorMessage);
            Assert.Equal(expectedNames, res.MemberNames);
            Assert.Equal(expectedSuccess, res.Success);
        }
    }
}
