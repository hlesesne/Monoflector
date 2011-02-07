using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Primitives;
using System.Threading;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel.Composition.Hosting
{
    /// <summary>
    /// Represents a <see cref="ComposablePartCatalog"/> that is
    /// environment aware.
    /// </summary>
    public class EnvironmentCatalog : ComposablePartCatalog
    {
        private HashSet<string> _environments;
        private volatile int _isDisposed = 0;
        private ComposablePartCatalog _catalog;
        private IQueryable<ComposablePartDefinition> _partsQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateCatalog"/> class.
        /// </summary>
        /// <param name="backend">The backend.</param>
        /// <param name="environments">The environments.</param>
        public EnvironmentCatalog(ComposablePartCatalog backend, IEnumerable<string> environments)
        {
            if (environments == null)
                throw new ArgumentNullException("environment");
            if (backend == null)
                throw new ArgumentNullException("backend");

            _environments = new HashSet<string>(environments, StringComparer.Ordinal);
            _catalog = backend;
            this._partsQuery = this._catalog.Parts.AsQueryable();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentCatalog"/> class.
        /// </summary>
        /// <param name="backend">The backend.</param>
        /// <param name="environments">The environments.</param>
        public EnvironmentCatalog(ComposablePartCatalog backend, params string[] environments)
            : this(backend, (IEnumerable<string>)environments)
        {

        }
        
        /// <summary>
        ///     Gets the part definitions of the catalog.
        /// </summary>
        /// <value>
        ///     A <see cref="IQueryable{T}"/> of <see cref="ComposablePartDefinition"/> objects of the 
        ///     <see cref="AggregateCatalog"/>.
        /// </value>
        /// <exception cref="ObjectDisposedException">
        ///     The <see cref="AggregateCatalog"/> has been disposed of.
        /// </exception>
        public override IQueryable<ComposablePartDefinition> Parts
        {
            get
            {
                this.ThrowIfDisposed();
                return this._partsQuery;
            }
        }

        /// <summary>
        ///     Returns the export definitions that match the constraint defined by the specified definition.
        /// </summary>
        /// <param name="definition">
        ///     The <see cref="ImportDefinition"/> that defines the conditions of the 
        ///     <see cref="ExportDefinition"/> objects to return.
        /// </param>
        /// <returns>
        ///     An <see cref="IEnumerable{T}"/> of <see cref="Tuple{T1, T2}"/> containing the 
        ///     <see cref="ExportDefinition"/> objects and their associated 
        ///     <see cref="ComposablePartDefinition"/> for objects that match the constraint defined 
        ///     by <paramref name="definition"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="definition"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The <see cref="AggregateCatalog"/> has been disposed of.
        /// </exception>
        public override IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> GetExports(ImportDefinition definition)
        {
            if (definition == null)
                throw new ArgumentNullException("definition");
            this.ThrowIfDisposed();

            // delegate the query to each catalog and merge the results.
            var exports = new List<Tuple<ComposablePartDefinition, ExportDefinition>>();
            foreach (var export in _catalog.GetExports(definition).Where(ExportCondition))
            {
                exports.Add(export);
            }
            return exports;
        }

        /// <summary>
        /// The condition for an export to be included.
        /// </summary>
        /// <remarks>
        /// If the export doesn't have environment metadata (both not present and empty/null)
        /// it is included. Otherwise, it must match the environment defined by the catalog.
        /// </remarks>
        /// <param name="value">The value.</param>
        /// <returns>Whether the export should be included.</returns>
        private bool ExportCondition(Tuple<ComposablePartDefinition, ExportDefinition> value)
        {
            var cp = value.Item1;
            var ed = value.Item2;
            
            object environment;
            if (cp.Metadata.TryGetValue(MetadataKeys.Environment, out environment))
            {
                if (environment is string && !string.IsNullOrEmpty((string)environment))
                {
                    return _environments.Contains((string)environment);
                }
                else if (environment is IEnumerable<object>)
                {
                    var list = (IEnumerable<object>)environment;
                    foreach (string item in list)
                    {
                        if (!_environments.Contains(item))
                            return false;
                    }
                }
            }

            return true;
        }
        
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            #pragma warning disable 420
            var wasDisposed = Interlocked.Exchange(ref this._isDisposed, 1) == 1;
            #pragma warning restore 420
            if (wasDisposed)
                return;
            try
            {

            }
            finally
            {
                base.Dispose(disposing);
            }
        }


        [DebuggerStepThrough]
        [SuppressMessage("Microsoft.Contracts", "CC1053", Justification = "Suppressing warning because this validator has no public contract")]
        private void ThrowIfDisposed()
        {
            if (this._isDisposed == 1)
            {
                throw new ObjectDisposedException(this.GetType().Name);
            }
        }
    }
}
