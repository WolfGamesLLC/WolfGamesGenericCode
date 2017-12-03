using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using WGSystem.ComponentModel.DataAnnotations;
using WGSystem.Collections.Generic;

namespace WGSystem.XUnitTest.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Test suite for the WGValidationResult proxy
    /// </summary>
    public class WGValidationResultShould
    {
        /// <summary>
        /// Generic string for use with testing
        /// </summary>
        private readonly string ERROR_MESSAGE = "Error Message";

        /// <summary>
        /// The test object
        /// </summary>
        private WGValidationResult wgValidationResultUnderTest;

        /// <summary>
        /// Collections factory for access to Generic collections
        /// </summary>
        public WGGenericCollectionsFactory CollectionsFactory { get; set; }

        /// <summary>
        /// Construct the default test object
        /// </summary>
        public WGValidationResultShould()
        {
            wgValidationResultUnderTest = new WGValidationResult(ERROR_MESSAGE);
            CollectionsFactory = new WGGenericCollectionsFactory();
        }

        /// <summary>
        /// Test that the object is created when passed a string
        /// </summary>
        [Fact]
        public void CreateWithOnlyErrorMessageStringArgument()
        {
            Assert.NotNull(new WGValidationResult(ERROR_MESSAGE));
        }

        /// <summary>
        /// Test that the object is created with null
        /// </summary>
        [Fact]
        public void CreateWithNull()
        {
            Assert.NotNull(new WGValidationResult(null));
        }

        /// <summary>
        /// Test that the object error message is null when created with null
        /// </summary>
        [Fact]
        public void CreateSetErrorMessageNull()
        {
            Assert.Null(new WGValidationResult(null).ErrorMessage);
        }

        /// <summary>
        /// Test the ErrorMessage get property
        /// </summary>
        [Fact]
        public void ReturnErrorMessage()
        {
            Assert.Equal(ERROR_MESSAGE, wgValidationResultUnderTest.ErrorMessage);
        }

        /// <summary>
        /// Test the ErrorMessage set property
        /// </summary>
        [Fact]
        public void SetErrorMessage()
        {
            string errorMessage = "New Error Message";
            wgValidationResultUnderTest.ErrorMessage = errorMessage;
            Assert.Equal(errorMessage, wgValidationResultUnderTest.ErrorMessage);
        }

        /// <summary>
        /// Test the equal operation with the same object
        /// </summary>
        [Fact]
        public void ReturnEqualWithSameObject()
        {
            Assert.Equal(wgValidationResultUnderTest, wgValidationResultUnderTest);
        }

        /// <summary>
        /// Test the equal operation with different objects
        /// </summary>
        [Fact]
        public void ReturnEqualWithDifferentObjectsWithSameValues()
        {
            Assert.Equal(wgValidationResultUnderTest, new WGValidationResult(ERROR_MESSAGE));
        }

        /// <summary>
        /// Test the equal operation with different error messages
        /// </summary>
        [Fact]
        public void ReturnNotEqualWithDifferentErrorMessageValues()
        {
            Assert.NotEqual(wgValidationResultUnderTest, new WGValidationResult("Hello World"));
        }

        /// <summary>
        /// Test the equal operation with different member names
        /// </summary>
        [Fact]
        public void ReturnNotEqualWithDifferentMemberNames()
        {
            var expectedResult = wgValidationResultUnderTest.Clone();
            var list = CollectionsFactory.CreateList<string>();
            list.Add("name");

            expectedResult.MemberNames = list;
            Assert.NotEqual(expectedResult, wgValidationResultUnderTest);
        }

        /// <summary>
        /// Test the equal operation with different Success
        /// </summary>
        [Fact]
        public void ReturnNotEqualWithDifferentSuccessValues()
        {
            var expectedResult = wgValidationResultUnderTest.Clone();
            expectedResult.Success = true;
            Assert.NotEqual(expectedResult, wgValidationResultUnderTest);
        }

        /// <summary>
        /// Test the MemberNames property
        /// </summary>
        [Fact]
        public void SetMemberNamesProperty()
        {
            IList<string> memberNames = CollectionsFactory.CreateList<string>();
            memberNames.Add("New member name");
            wgValidationResultUnderTest.MemberNames = memberNames;
            Assert.Equal(memberNames, wgValidationResultUnderTest.MemberNames);
        }

        /// <summary>
        /// Test the Success property
        /// </summary>
        [Fact]
        public void SetSuccessProperty()
        {
            bool success = true;
            wgValidationResultUnderTest.Success = success;
            Assert.Equal(success, wgValidationResultUnderTest.Success);
        }

        [Fact]
        public void CreateClone()
        {
            Assert.NotSame(wgValidationResultUnderTest, wgValidationResultUnderTest.Clone());
        }
    }
}
