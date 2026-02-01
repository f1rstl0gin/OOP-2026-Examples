using System;
using System.Collections.Generic;

public abstract class DocumentExporter
{
    public abstract void Export(string content);
}

public class PdfExporter : DocumentExporter
{
    public override void Export(string content)
    {
        Console.WriteLine($"Exporting PDF: {content}");
    }
}

public class CsvExporter : DocumentExporter
{
    public override void Export(string content)
    {
        Console.WriteLine($"Exporting CSV: {content}");
    }
}

public class HtmlExporter : DocumentExporter
{
    public override void Export(string content)
    {
        Console.WriteLine($"Exporting HTML: {content}");
    }
}

List<DocumentExporter> exporters = new()
{
    new PdfExporter(),
    new CsvExporter(),
    new HtmlExporter(),
};

foreach (DocumentExporter exporter in exporters)
{
    exporter.Export("Quarterly Report");
}
