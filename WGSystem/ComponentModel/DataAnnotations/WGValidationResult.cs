using System;
using System.Collections.Generic;

namespace WGSystem.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Proxy to isolate Wolf Games code from Microsoft's validation system code
    /// </summary>
    public class WGValidationResult : IWGValidationResult
    {
        /// <summary>
        /// The error message associated with the result
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The list of member names that have failed messages
        /// </summary>
        public IEnumerable<string> MemberNames { get; set; }

        /// <summary>
        /// The status of the validation
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public WGValidationResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Constructor to create a WGValidationResult from individual data elements
        /// </summary>
        /// <param name="errorMessage">The results error message</param>
        /// <param name="memberNames">The list of members that failed validation</param>
        /// <param name="success">The state of the validation</param>
        public WGValidationResult(string errorMessage, IEnumerable<string> memberNames, bool success) : this(errorMessage)
        {
            MemberNames = memberNames;
            Success = success;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var rside = obj as WGValidationResult;

            if(ErrorMessage != rside.ErrorMessage)
            {
                return false;
            }

            if (MemberNames != rside.MemberNames)
            {
                return false;
            }

            if (Success != rside.Success)
            {
                return false;
            }

            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                if (ErrorMessage != null)
                {
                    hash = hash * 23 + ErrorMessage.GetHashCode();
                }

                return hash + base.GetHashCode();
            }
        }

        public IWGValidationResult Clone()
        {
            return new WGValidationResult(ErrorMessage, MemberNames, Success);
        }
    }
}