// Command design pattern

using System;


// Example - 1
// Command interface
public interface ILightCommand
{
    void Execute();
}

// Concrete Commands
public class LightOnCommand : ILightCommand
{
    private readonly Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOn();
    }
}

public class LightOffCommand : ILightCommand
{
    private readonly Light light;

    public LightOffCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOff();
    }
}

// Receiver
public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Light is OFF");
    }
}

// Invoker
public class RemoteControl
{
    private ILightCommand currentCommand;

    public void SetCommand(ILightCommand command)
    {
        this.currentCommand = command;
    }

    public void PressButton()
    {
        currentCommand.Execute();
    }
}


// Example - 2
// Command interface
public interface ITextCommand
{
    void Execute();
}

// Concrete Commands
public class CutTextCommand : ITextCommand
{
    private readonly TextEditor textEditor;

    public CutTextCommand(TextEditor textEditor)
    {
        this.textEditor = textEditor;
    }

    public void Execute()
    {
        textEditor.CutText();
    }
}

public class CopyTextCommand : ITextCommand
{
    private readonly TextEditor textEditor;

    public CopyTextCommand(TextEditor textEditor)
    {
        this.textEditor = textEditor;
    }

    public void Execute()
    {
        textEditor.CopyText();
    }
}

public class PasteTextCommand : ITextCommand
{
    private readonly TextEditor textEditor;

    public PasteTextCommand(TextEditor textEditor)
    {
        this.textEditor = textEditor;
    }

    public void Execute()
    {
        textEditor.PasteText();
    }
}

// Receiver
public class TextEditor
{
    private string clipboard;

    public void CutText()
    {
        clipboard = "Cut text";
        Console.WriteLine("Text is cut");
    }

    public void CopyText()
    {
        clipboard = "Copied text";
        Console.WriteLine("Text is copied");
    }

    public void PasteText()
    {
        Console.WriteLine($"Pasting: {clipboard}");
    }
}

// Invoker
public class MenuInvoker
{
    private readonly List<ITextCommand> textCommands = new List<ITextCommand>();

    public void AddTextCommand(ITextCommand command)
    {
        textCommands.Add(command);
    }

    public void ExecuteTextCommands()
    {
        foreach (var command in textCommands)
        {
            command.Execute();
        }
    }
}

// Client
class Program
{
    static void Main()
    {
        // Example - 1
        Console.WriteLine("Example 1: ");
        Light livingRoomLight = new Light();

        ILightCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
        ILightCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);

        RemoteControl livingRoomRemote = new RemoteControl();

        livingRoomRemote.SetCommand(livingRoomLightOn);
        livingRoomRemote.PressButton(); // Light in the living room is ON

        livingRoomRemote.SetCommand(livingRoomLightOff);
        livingRoomRemote.PressButton(); // Light in the living room is OFF


        // Example - 2
        Console.WriteLine("\nExample 2: ");
        TextEditor documentEditor = new TextEditor();

        ITextCommand cutTextCommand = new CutTextCommand(documentEditor);
        ITextCommand copyTextCommand = new CopyTextCommand(documentEditor);
        ITextCommand pasteTextCommand = new PasteTextCommand(documentEditor);

        MenuInvoker textMenu = new MenuInvoker();
        textMenu.AddTextCommand(cutTextCommand);
        textMenu.AddTextCommand(copyTextCommand);
        textMenu.AddTextCommand(pasteTextCommand);

        textMenu.ExecuteTextCommands();
    }
}
