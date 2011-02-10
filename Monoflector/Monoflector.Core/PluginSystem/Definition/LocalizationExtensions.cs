using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using Monoflector.PluginSystem.Definition;

namespace Monoflector
{
    /// <summary>
    /// Represents localization extensions.
    /// </summary>
    public static class LocalizationExtensions
    {
        /// <summary>
        /// Finds the correct localized item in the specified items.
        /// </summary>
        /// <typeparam name="T">The type of localized items.</typeparam>
        /// <param name="items">The items.</param>
        /// <returns>The localized item.</returns>
        public static T Localize<T>(this IEnumerable<T> items)
            where T : LocalizedEntity
        {
            return Localize(items, Thread.CurrentThread.CurrentCulture);
        }

        /// <summary>
        /// Finds the correct localized item in the specified items.
        /// </summary>
        /// <typeparam name="T">The type of localized items.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="cultureInfo">The desired culture info.</param>
        /// <returns>
        /// The localized item.
        /// </returns>
        public static T Localize<T>(this IEnumerable<T> items, CultureInfo cultureInfo)
            where T : LocalizedEntity
        {
            T result = null;
            while (result == null && cultureInfo != null)
            {
                result = items.Where(x => x.Culture == cultureInfo).FirstOrDefault();
                cultureInfo = cultureInfo.Parent;
            }
            return result;
        }
    }
}
