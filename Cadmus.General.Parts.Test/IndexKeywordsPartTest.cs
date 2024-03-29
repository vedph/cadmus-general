﻿using Cadmus.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.General.Parts.Test;

public sealed class IndexKeywordsPartTest
{
    private static IndexKeywordsPart GetPart(bool keywords = true)
    {
        IndexKeywordsPart part = new()
        {
            ItemId = Guid.NewGuid().ToString(),
            RoleId = "some-role",
            CreatorId = "zeus",
            UserId = "another"
        };
        if (keywords)
        {
            part.AddKeyword(new IndexKeyword
            {
                IndexId = "colors",
                Language = "eng",
                Value = "Red",
                Note = "red note",
                Tag = "tag"
            });
            part.AddKeyword(new IndexKeyword
            {
                IndexId = "colors",
                Language = "eng",
                Value = "Green",
                Note = "green note",
                Tag = "tag"
            });
            part.AddKeyword(new IndexKeyword
            {
                Language = "eng",
                Value = "Greek"
            });
        }
        return part;
    }

    [Fact]
    public void Part_Is_Serializable()
    {
        IndexKeywordsPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        IndexKeywordsPart? part2 =
            TestHelper.DeserializePart<IndexKeywordsPart>(json);

        Assert.NotNull(part2);
        Assert.Equal(part.Id, part2!.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);
        Assert.Equal(part.Keywords.Count, part2.Keywords.Count);

        foreach (IndexKeyword expected in part.Keywords)
        {
            Assert.Contains(part2.Keywords,
                k => k.IndexId == expected.IndexId
                && k.Language == expected.Language
                && k.Value == expected.Value);
        }
    }

    [Fact]
    public void GetDataPins_NoKeywords_Empty()
    {
        IndexKeywordsPart part = GetPart(false);

        Assert.Empty(part.GetDataPins());
    }

    [Fact]
    public void GetDataPins_Tag_4()
    {
        IndexKeywordsPart part = GetPart();

        List<DataPin> pins = part.GetDataPins().ToList();
        Assert.Equal(7, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "tot-count");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        Assert.Equal("3", pin?.Value);

        // keyword..eng = Greek
        pin = pins.Find(p => p.Name == "keyword..eng"
            && p.Value == "greek");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "u-keyword..eng"
            && p.Value == "Greek");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        // keyword.colors.eng = green
        pin = pins.Find(p => p.Name == "keyword.colors.eng"
            && p.Value == "green");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "u-keyword.colors.eng"
            && p.Value == "Green");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        // keyword.colors.eng = red
        pin = pins.Find(p => p.Name == "keyword.colors.eng"
            && p.Value == "red");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "u-keyword.colors.eng"
            && p.Value == "Red");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
    }
}
