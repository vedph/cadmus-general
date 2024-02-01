# Names

List of generic proper names.

🔑 `it.vedph.names`

- names (`AssertedProperName[]`):
  - language (`string` 📚 `name-languages`)
  - tag (`string` 📚 `name-tags`)
  - pieces (`ProperNamePiece[]`):
    - type (`string` 📚 `name-piece-types`)
    - value (`string`)
  - assertion (`Assertion`):
    - tag (`string` 📚 `assertion-tags`)
    - rank (`short`)
    - references (`DocReference[]`):
      - type (`string` 📚 `doc-reference-types`)
      - tag (`string` 📚 `doc-reference-tags`)
      - citation (`string`)
      - note (`string`)
