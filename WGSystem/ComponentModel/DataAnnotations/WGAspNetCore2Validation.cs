using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WGSystem.Collections.Generic;

namespace WGSystem.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Implementation of ASP.Net Core 2.0 model validation 
    /// </summary>
    public class WGAspNetCore2Validation : IWGValidationImplementation
    {
        /// <summary>
        /// The collections factory used to create the generic IEnumerable <see cref="IWGValidationResult"/> list
        /// </summary>
        private WGGenericCollectionsFactory CollectionsFactory;

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="wGGenericCollectionsFactory">DI of WGGenericCollectionsFactory</param>
        public WGAspNetCore2Validation(WGGenericCollectionsFactory wGGenericCollectionsFactory)
        {
            CollectionsFactory = wGGenericCollectionsFactory;
            Result = CollectionsFactory.CreateList<IWGValidationResult>();
        }

        /// <summary>
        /// Return the results of the Validator.TryValidateObject call
        /// </summary>
        public ICollection<IWGValidationResult> Result { get; private set; }

        /// <summary>
        /// Setup and call Validator.TryValidateObject
        /// </summary>
        /// <param name="model">The model to be verified</param>
        /// <returns>True if the model passes</returns>
        public bool TryValidateObject(object model)
        {
            ValidationContext validationContext = new ValidationContext(model);
            var results = CollectionsFactory.CreateList<ValidationResult>();
            var rc = Validator.TryValidateObject(model, validationContext, results);

            foreach(ValidationResult result in results)
            {
                AddValidationResultToWGValidationResults(result);
            }

            return rc;
        }

        private void AddValidationResultToWGValidationResults(ValidationResult result)
        {
            Result.Add(new WGValidationResult(result.ErrorMessage));
        }
    }
}
