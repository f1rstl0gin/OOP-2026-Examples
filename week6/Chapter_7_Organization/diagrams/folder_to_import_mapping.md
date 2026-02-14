# Chapter 7 — Folder / Namespace / Import Mapping 

## Python (packages and imports)
```mermaid
flowchart LR
  A[app/] --> B[domain/]
  B --> C[geometry/]
  C --> D[contracts.py]
  C --> E[shapes.py]
  C --> F[reporting.py]
  G[main.py] -->|from app.domain.geometry.shapes import Rectangle, Circle| E
  G -->|from app.domain.geometry.reporting import ShapeReporter| F
  F -->|depends on Shape contract| D
  E -->|implements Shape contract| D
```
Key mapping:
- Folder `app/domain/geometry` corresponds to import prefix `app.domain.geometry.*`

## C# (folders to namespaces)
```mermaid
flowchart LR
  A[src/OopOrganization.Chapter7/] --> B[Domain/]
  B --> C[Geometry/]
  C --> D[Contracts/IShape.cs]
  C --> E[Shapes/Rectangle.cs]
  C --> F[Shapes/Circle.cs]
  C --> G[Reporting/ShapeReporter.cs]
  H[Program.cs] -->|using OopOrganization.Domain.Geometry.Shapes| E
  H -->|using OopOrganization.Domain.Geometry.Reporting| G
  G -->|depends on IShape| D
  E -->|implements IShape| D
```
Key mapping:
- Folder `Domain/Geometry/Shapes` maps to `namespace OopOrganization.Domain.Geometry.Shapes;`

## JavaScript (ES Modules + import surfaces)
```mermaid
flowchart LR
  A[src/] --> B[domain/]
  B --> C[geometry/]
  C --> D[contracts/Shape.js]
  C --> E[shapes/Rectangle.js]
  C --> F[shapes/Circle.js]
  C --> G[shapes/index.js]
  C --> H[reporting/ShapeReporter.js]
  I[main.js] -->|import {Rectangle,Circle} from shapes/index.js| G
  I -->|import {ShapeReporter} from reporting/ShapeReporter.js| H
  E -->|extends Shape| D
  F -->|extends Shape| D
```
Key mapping:
- Folder layout becomes import paths like `./domain/geometry/shapes/index.js`
