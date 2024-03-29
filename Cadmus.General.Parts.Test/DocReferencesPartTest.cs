﻿using Cadmus.Core;
using Cadmus.Refs.Bricks;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.General.Parts.Test;

public sealed class DocReferencesPartTest
{
    private static DocReferencesPart GetPart(int count)
    {
        DocReferencesPart part = new()
        {
            ItemId = Guid.NewGuid().ToString(),
            RoleId = "some-role",
            CreatorId = "zeus",
            UserId = "another",
        };

        for (int n = 1; n <= count; n++)
        {
            part.References.Add(new DocReference
            {
                Tag = "tag",
                Citation = n % 2 == 0? "Hes. th. 1.23" : "Hom. Il. 1.23",
                Note = "A note"
            });
        }

        return part;
    }

    [Fact]
    public void Part_Is_Serializable()
    {
        DocReferencesPart part = GetPart(2);

        string json = TestHelper.SerializePart(part);
        DocReferencesPart? part2 =
            TestHelper.DeserializePart<DocReferencesPart>(json);

        Assert.NotNull(part2);
        Assert.Equal(part.Id, part2!.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);

        Assert.Equal(2, part.References.Count);
        // TODO: details
    }

    [Fact]
    public void GetDataPins_NoCitation_Ok()
    {
        DocReferencesPart part = GetPart(0);

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Single(pins);
        DataPin pin = pins[0];
        Assert.Equal("tot-count", pin.Name);
        TestHelper.AssertPinIds(part, pin);
        Assert.Equal("0", pin.Value);
    }

    [Fact]
    public void GetDataPins_Dedications_Ok()
    {
        DocReferencesPart part = GetPart(3);

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Equal(4, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "tot-count");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        Assert.Equal("3", pin?.Value);

        pin = pins.Find(p => p.Name == "citation" &&
            p.Value == "Hom. Il. 1.23");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        pin = pins.Find(p => p.Name == "citation" &&
            p.Value == "Hes. th. 1.23");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);

        pin = pins.Find(p => p.Name == "tag");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        Assert.Equal("tag", pin?.Value);
    }
}
