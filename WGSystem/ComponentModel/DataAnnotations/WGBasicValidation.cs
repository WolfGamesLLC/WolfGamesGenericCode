using System;
using System.Collections.Generic;
using System.Text;

namespace WGSystem.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Base class for the Wolf Games bridge to model validation objects
    /// </summary>
    public class WGBasicValidation : IWGValidation
    {
        /// <summary>
        /// Implementation associated with this client validation.
        /// Use constructor injection to provide your desired implementation.
        /// </summary>
        IWGValidationImplementation IValidationImplementation { get; set; }

        /// <summary>
        /// Create an instance of a WGBasicValidation bridge to a third part
        /// model validation implementation
        /// </summary>
        /// <param name="validationImplementation">A concrete implementation of a model validation system</param>
        public WGBasicValidation(IWGValidationImplementation validationImplementation)
        {
            IValidationImplementation = validationImplementation ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Pass an object to the concrete implementation of the validation system for validation
        /// </summary>
        /// <param name="model">The model to be validated</param>
        /// <returns>True if the object is valid</returns>
        public bool TryValidateObject(object model)
        {
            if(model == null) throw new ArgumentNullException();

            return IValidationImplementation.TryValidateObject(model);
        }

        /// <summary>
        /// Return a collection of results
        /// </summary>
        /// <returns>list of results</returns>
        public ICollection<IWGValidationResult> Result { get { return IValidationImplementation.Result; } }
    }
}
