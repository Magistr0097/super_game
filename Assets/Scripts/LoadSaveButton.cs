using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadSaveButton : MonoBehaviour
{
    public Save save;
    public GameObject picture;
    public Text text;
    private GameObject SaveLoad;

    private void Start() 
    {
        SaveLoad = GameObject.FindWithTag("SaveLoad");
    }

    public void SetSave(Save comingSave)
    {
        save = comingSave;
        var texture = LoadTexture(save.ScreenShotPath);
        picture.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0,0), 100f);
        text.text = save.Name;
    }

    public void Load()
    {
        SaveLoad.GetComponent<SaveLoad>().Load(save);
    }

    private Texture2D LoadTexture(string filePath)
    {
        if (!File.Exists(filePath)) return null;
        var fileData = File.ReadAllBytes(filePath);
        var tex2D = new Texture2D(2, 2);
        return tex2D.LoadImage(fileData) ? tex2D : null;
    }
}
