using Bogus;
using Cadmus.Core;
using Cadmus.General.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Cadmus.Seed.General.Parts;

/// <summary>
/// Seeder for GalleryImageAnnotations part.
/// Tag: <c>seed.it.vedph.gallery-image-annotations</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.gallery-image-annotations")]
public sealed class GalleryImageAnnotationsPartSeeder : PartSeederBase
{
    private static int _nr = 0;

    private static List<GalleryImageAnnotation> GetAnnotations(int count, Faker f)
    {
        List<GalleryImageAnnotation> annotations = new(count);
        for (int i = 0; i < count; i++)
        {
            int n = 0;
            if (f.Random.Bool(0.3F)) n = Interlocked.Increment(ref _nr);

            annotations.Add(new GalleryImageAnnotation
            {
                Id = "#" + Guid.NewGuid().ToString(),
                Selector = $"xywh=pixel:{f.Random.Number(0, 100)}," +
                    $"{f.Random.Number(0, 100)},{f.Random.Number(10, 100)}," +
                    $"{f.Random.Number(10, 100)}",
                Note = f.Lorem.Sentence(),
                Tags = n > 0? new List<string> { $"eid_img-anno-{n}"} : null
            });
        }
        return annotations;
    }

    /// <summary>
    /// Creates and seeds a new part.
    /// </summary>
    /// <param name="item">The item this part should belong to.</param>
    /// <param name="roleId">The optional part role ID.</param>
    /// <param name="factory">The part seeder factory. This is used
    /// for layer parts, which need to seed a set of fragments.</param>
    /// <returns>A new part or null.</returns>
    /// <exception cref="ArgumentNullException">item or factory</exception>
    public override IPart? GetPart(IItem item, string? roleId,
        PartSeederFactory? factory)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        GalleryImageAnnotationsPart part = new Faker<GalleryImageAnnotationsPart>()
           .RuleFor(p => p.Annotations,
                f => GetAnnotations(f.Random.Number(1, 2), f))
           .Generate();
        SetPartMetadata(part, roleId, item);

        return part;
    }
}
