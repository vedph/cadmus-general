﻿using Bogus;
using Cadmus.Core;
using Cadmus.General.Parts;
using Cadmus.Refs.Bricks;
using Fusi.Tools.Config;
using System;
using System.Collections.Generic;

namespace Cadmus.Seed.General.Parts
{
    /// <summary>
    /// Seeder for <see cref="HistoricalEventsPartSeeder"/>.
    /// Tag: <c>seed.it.vedph.historical-events</c>.
    /// </summary>
    /// <seealso cref="PartSeederBase" />
    [Tag("seed.it.vedph.historical-events")]
    public sealed class HistoricalEventsPartSeeder : PartSeederBase
    {
        private static List<RelatedEntity> GetRelatedEntities(int count,
            string relation, string prefix)
        {
            List<RelatedEntity> entities = new List<RelatedEntity>();
            for (int n = 1; n <= count; n++)
            {
                entities.Add(new RelatedEntity
                {
                    Relation = relation,
                    Id = prefix + Guid.NewGuid().ToString("N")
                });
            }
            return entities;
        }

        private static List<HistoricalEvent> GetEvents(int count)
        {
            List<HistoricalEvent> events = new List<HistoricalEvent>();
            for (int n = 1; n <= count; n++)
            {
                bool even = n % 2 == 0;

                events.Add(new Faker<HistoricalEvent>()
                    .RuleFor(e => e.Eid, "events/" + Guid.NewGuid().ToString("N"))
                    .RuleFor(e => e.Type, even? "death" : "birth")
                    .RuleFor(e => e.Chronotope, SeedHelper.GetAssertedChronotopes(1)[0])
                    .RuleFor(e => e.Assertion, f => new Assertion
                    {
                        Tag = "tag",
                        Rank = (short)(n % 2 == 0? 2 : 1),
                        References = SeedHelper.GetDocReferences(1, 3),
                        Note = f.Random.Bool(0.25f)? f.Lorem.Sentence() : null
                    })
                    .RuleFor(e => e.Description, f => f.Lorem.Sentence())
                    .RuleFor(e => e.RelatedEntities, GetRelatedEntities(2,
                        even? "killer" : "parent", "persons/"))
                    .RuleFor(e => e.Note, f => f.Random.Bool(0.25f)
                        ? f.Lorem.Sentence() : null)
                    .Generate());
            }
            return events;
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
        public override IPart GetPart(IItem item, string roleId,
            PartSeederFactory factory)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            HistoricalEventsPart part = new Faker<HistoricalEventsPart>()
               .RuleFor(p => p.Events, f => GetEvents(f.Random.Number(1, 3)))
               .Generate();
            SetPartMetadata(part, roleId, item);

            return part;
        }
    }
}
