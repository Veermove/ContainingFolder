using System;
using System.Collections.Generic;
public class NameCleaner
{
    public List<string> getNameFromPath(string[] dirty)
    {
        List<string> ready = new List<string>(dirty.GetLength(0));
        foreach(string s in dirty)
        {
            ready.Add(cleanName(s));
        }
        return ready;
    }

    public string cleanName(string name)
    {
        ReadOnlySpan<char> nameSpan = name.AsSpan();
        int index = nameSpan.LastIndexOf("/");
        return nameSpan
            .Slice(index + 1, (nameSpan.Length - 1) - index)
            .ToString();
    }
}
