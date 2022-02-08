using Bogus;
using Cadmus.Refs.Bricks;
using Fusi.Antiquity.Chronology;
using System.Collections.Generic;

namespace Cadmus.Seed.General.Parts
{
    internal static class SeedHelper
    {
        /// <summary>
        /// Gets a random number of document references.
        /// </summary>
        /// <param name="min">The min number of references to get.</param>
        /// <param name="max">The max number of references to get.</param>
        /// <returns>References.</returns>
        public static List<DocReference> GetDocReferences(int min, int max)
        {
            List<DocReference> refs = new List<DocReference>();

            for (int n = 1; n <= Randomizer.Seed.Next(min, max + 1); n++)
            {
                refs.Add(new Faker<DocReference>()
                    .RuleFor(r => r.Type, "book")
                    .RuleFor(r => r.Tag, f => f.PickRandom(null, "tag"))
                    .RuleFor(r => r.Type, "biblio")
                    .RuleFor(r => r.Citation,
                        f => f.Person.LastName + " " + f.Date.Past(10).Year)
                    .RuleFor(r => r.Note, f => f.Lorem.Sentence())
                    .Generate());
            }

            return refs;
        }

        /// <summary>
        /// Gets a list of external IDs.
        /// </summary>
        /// <param name="min">The min number of IDs to get.</param>
        /// <param name="max">The max number of IDs to get.</param>
        /// <returns>IDs.</returns>
        public static List<ExternalId> GetExternalIds(int min, int max)
        {
            List<ExternalId> ids = new List<ExternalId>();
            Faker faker = new Faker();

            for (int n = 1; n <= Randomizer.Seed.Next(min, max + 1); n++)
            {
                ids.Add(faker.Random.Bool()
                    ? new ExternalId
                    {
                        Value = faker.Internet.Url(),
                        Scope = "myweb"
                    } : new ExternalId
                    {
                        Value = faker.Hacker.Abbreviation(),
                        Scope = "mydb"
                    });
            }

            return ids;
        }

        /// <summary>
        /// Gets a list of asserted chronotopes.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>Chronotopes.</returns>
        public static List<AssertedChronotope> GetAssertedChronotopes(int count)
        {
            List<AssertedChronotope> chronotopes = new List<AssertedChronotope>();
            for (int n = 1; n <= count; n++)
            {
                bool even = n % 2 == 0;
                chronotopes.Add(new AssertedChronotope
                {
                    Place = new AssertedPlace
                    {
                        Value = even ? "Even" : "Odd"
                    },
                    Date = new AssertedDate(HistoricalDate.Parse($"{1300 + n} AD"))
                });
            }
            return chronotopes;
        }
    }
}
