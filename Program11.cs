// Memento design pattern

using System;
using System.Collections.Generic;


// Example -1
// Memento
public class TextEditorMemento
{
    public string Text { get; }

    public TextEditorMemento(string text)
    {
        Text = text;
    }
}

// Originator
public class TextEditor
{
    private string text;

    public string Text
    {
        get => text;
        set
        {
            text = value;
            Console.WriteLine($"Current Text: {text}");
        }
    }

    public TextEditorMemento Save()
    {
        return new TextEditorMemento(text);
    }

    public void Restore(TextEditorMemento memento)
    {
        text = memento.Text;
        Console.WriteLine($"Restored Text: {text}");
    }
}

// Caretaker
public class TextEditorHistory
{
    private readonly List<TextEditorMemento> history = new List<TextEditorMemento>();

    public void Push(TextEditorMemento memento)
    {
        history.Add(memento);
    }

    public TextEditorMemento Pop()
    {
        if (history.Count > 0)
        {
            var lastIndex = history.Count - 1;
            var lastMemento = history[lastIndex];
            history.RemoveAt(lastIndex);
            return lastMemento;
        }
        else
        {
            return null;
        }
    }
}

// Example -2
// Memento
public class DocumentMemento
{
    public string Content { get; }

    public DocumentMemento(string content)
    {
        Content = content;
    }
}

// Originator
public class Document
{
    private string content;
    private readonly Stack<DocumentMemento> history = new Stack<DocumentMemento>();
    private readonly Stack<DocumentMemento> redoStack = new Stack<DocumentMemento>();

    public string Content
    {
        get => content;
        set
        {
            content = value;
            Console.WriteLine($"Current Content: {content}");
        }
    }

    public void Save()
    {
        history.Push(new DocumentMemento(content));
        redoStack.Clear(); // Clear redo stack when a new change is made
    }

    public void Undo()
    {
        if (history.Count > 0)
        {
            redoStack.Push(new DocumentMemento(content));
            var lastMemento = history.Pop();
            content = lastMemento.Content;
            Console.WriteLine($"Undo - Content: {content}");
        }
        else
        {
            Console.WriteLine("Undo not possible");
        }
    }

    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            history.Push(new DocumentMemento(content));
            var redoMemento = redoStack.Pop();
            content = redoMemento.Content;
            Console.WriteLine($"Redo - Content: {content}");
        }
        else
        {
            Console.WriteLine("Redo not possible");
        }
    }
}

// Client
class Program
{
    static void Main()
    {
        // Example -1
        Console.WriteLine("Example 1: ");
        TextEditor textEditor = new TextEditor();
        TextEditorHistory history = new TextEditorHistory();

        // Typing and saving changes
        textEditor.Text = "First line";
        history.Push(textEditor.Save());

        textEditor.Text = "Second line";
        history.Push(textEditor.Save());

        // Restoring to the previous state
        textEditor.Restore(history.Pop()); // Restored Text: Second line

        // Typing and saving more changes
        textEditor.Text = "Modified second line";
        history.Push(textEditor.Save());

        // Restoring to the original state
        textEditor.Restore(history.Pop()); // Restored Text: First line

        // Example -2
        Console.WriteLine("\nExample 2: ");
        Document document = new Document();

        document.Content = "First version";
        document.Save();

        document.Content = "Second version";
        document.Save();

        document.Undo(); // Undo - Content: First version
        document.Redo(); // Redo - Content: Second version
        document.Undo(); // Undo - Content: First version
    }
}
