# Chapter 7 (JavaScript) — Organization of Object-Oriented Code (Modern)

This mini-project demonstrates organizing OO JavaScript using:

- **ES Modules** (Node 18+)
- A domain folder layout (`src/domain/...`)
- An optional “namespace object” pattern for browser scenarios

## Run
From this folder:

```bash
npm install
npm run demo
```

## What to look for in lecture
- `src/domain/geometry/shapes/index.js` acts as a clean import surface.
- `src/domain/namespaceStyle.js` shows the nested-object “namespace” pattern.
