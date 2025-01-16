using System.Text.Json.Serialization;

namespace OpenLayers.Blazor.Internal;

public class Shape : Feature, IEquatable<Shape>
{
    public Shape()
    {
        Type = nameof(Shape);
    }

    [JsonIgnore]
    public bool Popup
    {
        get => GetProperty<bool>("popup");
        set => Properties["popup"] = value;
    }

    public Dictionary<string, object>? FlatStyle { get; set; }

    public List<StyleOptions>? Styles { get; set; }

    public double? Radius { get; set; }

    public bool Equals(Shape? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return
            base.Equals(other) &&
            FlatStyle.NullRespectingDynamicEqualityComparer(other.FlatStyle) &&
            Styles.NullRespectingDynamicEqualityComparer(other.Styles) &&
            Radius == other.Radius;
    }
}