# Comment

A general purpose free-text comment with some attached metadata.

🔑 `it.vedph.comment`

- tag (`string` 📚 `comment-tags`)
- text* (`string`, MD)
- references (`DocReference[]`):
  - type (`string` 📚 `doc-reference-types`)
  - tag (`string` 📚 `doc-reference-tags`)
  - citation (`string`)
  - note (`string`)
- links (`AssertedCompositeId[]`):
  - target (`PinTarget`):
    - gid\* (`string`)
    - label\* (`string`)
    - itemId (`string`)
    - partId (`string`)
    - partTypeId (`string`)
    - roleId (`string`)
    - name (`string`)
    - value (`string`)
  - scope (`string` 📚 `comment-id-scopes`)
  - tag (`string` 📚 `comment-id-tags`)
  - assertion (`Assertion`):
    - tag (`string` 📚 `assertion-tags`)
    - rank (`short`)
    - references (`DocReference[]`)
- categories (`string[]` 📚 `comment-categories`)
- keywords (`IndexKeyword[]`):
  - language* (`string` 📚 `languages`)
  - value* (`string`)
  - indexId (`string` 📚 `keyword-indexes`)
  - note (`string`)
  - tag (`string` 📚 `keyword-tags`)

Other thesauri:

- 📚 `pin-link-settings`

>⚠️ Note: in versions before 5, `links` was `externalIds` of type `AssertedId[]`.
