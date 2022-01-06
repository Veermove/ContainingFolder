using System;

public class Connector
{
    private Resolver resolver;
    public const int defaultDepth = 2;
    public Connector()
    {
        resolver = new Resolver();
    }

    public DirModel getByPath(string path, int? depth)
    {
        if (depth.HasValue)
        {
            return getWithDepth(path, depth.Value);
        } else
        {
            return getDefault(path);
        }
    }
    private DirModel getDefault(string path)
    {
        return resolver.getByPath(path, defaultDepth);
    }

    private DirModel getWithDepth(string path, int depth)
    {
        return resolver.getByPath(path, depth);
    }
}
