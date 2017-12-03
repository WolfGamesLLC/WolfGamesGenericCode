using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WGSystem.ComponentModel.DataAnnotations;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace WGSystem.XUnitTest.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Test suite for the <see cref="WGBasicValidation"/> implementation of the model validation client interface
    /// </summary>
    public class WGBasicValidationShould
    {
        /// <summary>
        /// Holds the test object
        /// </summary>
        public WGBasicValidation BasicValidation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Mock<IWGValidationImplementation> MockImplementation { get; set; }

        /// <summary>
        /// Construct the test suite object and inject a mock object that implements
        /// IWGValidationImplementation
        /// </summary>
        public WGBasicValidationShould()
        {
            MockImplementation = new Mock<IWGValidationImplementation>();
            BasicValidation = new WGBasicValidation(MockImplementation.Object);
        }

        /// <summary>
        /// Test that a <see cref="WGBasicValidation"/> object created with null 
        /// throws an InvalidTypeException
        /// </summary>
        [Fact]
        public void ThrowInvalidTypeExceptionWhenConstructedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => new WGBasicValidation(null));
        }

        /// <summary>
        /// Test that a <see cref="WGBasicValidation"/> object can be created
        /// </summary>
        [Fact]
        public void CreateWhenPassedAnIWGValidationImplementationObject()
        {
            Assert.NotNull(new WGBasicValidation(new Mock<IWGValidationImplementation>().Object));
        }

        /// <summary>
        /// Test that ArgumentNullException is thrown when validation is attempted on a null object
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromTryValidateObject()
        {
            Assert.Throws<ArgumentNullException>(() => BasicValidation.TryValidateObject(null));
        }

        /// <summary>
        /// Test to verify that the object is passed to the implementation's TryValidatObject
        /// </summary>
        [Fact]
        public void PassObjectToImplementation()
        {
            object model = new object();
            MockImplementation.Setup(val => val.TryValidateObject(model))
                .Returns(true);
            Assert.True(BasicValidation.TryValidateObject(model));
        }

        /// <summary>
        /// Test to verify that the results can be retrieved from an implementation
        /// </summary>
        [Fact]
        public void GetResultsFromImplementation()
        {
            object model = new object();
            List<IWGValidationResult> result = new List<IWGValidationResult>();
            result.Add(new WGValidationResult("Error message"));

            MockImplementation.Setup(val => val.Result)
                .Returns(result);
            Assert.Equal(result, BasicValidation.Result);
        }
    }
}
