using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;

namespace Monoflector
{
    /// <summary>
    /// Represents the component composition service.
    /// </summary>
    public static class CompositionServices
    {
        /// <summary>
        /// Gets a value indicating whether this instance is initialized.
        /// </summary>
        /// <value>
        /// 	<see langword="true"/> if this instance is initialized; otherwise, <see langword="false"/>.
        /// </value>
        public static bool IsInitialized
        {
            get;
            private set;
        }

        private static CompositionContainer _compositionContainer;
        /// <summary>
        /// Gets the composition container.
        /// </summary>
        public static CompositionContainer CompositionContainer
        {
            get
            {
                CheckInitialized();
                return _compositionContainer;
            }
        }

        /// <summary>
        /// Initializes the specified composition container.
        /// </summary>
        /// <param name="compositionContainer">The composition container.</param>
        public static void Initialize(CompositionContainer compositionContainer)
        {
            if (compositionContainer == null)
                throw new ArgumentNullException("compositionContainer");
            if (IsInitialized)
                throw new InvalidOperationException("CompositionServices is already initialized.");

            _compositionContainer = compositionContainer;
            IsInitialized = true;
        }

        /// <summary>
        /// Composes the parts.
        /// </summary>
        /// <param name="attributedPart">The attributed part.</param>
        public static void ComposeParts(this object attributedPart)
        {
            CheckInitialized();
            _compositionContainer.ComposeParts(attributedPart);
        }

        /// <summary>
        /// Throws an exception if the class has not been initialized.
        /// </summary>
        [DebuggerNonUserCode, DebuggerHidden]
        private static void CheckInitialized()
        {
            if (!IsInitialized)
                throw new InvalidOperationException("CompositionServices has not been initialized.");
        }
    }
}
