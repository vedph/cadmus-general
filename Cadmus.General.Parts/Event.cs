using Cadmus.Refs.Bricks;
using System.Collections.Generic;
using System.Text;

namespace Cadmus.General.Parts
{
    /// <summary>
    /// A generic historical event.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Gets or sets the ID of this event.
        /// </summary>
        public string Eid { get; set; }

        /// <summary>
        /// Gets or sets the event's type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the chronotope.
        /// </summary>
        public AssertedChronotope Chronotope { get; set; }

        /// <summary>
        /// Gets or sets the assertion related to this event.
        /// </summary>
        public Assertion Assertion { get; set; }

        /// <summary>
        /// Gets or sets the event's description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the entities related to this event.
        /// </summary>
        public List<RelatedEntity> RelatedEntities { get; set; }

        /// <summary>
        /// Gets or sets an optional note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(Eid)) sb.Append('#').Append(Eid);
            if (!string.IsNullOrEmpty(Type))
                sb.Append(" [").Append(Type).Append(']');
            if (Chronotope != null)
                sb.Append(": ").Append(Chronotope);

            return sb.ToString();
        }
    }
}
