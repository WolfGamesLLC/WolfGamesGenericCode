using System;
using System.Collections.Generic;
using System.Text;

namespace WGSystem.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Client side of the bride to model validation objects
    /// </summary>
    public interface IWGValidation
    {
        /// <summary>
        /// Pass an object to the concrete implementation of the validation system for validation
        /// </summary>
        /// <param name="model">The model to be validated</param>
        /// <returns>True if the object is valid</returns>
        bool TryValidateObject(object model);

        /// <summary>
        /// Return a collection of results
        /// </summary>
        /// <returns>list of results</returns>
        ICollection<IWGValidationResult> Result { get;  }
    }
}
