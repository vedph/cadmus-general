# Cadmus General Parts

👀 [Cadmus Page](https://myrmex.github.io/overview/cadmus/)

General-purpose parts for Cadmus projects.

- parts:
  - [bibliography](docs/bibliography.md)
  - [categories](docs/categories.md)
  - [chronotopes](docs/chronotopes.md)
  - [comment](docs/comment.md)
  - [decorated counts](docs/decorated-counts.md)
  - [documental references](docs/doc-references.md)
  - [external bibliography](docs/ext-bibliography.md)
  - [external IDs](docs/external-ids.md)
  - [historical date](docs/historical-date.md)
  - [historical events](docs/historical-events.md)
  - [index keywords](docs/index-keywords.md)
  - [metadata](docs/metadata.md)
  - [names](docs/names.md)
  - [note](docs/note.md)
  - [physical measurements](docs/physical-measurements.md)
  - [physical states](docs/physical-states.md)
  - [pin-links](docs/pin-links.md)
  - [tiled text](docs/tiled-text.md)
  - [tiled text layer](docs/tiled-text-layer.md)
  - [token text](docs/token-text.md)
  - [token text layer](docs/token-text-layer.md)
- fragments:
  - [chronology](docs/fr.chronology.md)
  - [comment](docs/fr.comment.md)
  - [pin-links](docs/fr.pin-links.md)

## History

### 6.1.1

- 2024-07-17:
  - added `DecoratedCountsPart`, `PhysicalMeasurementsPart`, `PhysicalStatesPart`.

### 6.1.0

- 2024-02-01:
  - documentation.
  - moved `ChronologyLayerFragment` here from `Cadmus.Philology.Parts`. This was required to synch with the corresponding UI libraries.

### 6.0.4

- 2024-01-31: updated packages.

### 6.0.3

- 2024-01-28: added reference to material bricks in `Cadmus.General.Parts` so that `PhysicalSize` can be used from there.

### 6.0.2

- 2023-11-21: updated packages.

### 6.0.1

- 2023-11-18: ⚠️ Upgraded to .NET 8.

### 5.0.5

- 2023-09-04: updated packages.

### 5.0.4

- 2023-06-16: updated packages.

### 5.0.3

- 2023-06-02: updated packages.

### 5.0.2

- 2023-05-22: breaking changes:
  - refactored comment in comments part and fragment: `ExternalIds` replaced with `Links`, a list of `AssertedCompositeId` (from bricks).

### 5.0.1

- 2023-05-22: breaking changes:
  - refactored related entity in events part: relation ID is now of type `AssertedCompositeId` (from bricks).

### 5.0.0

- 2023-05-22: breaking changes:
  - refactored pin links part and pin links fragment: links are now of type `AssertedCompositeId` (from bricks).

### 4.2.1

- 2023-05-12: updated packages.

### 4.2.0

- 2023-03-11: moved `GalleryImageAnnotationsPart` to its own library under Cadmus imaging.

### 4.1.4

- 2023-02-03:
  - fixed missing target in gallery image annotations seeder.
  - multiple notes per annotation.

### 4.1.2

- 2023-02-03: added `GalleryImageAnnotationsPart`.

### 4.1.1

- 2023-02-27: added an optional `tag` to historical event.

### 4.1.0

- 2023-02-26: many chronotopes per historical event.

### 4.0.2

- 2023-02-15:
  - added an optional `tag` to `PinLink`.

### 4.0.1

- refactored infrastructure.

### 3.0.2

- 2022-11-25:
  - added `PinLinksPart`.
  - fix to historical date seeder references.

### 3.0.0

- 2022-11-10: upgraded to NET 7.

### 2.2.2

- 2022-11-04: updated packages.

### 2.2.1

- 2022-11-04: minor adjustments after nullability.

### 2.2.0

- 2022-11-04: updated packages (nullability enabled in Cadmus core).

### 2.1.2

- 2022-11-03: updated packages.

### 2.1.1

- 2022-10-12: updated packages.

### 2.1.0

- 2022-08-04: replaced `ExternalId` with `AssertedId` in comments.

### 2.0.0

- 2022-05-18: upgraded to NET 6.0.

### 1.0.4

- 2022-01-16: added `ChronotopesPart`.
- 2022-01-09: added assertion to external IDs part. Accordingly, the corresponding bricks editor has been updated in the bricks shell project.
