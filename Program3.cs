// Abstract Factory design pattern

using System;


// EXAMPLE # 1
// Abstract Factory interface
interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Concrete Factory for Windows
class WindowsFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new WindowsButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new WindowsCheckbox();
    }
}

// Concrete Factory for Mac
class MacFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new MacButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new MacCheckbox();
    }
}

// Abstract Product: Button
interface IButton
{
    void Render();
}

// Concrete Product: Windows Button
class WindowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Render Windows Button");
    }
}

// Concrete Product: Mac Button
class MacButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Render Mac Button");
    }
}

// Abstract Product: Checkbox
interface ICheckbox
{
    void Display();
}

// Concrete Product: Windows Checkbox
class WindowsCheckbox : ICheckbox
{
    public void Display()
    {
        Console.WriteLine("Display Windows Checkbox");
    }
}

// Concrete Product: Mac Checkbox
class MacCheckbox : ICheckbox
{
    public void Display()
    {
        Console.WriteLine("Display Mac Checkbox");
    }
}

// Client code
class GUIApplication
{
    private readonly IGUIFactory factory;

    public GUIApplication(IGUIFactory factory)
    {
        this.factory = factory;
    }

    public void CreateUI()
    {
        var button = factory.CreateButton();
        var checkbox = factory.CreateCheckbox();

        button.Render();
        checkbox.Display();
    }
}



// EXAMPLE # 2
// Abstract Factory interface
interface IDocumentConverterFactory
{
    IDocumentConverter CreatePdfConverter();
    IDocumentConverter CreateCsvConverter();
}

// Concrete Factory for PDF
class PdfConverterFactory : IDocumentConverterFactory
{
    public IDocumentConverter CreatePdfConverter()
    {
        return new PdfConverter();
    }

    public IDocumentConverter CreateCsvConverter()
    {
        return new CsvToPdfConverter();
    }
}

// Concrete Factory for CSV
class CsvConverterFactory : IDocumentConverterFactory
{
    public IDocumentConverter CreatePdfConverter()
    {
        return new PdfToCsvConverter();
    }

    public IDocumentConverter CreateCsvConverter()
    {
        return new CsvConverter();
    }
}

// Abstract Product: Document Converter
interface IDocumentConverter
{
    void Convert();
}

// Concrete Product: PDF Converter
class PdfConverter : IDocumentConverter
{
    public void Convert()
    {
        Console.WriteLine("Converting to PDF");
    }
}

// Concrete Product: CSV Converter
class CsvConverter : IDocumentConverter
{
    public void Convert()
    {
        Console.WriteLine("Converting to CSV");
    }
}

// Concrete Product: PDF to CSV Converter
class PdfToCsvConverter : IDocumentConverter
{
    public void Convert()
    {
        Console.WriteLine("Converting from PDF to CSV");
    }
}

// Concrete Product: CSV to PDF Converter
class CsvToPdfConverter : IDocumentConverter
{
    public void Convert()
    {
        Console.WriteLine("Converting from CSV to PDF");
    }
}

// Client code
class DocumentConversionApp
{
    private readonly IDocumentConverterFactory factory;

    public DocumentConversionApp(IDocumentConverterFactory factory)
    {
        this.factory = factory;
    }

    public void ConvertDocuments()
    {
        var pdfConverter = factory.CreatePdfConverter();
        var csvConverter = factory.CreateCsvConverter();

        pdfConverter.Convert();
        csvConverter.Convert();
    }
}


class Program
{
    static void Main()
    {
        // EXAMPLE # 1
        // For Windows
        var windowsFactory = new WindowsFactory();
        var windowsApp = new GUIApplication(windowsFactory);
        windowsApp.CreateUI();

        // For Mac
        var macFactory = new MacFactory();
        var macApp = new GUIApplication(macFactory);
        macApp.CreateUI();
        Console.WriteLine("");

        // EXAMPLE # 2
        // For PDF conversion
        var pdfConverterFactory = new PdfConverterFactory();
        var pdfApp = new DocumentConversionApp(pdfConverterFactory);
        pdfApp.ConvertDocuments();

        // For CSV conversion
        var csvConverterFactory = new CsvConverterFactory();
        var csvApp = new DocumentConversionApp(csvConverterFactory);
        csvApp.ConvertDocuments();
    }
}
