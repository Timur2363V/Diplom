using System;
using System.IO;
using UnityEngine;

[Serializable]
public class ReplacerScripts
{
    [SerializeField]
    private string nameScript;
    [SerializeField]
    private string nameMethod;

    public string NameScript => nameScript;
    public string NameMethod => nameMethod;

    public void Replace(ReplacerScripts replacerScripts)
    {
        var directoryInfo = new DirectoryInfo(Application.dataPath);
        GetFileDirectories(directoryInfo, replacerScripts);
    }

    private void GetFileDirectories(DirectoryInfo directoryInfo, ReplacerScripts replacerScripts)
    {
        foreach (var directory in directoryInfo.GetDirectories())
        {
            GetFileDirectories(directory, replacerScripts);
            GetFiles(directory, replacerScripts);
        }

        GetFiles(directoryInfo, replacerScripts);
    }

    private void GetFiles(DirectoryInfo directory, ReplacerScripts replacerScripts)
    {
        foreach (var fileInfo in directory.GetFiles())
        {
            if (!fileInfo.Name.EndsWith(".cs"))
                continue;

            var nameWithoutExpansion = fileInfo.Name.Substring(0, fileInfo.Name.Length - 3);

            if (nameWithoutExpansion != replacerScripts.NameScript)
            {
                ReplaceScriptText(fileInfo, replacerScripts.NameScript, nameScript);
            }
        }
    }

    private void ReplaceScriptText(FileInfo fileInfo, string text, string replaceText)
    {
        string fileText = File.ReadAllText(fileInfo.FullName);
        fileText = fileText.Replace(text + " ", replaceText + " ");
        File.WriteAllText(fileInfo.FullName, fileText);
    }
}
