using System;
using System.Collections.Generic;
using System.IO;

public class Resolver
{

    private NameCleaner cleaner = new NameCleaner();
    private DirModel currentDirectory;

// create new model of directory including: all file names,
//    all folder names,
//    own name,
//    own path,
//    models of directories in current folder,

    public DirModel getByPath(string givenPath, int depth)
    {
        // Console.WriteLine(givenPath);
        var subDirs = resolveFolders(givenPath, depth);
        currentDirectory = new DirModel()
        {
            subfolders = subDirs,
            files = resolveFiles(givenPath),
            name = cleaner.cleanName(givenPath),
            path = givenPath,
        };
        return currentDirectory;
    }

    private List<string> resolveFiles(string path)
    {
        try
        {
            string[] fils = Directory.GetFiles(path);
            return cleaner.getNameFromPath(fils);
        } catch (System.IO.DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }


    private List<DirModel> resolveFolders(string path, int depth)
    {
        try
        {
            string[] dirs = Directory.GetDirectories(path);
            if (dirs.GetLength(0) < 1)
            {
                return null;
            }

            var dirsModel = new List<DirModel>(dirs.GetLength(0));
            foreach(string folder in dirs)
            {
                dirsModel.Add(getByPath(folder, depth - 1));
            }
            dirsModel.Sort(DirModel.CompareByName);
            return dirsModel;
        } catch (System.IO.DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

}
