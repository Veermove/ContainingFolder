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

    public DirModel getByPath(string givenPath, int depth, bool option)
    {
        var subDirs = resolveFolders(givenPath, depth, option);
        currentDirectory = new DirModel()
        {
            subfolders = subDirs,
            files = resolveFiles(givenPath, option),
            name = cleaner.cleanName(givenPath),
            path = givenPath,
        };
        return currentDirectory;
    }

    private List<string> resolveFiles(string path, bool option)
    {
        try
        {
            string[] fils = Directory.GetFiles(path);
            return cleaner.getNameFromPath(fils, option);
        } catch (System.IO.DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }


    private List<DirModel> resolveFolders(string path, int depth, bool option)
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
                if (folder.StartsWith('.') && option)
                {

                } else
                {
                    dirsModel.Add(getByPath(folder, depth - 1, option));
                }
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
