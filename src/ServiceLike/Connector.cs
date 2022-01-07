using System;

public class Connector
{
    private Resolver resolver;
    public const int defaultDepth = 10;
    public Connector()
    {
        resolver = new Resolver();
    }

    public DirModel getByPath(string path, int? depth, bool? opt)
    {
        if (path is null)
        {
            return null;
        } else if (depth.HasValue && !opt.HasValue)
        {
            return getWithDepth(path, depth.Value);
        }
        else if (depth.HasValue && opt.HasValue)
        {
            return getWithDepthAndOption(path, depth.Value, opt.Value);
        } else
        {
            return getDefault(path);
        }
    }
    private DirModel getDefault(string path)
    {
        return resolver.getByPath(path, defaultDepth, false);
    }

    private DirModel getWithDepth(string path, int depth)
    {
        return resolver.getByPath(path, depth, false);
    }

    private DirModel getWithDepthAndOption(string path, int depth, bool option)
    {
        return resolver.getByPath(path, depth, option);
    }
}
