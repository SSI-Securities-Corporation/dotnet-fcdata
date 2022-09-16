using System;

namespace SSI.FastConnect.DataContracts.Enums
{
    /// <summary>
    /// Support generate description for help page
    /// </summary>
    public class HelpDescription : Attribute
    {

        /// <summary>
        /// Description for help page
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Required data
        /// </summary>
        public bool Required { get; set; }


        /// <summary>
        /// Value of param
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="description"></param>
        public HelpDescription(string description, bool isRequired = false)
        {
            Description = description;
            Required = isRequired;
        }
    }
}