# External IDs

External identifiers.

🔑 `it.vedph.external-ids`

- ids (`AssertedId[]`):
  - tag (`string` 📚 `external-id-tags`)
  - value\* (`string`)
  - scope (`string` 📚 `external-id-scopes`)
  - assertion (`Assertion`):
    - tag (`string` 📚 `assertion-tags`)
    - rank\* (`string`)
    - note (`string`)
    - references (`DocReference[]`):
      - type (`string` 📚 `doc-reference-types`)
      - tag (`string` 📚 `doc-reference-tags`)
      - citation (`string`)
      - note (`string`)
