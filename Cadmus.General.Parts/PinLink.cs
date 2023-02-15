using System.Text;

namespace Cadmus.General.Parts;

/// <summary>
/// A link entry used in <see cref="PinLinksPart"/>.
/// </summary>
public class PinLink
{
    /// <summary>
    /// Gets or sets the link's label.
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the item identifier.
    /// </summary>
    public string? ItemId { get; set; }

    /// <summary>
    /// Gets or sets the part identifier.
    /// </summary>
    public string? PartId { get; set; }

    /// <summary>
    /// Gets or sets the part type identifier.
    /// </summary>
    public string? PartTypeId { get; set; }

    /// <summary>
    /// Gets or sets the role identifier.
    /// </summary>
    public string? RoleId { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// Gets or sets an optional tag for this link.
    /// </summary>
    public string? Tag { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(Label).Append(": ").Append(ItemId).Append(' ').Append(PartId);
        if (!string.IsNullOrEmpty(RoleId))
            sb.Append("R=").Append(RoleId);
        return sb.ToString();
    }
}
