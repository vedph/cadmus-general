﻿using Cadmus.Core;
using Cadmus.General.Parts;
using Fusi.Tools.Configuration;
using System;
using System.Reflection;
using Xunit;

namespace Cadmus.Seed.General.Parts.Test;

public sealed class AssertedHistoricalDatesPartSeederTest
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
        Type t = typeof(AssertedHistoricalDatesPartSeeder);
        TagAttribute? attr = t.GetTypeInfo().GetCustomAttribute<TagAttribute>();
        Assert.NotNull(attr);
        Assert.Equal("seed.it.vedph.asserted-historical-dates", attr!.Tag);
    }

    [Fact]
    public void Seed_Optionless_Ok()
    {
        AssertedHistoricalDatesPartSeeder seeder = new();
        seeder.SetSeedOptions(_seedOptions);

        IPart? part = seeder.GetPart(_item, null, _factory);

        Assert.NotNull(part);

        AssertedHistoricalDatesPart? p = part as AssertedHistoricalDatesPart;
        Assert.NotNull(p);

        TestHelper.AssertPartMetadata(p);
        Assert.NotEmpty(p.Dates);
    }
}
