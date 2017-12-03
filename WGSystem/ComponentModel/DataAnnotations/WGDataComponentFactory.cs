using System;
using System.Collections.Generic;

namespace WGSystem.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Abstract factory for creation of data annotation components
    /// </summary>
    public class WGDataComponentFactory
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public WGDataComponentFactory()
        {
        }

        /// <summary>
        /// Create a validation result
        /// </summary>
        /// <param name="errorMessage">The results error message</param>
        /// <returns>An object that implements an IWGValidationResult interface</returns>
        public IWGValidationResult CreateValidationResult(string errorMessage)
        {
            return new WGValidationResult(errorMessage);
        }

        /// <summary>
        /// Create a validation result
        /// </summary>
        /// <param name="errorMessage">The results error message</param>
        /// <param name="memberNames">The list of members in the model that have validation errors</param>
        /// <param name="success">The validation state</param>
        /// <returns>An object that implements an IWGValidationResult interface</returns>
        public IWGValidationResult CreateValidationResult(string errorMessage, IList<string> memberNames, bool success)
        {
            return new WGValidationResult(errorMessage, memberNames, success);
        }
    }
}