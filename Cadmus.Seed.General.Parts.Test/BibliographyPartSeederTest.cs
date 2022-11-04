﻿using Cadmus.Core;
using Cadmus.General.Parts;
using Fusi.Tools.Config;
using System;
using System.Reflection;
using Xunit;

namespace Cadmus.Seed.General.Parts.Test
{
    public sealed class BibliographyPartSeederTest
    {
        private static readonly PartSeederFactory _factory =
            TestHelper.GetFactory();
        private static readonly SeedOptions _seedOptions =
            _factory.GetSeedOptions();
        private static readonly IItem _item =
            _factory.GetItemSeeder().GetItem(1, "facet");

        [Fact]
        public void TypeHasTagAttribute()
        {
            Type t = typeof(BibliographyPartSeeder);
            TagAttribute? attr = t.GetTypeInfo().GetCustomAttribute<TagAttribute>();
            Assert.NotNull(attr);
            Assert.Equal("seed.it.vedph.bibliography", attr!.Tag);
        }

        [Fact]
        public void Seed_Options_Ok()
        {
            BibliographyPartSeeder seeder = new();
            seeder.SetSeedOptions(_seedOptions);
            seeder.Configure(new BibliographyPartSeederOptions
            {
                Authors = new[]
                {
                    "Williams,Michael",
                    "Jenkins,Kyle",
                    "Young,Tyler",
                    "Moss,Kyle",
                    "Flores,Brycen"
                },
                Journals = new[]
                {
                    "AJPh",
                    "CJ",
                    "CPh",
                    "CQ",
                    "IF"
                }
            });

            IPart? part = seeder.GetPart(_item, null, _factory);

            Assert.NotNull(part);

            BibliographyPart? bp = part as BibliographyPart;
            Assert.NotNull(bp);

            TestHelper.AssertPartMetadata(bp!);
            Assert.NotEmpty(bp!.Entries);
        }
    }
}
