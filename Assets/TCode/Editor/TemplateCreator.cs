using UnityEngine;
using UnityEditor;
using System.IO;


public class TemplateCreator : UnityEditor.AssetModificationProcessor
{
    private static string template =
      "/*\nCOMPANY: #COMPANY#\nPROJECT: #PROJECT#\nAUTHOR: #AUTHOR# \nVERSION: 1.0\nCREATION DATE: #CREATIONDATE#\n*/\n";

    private static void OnWillCreateAsset(string assetPath)
    {
        if (assetPath.EndsWith(".cs.meta"))
        {
            assetPath = assetPath.Replace(".meta", "");
            string script = File.ReadAllText(assetPath);
            script = script.Insert(0, template);
            script = ReplaceStrings(script);
            File.WriteAllText(assetPath, script);
        }
    }


    private static string ReplaceStrings(string value)
    {
        value = value.Replace("#COMPANY#", PlayerSettings.companyName);
        value = value.Replace("#PROJECT#", PlayerSettings.productName);
        value = value.Replace("#AUTHOR#", "Thiago Z Silva");
        value = value.Replace("#CREATIONDATE#", System.DateTime.Today.ToString().Substring(0, 10));
        return value;
    }
}
