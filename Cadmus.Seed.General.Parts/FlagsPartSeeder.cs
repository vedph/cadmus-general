using Bogus;
using Cadmus.Core;
using Cadmus.General.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.General.Parts;

/// <summary>
/// Seeder for <see cref="FlagsPart"/>.
/// Tag: <c>seed.it.vedph.flags</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.flags")]
public sealed class FlagsPartSeeder : PartSeederBase,
    IConfigurable<FlagsPartSeederOptions>
{
    private FlagsPartSeederOptions? _options;

    /// <summary>
    /// Configures the object with the specified options.
    /// </summary>
    /// <param name="options">The options.</param>
    public void Configure(FlagsPartSeederOptions options)
    {
        _options = options;
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
        ArgumentNullException.ThrowIfNull(item);

        // cannot seed without options
        if (_options == null) return null;

        FlagsPart part = new Faker<FlagsPart>()
           .RuleFor(p => p.Flags, f => new HashSet<string>(
               f.PickRandom(_options.Flags,
                            f.Random.Number(1, _options.Flags.Count))))
           .Generate();

        // add random notes for some of the flags
        if (part.Flags.Count > 0)
        {
            Faker f = new();
            part.Notes = [];
            foreach (string flag in part.Flags)
            {
                if (f.Random.Bool(0.3f))
                    part.Notes[flag] = f.Lorem.Sentence();
            }
        }

        SetPartMetadata(part, roleId, item);

        return part;
    }
}

/// <summary>
/// Options for <see cref="FlagsPartSeeder"/>.
/// </summary>
public sealed class FlagsPartSeederOptions
{
    /// <summary>
    /// The flags to seed.
    /// </summary>
    public HashSet<string> Flags { get; set; } = [];
}
