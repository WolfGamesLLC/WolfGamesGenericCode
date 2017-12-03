using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WGSystem.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Implementation side of the bridge to model validation objects
    /// </summary>
    public interface IWGValidationImplementation
    {
        /// <summary>
        /// Try to validate the model
        /// </summary>
        /// <param name="model">An object model</param>
        /// <returns>True if the validation passes</returns>
        bool TryValidateObject(Object model);

        /// <summary>
        /// Return the results of a failed validation
        /// </summary>
        ICollection<IWGValidationResult> Result { get; }
    }
}
