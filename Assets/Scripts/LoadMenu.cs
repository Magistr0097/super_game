using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadMenu : MonoBehaviour
{
    public Save[] saves;
    public GameObject[] loadButtons;
    private string filePath;
    private string screenShotPath;
    private int index = 0;

    private void Start()
    {
        filePath = Application.persistentDataPath + "/Saves";
        screenShotPath = Application.persistentDataPath + "/SavePictures";
    }
    public void GetSaves()
    {
        var filePaths = Directory.GetFiles(Application.persistentDataPath + "/Saves");
        if (filePaths.Length <= 0) return;
        filePaths = TakeDate(filePaths).OrderByDescending(x => x.Item2).Select(x => x.Item1).ToArray();
        var bf = new BinaryFormatter();
        var temp = new List<Save>();
        foreach (var path in filePaths)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            try
            {
                temp.Add((Save)bf.Deserialize(fs));
            }
            catch
            {}
            fs.Close();
        }
        saves = temp.ToArray();
        index = 0;
        SetSaves();
    }

    private void SetSaves()
    {
        for (var i = 0; i < 3; i++)
        {
            if (i+index < saves.Length)
            {
                loadButtons[i].SetActive(true);
                loadButtons[i].GetComponent<LoadSaveButton>().SetSave(saves[i + index]);
            }
            else
                loadButtons[i].SetActive(false);
        }
    }

    public void Previous()
    {
        if (index > 0)
        {
            index--;
            SetSaves();
        }
    }

    public void Next()
    {
        if (2+index <= saves.Length)
        {
            index++;
            SetSaves();
        }
    }

    private IEnumerable<(string, DateTime)> TakeDate(IEnumerable<string> saves)
    {
        foreach (var saveName in saves)
        {
            var split = saveName.Split(new []{'-', '.'});
            yield return (saveName, new DateTime(Int32.Parse(split[1]), Int32.Parse(split[2]), Int32.Parse(split[3]),
                                                 Int32.Parse(split[4]), Int32.Parse(split[5]) ,Int32.Parse(split[6])));
        }
    }
}