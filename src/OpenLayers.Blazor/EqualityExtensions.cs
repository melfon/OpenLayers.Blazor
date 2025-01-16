using System.Text.Json;

namespace OpenLayers.Blazor
{
    public static class EqualityExtensions
    {
        public static bool NullRespectingSequenceEqual<T>(this IEnumerable<T>? me, IEnumerable<T>? other, IEqualityComparer<T>? comparer = null)
        {
            return me is null && other is null ? true
             : me is null || other is null ? false
             : (comparer is null ? me.SequenceEqual(other) : me.SequenceEqual(other, comparer));
        }

        public static bool NullRespectingDynamicEqualityComparer<T>(this T? me, T? other)
        {
            if (ReferenceEquals(me, other)) return true;
            if (ReferenceEquals(me, null)) return false;
            if (ReferenceEquals(other, null)) return false;
            if (me.GetType() != other.GetType()) return false;

            return JsonSerializer.Serialize(me) == JsonSerializer.Serialize(other);
        }
    }
}
