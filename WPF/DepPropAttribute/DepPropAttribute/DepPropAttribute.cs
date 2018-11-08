using System;
using System.Collections.Generic;
using System.Reflection;

namespace DepPropAttributeExample
{
    /// <summary>
    /// Attach attribute to a property, indicating dependent property. Can be 
    /// used, for example, to map dependencies between Model properties and
    /// ViewModel properties.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DepPropAttribute : Attribute
    {
        public string PropName { get; }

        public DepPropAttribute(string propname)
        {
            PropName = propname;
        }

        /// <summary>
        /// Build dictionary of mapped properties, based on use of the DepProp attribute.
        /// </summary>
        /// <param name="type">Type to examine</param>
        /// <returns>Each key is independent property from attribute, value is list of props that this dep prop is applied to</returns>
        public static Dictionary<string, List<string>> MapDependentProperties(Type type)
        {
            var dict = new Dictionary<string, List<string>>();

            // Populate dependent property lookup dictionary
            foreach (var mi in type.GetProperties())
            {
                foreach (var attr in mi.GetCustomAttributes(typeof(DepPropAttribute)))
                {
                    var depAttr = attr as DepPropAttribute;
                    if (!dict.ContainsKey(depAttr.PropName))
                    {
                        dict.Add(depAttr.PropName, new List<string>());
                    }
                    dict[depAttr.PropName].Add(mi.Name);
                }
            }

            return dict;
        }
    }
}
