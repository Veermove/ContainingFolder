using System;
using System.Collections.Generic;

public class DirModel
{
    public List<string> files { get; init; }
    public List<DirModel> subfolders { get; init; }
    public string name { get; init; }
    public string path { get; init; }

    public static int CompareByName(DirModel modelOne, DirModel modelTwo)
    {
        return String.Compare(modelOne.name, modelTwo.name);
    }
}
