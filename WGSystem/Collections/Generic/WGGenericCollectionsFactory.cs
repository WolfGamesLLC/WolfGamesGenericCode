using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WGSystem.Collections.Generic
{
    /// <summary>
    /// Factory for creating generic collection objects
    /// </summary>
    public class WGGenericCollectionsFactory
    {
        /// <summary>
        /// Creates a List of T type objects
        /// </summary>
        /// <typeparam name="T">Type of objects contained in the list</typeparam>
        /// <returns>An object that implements an IList</returns>
        public IList<T> CreateList<T>()
        {
            return new List<T>();
        }
    }
}
