using System.Collections.Generic;
using System.Text;
using Cadmus.Core;
using Fusi.Tools.Config;

namespace Cadmus.General.Parts
{
    /// <summary>
    /// Generic historical events part.
    /// <para>Tag: <c>it.vedph.historical-events</c>.</para>
    /// </summary>
    [Tag("it.vedph.historical-events")]
    public sealed class HistoricalEventsPart : PartBase
    {
        /// <summary>
        /// Gets or sets the entries.
        /// </summary>
        public List<HistoricalEvent> Events { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HistoricalEventsPart"/> class.
        /// </summary>
        public HistoricalEventsPart()
        {
            Events = new List<HistoricalEvent>();
        }

        private void AddChronotopePins(HistoricalEvent entry, DataPinBuilder builder)
        {
            if (entry.Chronotope.Place?.Value != null)
            {
                builder.AddValue("place",
                    entry.Chronotope.Place.Value);

                builder.AddValue("hasPlace@" + entry.Eid,
                    entry.Chronotope.Place.Value);
            }

            if (entry.Chronotope.Date != null)
            {
                double sortValue =
                    entry.Chronotope.Date.GetSortValue();
                builder.AddValue("date-value", sortValue);

                builder.AddValue("hasDate@" + entry.Eid,
                    entry.Chronotope.Date.ToString());
                builder.AddValue("hasDateValue@" + entry.Eid,
                    sortValue);
            }
        }

        private void AddRelatedEntriesPins(HistoricalEvent entry, DataPinBuilder builder)
        {
            foreach (RelatedEntity entity in entry.RelatedEntities)
            {
                builder.AddValue("eid2@" + entry.Eid, entity.Id);
                builder.AddValue($"rel@{entry.Eid}@{entity.Id}", entity.Relation);
            }
        }

        /// <summary>
        /// Get all the key=value pairs (pins) exposed by the implementor.
        /// </summary>
        /// <param name="item">The optional item. The item with its parts
        /// can optionally be passed to this method for those parts requiring
        /// to access further data.</param>
        /// <returns>The pins: <c>tot-count</c> and a collection of pins with
        /// these keys: <c>eid</c>, <c>type</c>, <c>place</c>, <c>date-value</c>.
        /// </returns>
        public override IEnumerable<DataPin> GetDataPins(IItem item = null)
        {
            DataPinBuilder builder = new DataPinBuilder();

            builder.Set("tot", Events?.Count ?? 0, false);

            if (Events?.Count > 0)
            {
                foreach (HistoricalEvent entry in Events)
                {
                    builder.AddValue("eid", entry.Eid);
                    builder.AddValue("type", entry.Type);

                    if (entry.Chronotope != null)
                        AddChronotopePins(entry, builder);

                    // event's type
                    builder.AddValue("type@" + entry.Eid, entry.Type);
                    // related entries
                    if (entry.RelatedEntities?.Count > 0)
                        AddRelatedEntriesPins(entry, builder);
                }
            }

            return builder.Build(this);
        }

        /// <summary>
        /// Gets the definitions of data pins used by the implementor.
        /// </summary>
        /// <returns>Data pins definitions.</returns>
        public override IList<DataPinDefinition> GetDataPinDefinitions()
        {
            return new List<DataPinDefinition>(new[]
            {
                new DataPinDefinition(DataPinValueType.Integer,
                   "tot-count",
                   "The total count of events."),
                new DataPinDefinition(DataPinValueType.String,
                   "eid",
                   "The events IDs.",
                   "M"),
                new DataPinDefinition(DataPinValueType.String,
                   "type",
                   "The events types.",
                   "M"),
                new DataPinDefinition(DataPinValueType.String,
                   "place",
                   "The events places.",
                   "M"),
                new DataPinDefinition(DataPinValueType.Decimal,
                   "date-value",
                   "The events date values.",
                   "M"),
                // semantic
                new DataPinDefinition(DataPinValueType.String,
                   "hasPlace@EID",
                   "The event's place.",
                   "M"),
                new DataPinDefinition(DataPinValueType.String,
                   "hasDate@EID",
                   "The event's date.",
                   "M"),
                new DataPinDefinition(DataPinValueType.Decimal,
                   "hasDateValue@EID",
                   "The event's date value.",
                   "M"),
                new DataPinDefinition(DataPinValueType.String,
                   "eid2@EID",
                   "The event's related entity ID.",
                   "M"),
                new DataPinDefinition(DataPinValueType.String,
                   "rel@EID@RELID",
                   "The link between the event and its related entity.",
                   "M")
            });
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[Events]");

            if (Events?.Count > 0)
            {
                sb.Append(' ');
                int n = 0;
                foreach (var entry in Events)
                {
                    if (++n > 3) break;
                    if (n > 1) sb.Append("; ");
                    sb.Append(entry);
                }
                if (Events.Count > 3)
                    sb.Append("...(").Append(Events.Count).Append(')');
            }

            return sb.ToString();
        }
    }
}
