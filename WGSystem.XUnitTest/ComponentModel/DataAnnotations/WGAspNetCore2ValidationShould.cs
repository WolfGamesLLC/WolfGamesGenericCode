using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WGSystem.Collections.Generic;
using WGSystem.ComponentModel.DataAnnotations;
using Xunit;


namespace WGSystem.XUnitTest.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Test suite for the WGAspNetCore2Validation implementation of the model validation bridge
    /// </summary>
    public class WGAspNetCore2ValidationShould
    {
        /// <summary>
        /// Test model object
        /// </summary>
        public class TestModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        /// <summary>
        /// Implementation under test
        /// </summary>
        public IWGValidationImplementation Implementation { get; set; }

        /// <summary>
        /// Model used for testing
        /// </summary>
        public TestModel Model { get; set; }

        /// <summary>
        /// Create a default test object and test model
        /// </summary>
        public WGAspNetCore2ValidationShould()
        {
            Implementation = new WGAspNetCore2Validation(new WGGenericCollectionsFactory());
            Model = new TestModel();
        }

        /// <summary>
        /// Test the default constructor
        /// </summary>
        [Fact]
        public void CreateDefaultObject()
        {
            Assert.NotNull(new WGAspNetCore2Validation(new WGGenericCollectionsFactory()));
        }

        /// <summary>
        /// Test the ASP.NET Core 2.0 validation system with a good model
        /// </summary>
        [Fact]
        public void PassValidationWithGoodModel()
        {
            Model = new TestModel();
            Model.Email = "some.one@somewhere.com";
            Assert.True(Implementation.TryValidateObject(Model));
        }

        /// <summary>
        /// Test the ASP.NET Core 2.0 validation system with a bad model
        /// </summary>
        [Fact]
        public void FailValidationWithBadModel()
        {
            Model = new TestModel();
            Assert.False(Implementation.TryValidateObject(Model));
        }

        /// <summary>
        /// Test the ASP.NET Core 2.0 validation system results after a bad model
        /// </summary>
        [Fact]
        public void ReturnFailValidationResult()
        {
            var result = new WGValidationResult("The Email field is required.");
            Model = new TestModel();
            Implementation.TryValidateObject(Model);

            Assert.Equal(result, ((IList<IWGValidationResult>)Implementation.Result)[0]);
        }
    }
}
