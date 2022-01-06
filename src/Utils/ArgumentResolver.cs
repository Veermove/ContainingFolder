using System;
public static class ArgumentResolver
{
    public static (string, int?, bool?) getArgs(string[] args)
    {
        if (args.GetLength(0) == 2)
        {
            return (args[0], resolveDepth(args[1]), null);
        } else if (args.GetLength(0) == 3)
        {
            return (args[0], resolveDepth(args[1]), resolveOption1(args[2]));
        }
        return (args[0], null, null);
    }

    private static int? resolveDepth(string dep)
    {
        int depth;
        try
        {
            depth = Int32.Parse(dep);
        } catch (Exception e) when (
            e is System.OverflowException
            || e is System.FormatException
            || e is System.ArgumentNullException
        )
        {
            Console.WriteLine("Unalbe to parse depth, going with default value of " + Connector.defaultDepth);
            return null;
        }
        return depth;
    }

    private static bool? resolveOption1(string opt)
    {
        return null;
    }
}
