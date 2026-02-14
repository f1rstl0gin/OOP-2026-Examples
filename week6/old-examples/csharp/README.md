# Chapter 7 (C#) — Organization of Object-Oriented Code (Modern)

This mini-solution demonstrates organization using:

- Folders mirroring namespace hierarchy
- Interface contracts in a `Contracts` namespace
- A small domain with a service class (`ShapeReporter`)

## Build & run (NET 8)
From this folder:

```bash
dotnet build
dotnet run --project src/OopOrganization.Chapter7/OopOrganization.Chapter7.csproj
```

## What to look for in lecture
- How folders map to namespaces like `OopOrganization.Domain.Geometry.Shapes`
- How the reporter depends on `IShape` (contract) instead of concrete types
