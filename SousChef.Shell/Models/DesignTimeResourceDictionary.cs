using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace SousChef.Shell.Models
{
    /// <summary>
    /// Represents a resource dictionary that consumes resources at design time only, allowing preview of styles and themes
    /// from resource dictionaries that would normally only be visible at runtime.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.ResourceDictionary" />
    /// <summary>
    /// Class which allows a resource dictionary to be applied to a view only at design time.
    /// </summary>
    public class DesignTimeResourceDictionary : ResourceDictionary
    {
        #region Fields

        private string designTimeSource;

        #endregion

        #region Instance Properties

        /// <summary>
        /// Gets or sets the design time source.
        /// </summary>
        /// <value>The design time source.</value>
        public string DesignTimeSource
        {
            get
            {
                return this.designTimeSource;
            }

            set
            {
                this.designTimeSource = value;
                if (DesignMode.DesignModeEnabled)
                {
                    base.Source = new Uri(this.designTimeSource);
                }
            }
        }

        /// <summary>
        /// Gets or sets the uniform resource identifier (URI) to load resources from.
        /// </summary>
        /// <returns>
        /// The source location of an external resource dictionary.
        /// </returns>
        public new Uri Source
        {
            get
            {
                if (!DesignMode.DesignModeEnabled)
                {
                    return null;
                }

                return base.Source;
            }

            set
            {
                if (!DesignMode.DesignModeEnabled)
                {
                    return;
                }

                base.Source = value;
            }
        }

        #endregion
    }
}
