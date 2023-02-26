# Cadmus General Parts

- [Cadmus General Parts](#cadmus-general-parts)
  - [Parts](#parts)
    - [BibliographyPart](#bibliographypart)
    - [CategoriesPart](#categoriespart)
    - [ChronotopesPart](#chronotopespart)
    - [CommentPart](#commentpart)
    - [DocReferencesPart](#docreferencespart)
    - [ExtBibliographyPart](#extbibliographypart)
    - [ExternalIdsPart](#externalidspart)
    - [HierarchyPart](#hierarchypart)
    - [HistoricalDatePart](#historicaldatepart)
    - [HistoricalEventsPart](#historicaleventspart)
    - [IndexKeywordsPart](#indexkeywordspart)
    - [KeywordsPart](#keywordspart)
    - [MetadataPart](#metadatapart)
    - [NamesPart](#namespart)
    - [NotePart](#notepart)
    - [NumberingPart](#numberingpart)
    - [PinLinksPart](#pinlinkspart)
    - [TiledTextLayerPart](#tiledtextlayerpart)
    - [TokenTextLayerPart](#tokentextlayerpart)
  - [Fragments](#fragments)
    - [CommentLayerFragment](#commentlayerfragment)
    - [PinLinksLayerFragment](#pinlinkslayerfragment)
  - [History](#history)
    - [4.1.0](#410)
    - [4.0.2](#402)
    - [4.0.1](#401)
    - [3.0.2](#302)
    - [3.0.0](#300)
    - [2.2.2](#222)
    - [2.2.1](#221)
    - [2.2.0](#220)
    - [2.1.2](#212)
    - [2.1.1](#211)
    - [2.1.0](#210)
    - [2.0.0](#200)
    - [1.0.4](#104)

This solution contains the Cadmus general parts library derived from `Cadmus.Parts`, in the context of the general refactoring towards a more streamlined and modular system.

The library includes all the old parts with some additions. No part or fragment ID has been changed.

👀 [Cadmus Page](https://myrmex.github.io/overview/cadmus/)

## Parts

### BibliographyPart

ID: `it.vedph.bibliography`

- entries (`BibEntry[]`):
  - key (`string`)
  - typeId (`string`)
  - tag (`string`)
  - authors (`BibAuthor[]`):
    - firstName (`string`)
    - lastName (`string`)
    - roleId (`string`)
  - title (`string`)
  - language (`string`)
  - container (`string`)
  - contributors (`BibAuthor[]`)
  - edition (`short`)
  - number (`string`)
  - publisher (`string`)
  - yearPub (`short`)
  - placePub (`string`)
  - location (`string`)
  - accessDate (`date`)
  - firstPage (`short`)
  - lastPage (`short`)
  - keywords (`Keyword[]`)
  - note (`string`)

### CategoriesPart

ID: `it.vedph.categories`

- categories (`string[]`)

### ChronotopesPart

ID: `it.vedph.chronotopes`

- chronotopes (`AssertedChronotope[]`):
  - place (`AssertedPlace`)
    - tag (`string`)
    - value (`string`)
    - assertion (`Assertion`):
      - tag (`string`)
      - rank (`short`)
      - references (`DocReference[]`)
      - note (`string`)
  - date (`AssertedDate`):
    - a (`Datation`):
      - value (`int`)
      - isCentury (`bool`)
      - isSpan (`bool`)
      - isApproximate (`bool`)
      - isDubious (`bool`)
      - day (`short`)
      - month (`short`)
      - hint (`string`)
    - b (`Datation`)
    - tag (`string`)
    - assertion (`Assertion`)

### CommentPart

ID: `it.vedph.comment`

- tag (`string`)
- text (`string`)
- references (`DocReference[]`)
- externalIds (`AssertedId[]`)
- categories (`string[]`)
- keywords (`IndexKeyword[]`)

### DocReferencesPart

ID: `it.vedph.doc-references`

- references (`DocReference[]`)
  - type (`string`)
  - tag (`string`)
  - citation (`string`)
  - note (`string`)

### ExtBibliographyPart

ID: `it.vedph.ext-bibliography`

- entries (`ExtBibEntry[]`):
  - id (`string`)
  - label (`string`)
  - payload (`string`)
  - tag (`string`)
  - note (`string`)

### ExternalIdsPart

ID: `it.vedph.external-ids`

- ids (`AssertedId[]`):
  - tag (`string`)
  - value\* (`string`)
  - scope (`string`)
  - assertion (`Assertion`):
    - tag (`string`)
    - rank\* (`string`)
    - note (`string`)
    - references (`DocReference[]`)

### HierarchyPart

ID: `it.vedph.hierarchy`

- parentId (`string`)
- childrenIds (`string[]`)
- y (`int`)
- x (`int`)
- tag (`string`)

### HistoricalDatePart

ID: `it.vedph.historical-date`

- date (`HistoricalDate`)
  - a (`Datation`):
    - value (`int`)
    - isCentury (`bool`)
    - isSpan (`bool`)
    - isApproximate (`bool`)
    - isDubious (`bool`)
    - day (`short`)
    - month (`short`)
    - hint (`string`)
  - b (`Datation`)
- references (`DocReference[]`)

### HistoricalEventsPart

ID: `it.vedph.historical-events`

- events (`HistoricalEvent[]`):
  - eid (`string`)
  - type (`string`)
  - chronotopes (`AssertedChronotope[]`)
  - assertion (`Assertion`)
  - description (`string`)
  - relatedEntities (`RelatedEntity[]`):
    - relation (`string`)
    - id (`string`)
  - note (`string`)

### IndexKeywordsPart

ID: `it.vedph.index-keywords`

- keywords (`IndexKeyword[]`):
  - language (`string`)
  - value (`string`)
  - indexId (`string`)
  - note (`string`)
  - tag (`string`)

### KeywordsPart

ID: `it.vedph.keywords`

- keywords (`Keyword[]`):
  - language (`string`)
  - value (`string`)

### MetadataPart

ID: `it.vedph.metadata`

- metadata (`Metadatum[]`):
  - type (`string`)
  - name (`string`)
  - value (`string`)

### NamesPart

ID: `it.vedph.names`

- names (`AssertedProperName[]`):
  - language (`string`)
  - tag (`string`)
  - pieces (`ProperNamePiece[]`):
    - type (`string`)
    - value (`string`)
  - assertion (`Assertion`)

### NotePart

ID: `it.vedph.note`

- tag (`string`)
- text (`string`)

### NumberingPart

ID: `it.vedph.numbering`

- number (`string`)
- ordinal (`int`)
- tag (`string`)

### PinLinksPart

ID: `it.vedph.pin-links`

- links (`PinLink[]`):
  - label\* (`string`)
  - itemId\* (`string`)
  - partId\* (`string`)
  - partTypeId\* (`string`)
  - roleId (`string`)
  - name\* (`string`)
  - value\* (`string`)
  - tag (`string`)

### TiledTextLayerPart

ID: `it.vedph.tiled-text-layer`

- fragments (`ITextLayerFragment[]`):
  - location (`string`)
  - ... etc.

### TokenTextLayerPart

- fragments (`ITextLayerFragment[]`):
  - location (`string`)
  - ... etc.

## Fragments

### CommentLayerFragment

ID: `fr.it.vedph.comment`

- location (`string`)
- tag (`string`)
- text (`string`)
- references (`DocReference[]`)
- externalIds (`AssertedId[]`)
- categories (`string[]`)
- keywords (`IndexKeyword[]`)

### PinLinksLayerFragment

ID: `fr.it.vedph.pin-links`

- location (`string`)
- links (`PinLink[]`)

## History

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
