using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadLines : MonoBehaviour
{
    void Start()
    {
        var path = System.IO.Directory.GetCurrentDirectory() + "\\Dialogues.csv";
        var fileData = System.IO.File.ReadAllText(path)
            .Split(new string[] { ";\"", "\"" }, System.StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < fileData.Length-1; i+=2)
        {
            Variables.linesDict[fileData[i].Trim()] = fileData[i+1].Trim().Split('\n'); 
        }
    }
}
