using System;
using System.Collections.Generic;

namespace Cadmus.General.Parts;

/// <summary>
/// An annotation targeting a <see cref="GalleryImage"/>.
/// </summary>
public class GalleryImageAnnotation
{
    /// <summary>
    /// Gets or sets the image identifier. By default this is a GUID
    /// prefixed by a hash character, but you can use any other type of
    /// identifiers.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Essential metadata about the target image.
    /// </summary>
    public GalleryImage? Target { get; set; }

    /// <summary>
    /// Gets or sets the selector used for defining the portion of the image
    /// being annotated.
    /// </summary>
    public string Selector { get; set; }

    /// <summary>
    /// Gets or sets an optional note in the annotation's body.
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Gets or sets an optional set of tags in the annotation's body.
    /// </summary>
    public List<string>? Tags { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GalleryImageAnnotation"/>
    /// class.
    /// </summary>
    public GalleryImageAnnotation()
    {
        Id = "#" + Guid.NewGuid().ToString();
        Selector = "";
        Tags = new List<string>();
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"{Id} => {Target}";
    }
}
