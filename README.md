# Cadmus.General.Parts

- [Cadmus.General.Parts](#cadmusgeneralparts)
  - [Parts](#parts)
    - [BibliographyPart](#bibliographypart)
    - [CategoriesPart](#categoriespart)
    - [ChronotopesPart](#chronotopespart)
    - [CommentPart](#commentpart)
    - [DocReferencesPart](#docreferencespart)
    - [ExtBibliographyPart](#extbibliographypart)
    - [HierarchyPart](#hierarchypart)
    - [HistoricalDatePart](#historicaldatepart)
    - [HistoricalEventsPart](#historicaleventspart)
    - [IndexKeywordsPart](#indexkeywordspart)
    - [KeywordsPart](#keywordspart)
    - [MetadataPart](#metadatapart)
    - [NamesPart](#namespart)
    - [NotePart](#notepart)
    - [NumberingPart](#numberingpart)
    - [TiledTextLayerPart](#tiledtextlayerpart)
    - [TokenTextLayerPart](#tokentextlayerpart)
  - [Fragments](#fragments)
    - [CommentLayerFragment](#commentlayerfragment)
  - [History](#history)

This solution contains the Cadmus general parts library derived from `Cadmus.Parts`, in the context of the general refactoring towards a more streamlined and modular system.

The library includes all the old parts with these additions:

- `HistoricalEventsPart`: historical events part.
- `MetadataPart`: generic metadata part.

No part or fragment ID has been changed.

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
- externalIds (`ExternalId[]`):
  - tag (`string`)
  - value (`string`)
  - scope (`string`)
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
  - chronotope (`AssertedChronotope`)
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
- externalIds (`ExternalId[]`):
  - tag (`string`)
  - value (`string`)
  - scope (`string`)
- categories (`string[]`)
- keywords (`IndexKeyword[]`)

## History

- 2022-01-16: added `ChronotopesPart`.
- 2022-01-09: added assertion to external IDs part. Accordingly, the corresponding bricks editor has been updated in the bricks shell project.
