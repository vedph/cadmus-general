﻿using Bogus;
using Cadmus.Core;
using Cadmus.General.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cadmus.Seed.General.Parts;

/// <summary>
/// Bibliography part seeder.
/// Tag: <c>seed.it.vedph.bibliography</c>.
/// </summary>
/// <seealso cref="PartSeederBase" />
[Tag("seed.it.vedph.bibliography")]
public sealed class BibliographyPartSeeder : PartSeederBase,
    IConfigurable<BibliographyPartSeederOptions>
{
    private readonly List<int> _numbers;
    private readonly IList<string> _typeIds;
    private readonly IList<string> _languages;
    private IList<string> _authors;
    private IList<string> _journals;

    /// <summary>
    /// Initializes a new instance of the <see cref="BibliographyPartSeeder"/>
    /// class.
    /// </summary>
    public BibliographyPartSeeder()
    {
        _numbers = Enumerable.Range(1, 10).ToList();
        _authors = (from n in _numbers
                    select $"author{n}").ToList();
        _journals = (from n in _numbers
                     select $"journal{n}").ToList();
        _typeIds = new[]
        {
            "book", "article-j", "article-b", "site"
        };
        _languages = new[]
        {
            "eng", "ita", "deu", "fra", "spa"
        };
    }

    private static BibAuthor ParseAuthor(string name)
    {
        Match m = Regex.Match(name, "(?<l>[^,]+)(?:,(?<f>.+))?");

        BibAuthor author = new();

        if (!m.Success)
        {
            author.LastName = name;
            return author;
        }
        author.LastName = m.Groups["l"].Value;
        author.FirstName = m.Groups["f"].Length > 0 ?
            m.Groups["f"].Value : null;

        return author;
    }

    /// <summary>
    /// Configures the object with the specified options.
    /// </summary>
    /// <param name="options">The options.</param>
    public void Configure(BibliographyPartSeederOptions options)
    {
        _authors = options.Authors ??
            (from n in _numbers select $"author{n}").ToList();
        _journals = options.Journals ??
            (from n in _numbers select $"journal{n}").ToList();
    }

    /// <summary>
    /// Creates and seeds a new part.
    /// </summary>
    /// <param name="item">The item this part should belong to.</param>
    /// <param name="roleId">The optional part role ID.</param>
    /// <param name="factory">The part seeder factory. This is used
    /// for layer parts, which need to seed a set of fragments.</param>
    /// <returns>A new part.</returns>
    /// <exception cref="ArgumentNullException">item or factory</exception>
    public override IPart? GetPart(IItem item, string? roleId,
        PartSeederFactory? factory)
    {
        ArgumentNullException.ThrowIfNull(item);
        ArgumentNullException.ThrowIfNull(factory);

        BibliographyPart part = new();
        SetPartMetadata(part, roleId, item);

        Faker f = new();

        for (int i = 0; i < 5; i++)
        {
            BibEntry entry = new()
            {
                TypeId = Seed.SeedHelper.RandomPickOneOf(_typeIds),
                Tag = f.PickRandom(null, "alpha", "beta"),
                Authors = (from a in Seed.SeedHelper.RandomPickOf(_authors,
                    Randomizer.Seed.Next(1, 5) == 1? 2:1)
                          select ParseAuthor(a)).ToList(),
                Title = f.Lorem.Sentence(3, 8),
                Language = Seed.SeedHelper.RandomPickOneOf(_languages)
            };

            if (entry.TypeId != "site")
            {
                entry.FirstPage = (short)Randomizer.Seed.Next(1, 100);
                entry.LastPage =
                    (short)(entry.FirstPage + Randomizer.Seed.Next(1, 20));
                entry.YearPub =
                    (short)(DateTime.Now.Year - Randomizer.Seed.Next(0, 20));
            }

            switch (entry.TypeId)
            {
                case "article-b":
                    entry.Contributors =
                        (from a in Seed.SeedHelper.RandomPickOf(_authors,
                            Randomizer.Seed.Next(1, 5) == 1 ? 2 : 1)
                        select ParseAuthor(a)).ToList();
                    entry.Container = f.Lorem.Sentence();
                    break;

                case "article-j":
                    entry.Container = Seed.SeedHelper.RandomPickOneOf(_journals);
                    break;

                case "site":
                    entry.Location = $"www.{f.Lorem.Word().ToLowerInvariant()}.com";
                    break;

                default:
                    entry.Edition = (short)Randomizer.Seed.Next(1, 3);
                    break;
            }

            // keywords
            List<Keyword> keywords = new();
            for (int j = 0; j < Randomizer.Seed.Next(0, 3); j++)
            {
                keywords.Add(new Keyword
                {
                    Language = Seed.SeedHelper.RandomPickOneOf(_languages),
                    Value = f.Lorem.Word()
                });
            }
            if (keywords.Count > 0) entry.Keywords = keywords.ToList();

            part.Entries.Add(entry);
        }

        return part;
    }
 }

/// <summary>
/// Options for <see cref="BibliographyPartSeeder"/>.
/// </summary>
public sealed class BibliographyPartSeederOptions
{
    /// <summary>
    /// Gets or sets the authors to pick from. If not specified, names
    /// like "author1", "author2", etc. will be used. If specified, use
    /// format <c>last,first</c> for each name.
    /// </summary>
    public IList<string>? Authors { get; set; }

    /// <summary>
    /// Gets or sets the journals to pick from. If not specified, names
    /// like "journal1", "journal2", etc. will be used.
    /// </summary>
    public IList<string>? Journals { get; set; }
}
