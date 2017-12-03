using System.Collections.Generic;

namespace WGSystem.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Interface for the Wolf games validation adaptor
    /// </summary>
    public interface IWGValidationResult
    {
        string ErrorMessage { get; set; }
        IEnumerable<string> MemberNames { get; set; }
        bool Success { get; set; }
    }
}