namespace Cadmus.General.Parts;

/// <summary>
/// Minimalist metadata about an image picked from a gallery for annotation
/// purposes.
/// </summary>
public class GalleryImage
{
    /// <summary>
    /// Gets or sets the image identifier.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the image URI.
    /// </summary>
    public string Uri { get; set; }

    /// <summary>
    /// Gets or sets the image title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the optional image description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GalleryImage"/> class.
    /// </summary>
    public GalleryImage()
    {
        Id = "";
        Uri = "";
        Title = "";
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"{Id}: {Title}";
    }
}
