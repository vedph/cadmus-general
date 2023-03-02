using Cadmus.Core;
using Cadmus.Seed.General.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cadmus.General.Parts.Test;

public sealed class GalleryImageAnnotationsPartTest
{
    private static GalleryImageAnnotationsPart GetPart()
    {
        GalleryImageAnnotationsPartSeeder seeder = new();
        IItem item = new Item
        {
            FacetId = "default",
            CreatorId = "zeus",
            UserId = "zeus",
            Description = "Test item",
            Title = "Test Item",
            SortKey = ""
        };
        return (GalleryImageAnnotationsPart)seeder.GetPart(item, null, null)!;
    }

    private static GalleryImageAnnotationsPart GetEmptyPart()
    {
        return new GalleryImageAnnotationsPart
        {
            ItemId = Guid.NewGuid().ToString(),
            RoleId = "some-role",
            CreatorId = "zeus",
            UserId = "another",
        };
    }

    [Fact]
    public void Part_Is_Serializable()
    {
        GalleryImageAnnotationsPart part = GetPart();

        string json = TestHelper.SerializePart(part);
        GalleryImageAnnotationsPart part2 =
            TestHelper.DeserializePart<GalleryImageAnnotationsPart>(json)!;

        Assert.Equal(part.Id, part2.Id);
        Assert.Equal(part.TypeId, part2.TypeId);
        Assert.Equal(part.ItemId, part2.ItemId);
        Assert.Equal(part.RoleId, part2.RoleId);
        Assert.Equal(part.CreatorId, part2.CreatorId);
        Assert.Equal(part.UserId, part2.UserId);

        Assert.Equal(part.Annotations.Count, part2.Annotations.Count);
    }

    [Fact]
    public void GetDataPins_NoEntries_Ok()
    {
        GalleryImageAnnotationsPart part = GetPart();
        part.Annotations.Clear();

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Single(pins);
        DataPin pin = pins[0];
        Assert.Equal("tot-count", pin.Name);
        TestHelper.AssertPinIds(part, pin);
        Assert.Equal("0", pin.Value);
    }

    [Fact]
    public void GetDataPins_Entries_Ok()
    {
        GalleryImageAnnotationsPart part = GetEmptyPart();

        for (int n = 1; n <= 3; n++)
        {
            part.Annotations.Add(new GalleryImageAnnotation
            {
                Id = $"#a{n}",
                Tags = new List<string> { $"eid_img-anno-{n}" },
                Target = new GalleryImage
                {
                    Id = $"#i{n}"
                }
            });
        }

        List<DataPin> pins = part.GetDataPins(null).ToList();

        Assert.Equal(10, pins.Count);

        DataPin? pin = pins.Find(p => p.Name == "tot-count");
        Assert.NotNull(pin);
        TestHelper.AssertPinIds(part, pin!);
        Assert.Equal("3", pin!.Value);

        for (int n = 1; n <= 3; n++)
        {
            // id
            pin = pins.Find(p => p.Name == "id" && p.Value == $"#a{n}");
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);

            // eid
            pin = pins.Find(p => p.Name == "eid" && p.Value == $"img-anno-{n}");
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);

            // target-id
            pin = pins.Find(p => p.Name == "target-id" && p.Value == $"#i{n}");
            Assert.NotNull(pin);
            TestHelper.AssertPinIds(part, pin!);
        }
    }
}
