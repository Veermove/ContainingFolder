using System;
public class Painter
{

    private int indentationIncrement = 3;

    public Painter(){}
    public Painter(int indentationIncrement)
    {
        this.indentationIncrement = indentationIncrement;
    }
    public void display(DirModel directory)
    {
        drawSubtree(directory, "");
    }

    private void drawSubtree(DirModel dirModel, string currentIndentation)
    {
        if (dirModel is null)
        {
            return;
        }

        // Console.WriteLine(currentIndentation + dirModel.name + ":");
        Console.Write(currentIndentation);
        displayFolderName(dirModel.name);
        Console.Write(":\n");

        string indentation = new String(' ', indentationIncrement - 1);
        if (!(dirModel.subfolders is null))
        {
            foreach(DirModel directory in dirModel.subfolders)
            {
                drawSubtree(directory, currentIndentation + "|" + indentation);
            }
        }

        drawSubfiles(dirModel, currentIndentation + "|" + indentation);

    }
    private void drawSubfiles(DirModel dirModel, string currentIndentation)
    {
        Random rng = new Random();
        int colorCode = rng.Next(105, 227);
        foreach(string file in dirModel.files)
        {
            // Console.WriteLine(currentIndentation + file);
            Console.Write(currentIndentation);
            displayFileName(file, colorCode);
            Console.Write("\n");
        }
    }

    private void displayFolderName(string folderName)
    {
        Console.Write("\u001b[1m");
        Console.Write(folderName);
        Console.Write("\u001b[0m");
    }

    private void displayFileName(string fileName, int colorCode)
    {
        Console.Write("\u001b[3m");
        Console.Write($"\u001b[38;5;{colorCode}m");
        Console.Write(fileName);
        Console.Write("\u001b[0m");
    }
}
