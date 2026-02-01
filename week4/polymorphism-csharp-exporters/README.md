# Week 4 – Polymorphism (C# Document Exporters)

**Domain:** Document exporting (PDF, CSV, HTML)

## Highlights

- `DocumentExporter` is an abstract base class that enforces the contract.
- Each exporter overrides `Export()` with its own output behavior.
- A single list of exporters can invoke the same method and get different results.

## Run the example

```bash
dotnet run --project PolymorphismExporters.csproj
```
