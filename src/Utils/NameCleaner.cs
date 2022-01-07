using System;
using System.Collections.Generic;
public class NameCleaner
{
    public List<string> getNameFromPath(string[] dirty, bool option)
    {
        List<string> ready = new List<string>(dirty.GetLength(0));
        foreach(string s in dirty)
        {
            var name = cleanName(s);
            if (!(name.StartsWith('.') && option))
                {
                    ready.Add(name);
                }
        }
        return ready;
    }

    public string cleanName(string name)
    {
        ReadOnlySpan<char> nameSpan = name.AsSpan();
        if (nameSpan[nameSpan.Length -1] == '/')
        {
            nameSpan = nameSpan.Slice(0, nameSpan.Length - 1);
        }
        int index = nameSpan.LastIndexOf("/");
        return nameSpan
            .Slice(index + 1, (nameSpan.Length - 1) - index)
            .ToString();
    }
}
