Assembly
========

1. Renamed to System.ComponentModel.Composition.Monoflector to avoid conflicts with other projects that use the Codeplex MEF builds.

ExportAttribute
===============

1. Limitation with PartMetadataAttribute: the attribute is sealed. This prevents Environment-aware composition. Also, discovery of type metadata (lists) is broken - as it doesn't support lists.

    :: ComponentModel\System\ComponentModel\Composition\PartMetadataAttribute.cs

    // Line 14
    public class PartMetadataAttribute : Attribute

    :: ComponentModel\System\ComponentModel\Composition\Hosting\CompositionServices.cs

    // Line 122
        internal static IDictionary<string, object> GetPartMetadataForType(this Type type, CreationPolicy creationPolicy)
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>(StringComparers.MetadataKeyNames);

            if (creationPolicy != CreationPolicy.Any)
            {
                dictionary.Add(CompositionConstants.PartCreationPolicyMetadataName, creationPolicy);
            }

            foreach (PartMetadataAttribute partMetadata in type.GetAttributes<PartMetadataAttribute>(true))
            {
                if (reservedMetadataNames.Contains(partMetadata.Name, StringComparers.MetadataKeyNames))
                {
                    // Perhaps we should log an error here so that people know this value is being ignored.
                    continue;
                }

                // Determine if we allow multiple values.
                Type attrType = partMetadata.GetType();
                bool allowsMultiple = false;
                AttributeUsageAttribute usage = attrType.GetFirstAttribute<AttributeUsageAttribute>(true);

                if (usage != null)
                {
                    // Only allow multiple values on inherited attributes.
                    allowsMultiple = usage.AllowMultiple && attrType != typeof(PartMetadataAttribute);
                }

                if (!dictionary.TryContributeMetadataValue(partMetadata.Name, partMetadata.Value, null, allowsMultiple))
                {
                    throw ExceptionBuilder.CreateDiscoveryException(Strings.Discovery_DuplicateMetadataNameValues, type.GetDisplayName(), partMetadata.Name);
                }
            }

    // Line 272
        private class MetadataList : IEnumerable<object>
        {

            IEnumerator<object> IEnumerable<object>.GetEnumerator()
            {
                return _innerList.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _innerList.GetEnumerator();
            }