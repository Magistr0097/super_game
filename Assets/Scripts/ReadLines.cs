using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadLines : MonoBehaviour
{
    
    private Variables variables;
    void Start()
    {
        variables = GameObject.FindWithTag("Variables").GetComponent<Variables>();

        var path = System.IO.Directory.GetCurrentDirectory() + "\\Dialogues.csv";
        var fileData = System.IO.File.ReadAllText(path).Split(new string[]{";\"", "\""}, System.StringSplitOptions.RemoveEmptyEntries);

        for (var i = 0; i < fileData.Length-1; i+=2)
        {
            variables.linesDict[fileData[i].Trim()] = fileData[i+1].Trim().Split('\n'); 
        }
    }
}
