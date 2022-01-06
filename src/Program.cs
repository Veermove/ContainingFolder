using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Connector connector = new Connector();
        Painter painter = new Painter();
        var (path, depth, option) = ArgumentResolver.getArgs(args);
        DirModel dir = connector.getByPath(path, depth, option);
        painter.display(dir);
    }
}
