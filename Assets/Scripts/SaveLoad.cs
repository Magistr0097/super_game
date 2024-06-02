using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Linq;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    public SceneManager sceneManager;
    public GameObject[] enemySaves;
    public GameObject mainPlayerSave;
    public GameObject camera;
    public GameObject UICanvas;
    private string filePath;
    private string screenShotPath;
    private static readonly Dictionary<string, int> sceneIndexFromName = new Dictionary<string, int>{{"MenuScene", 0}, {"Forest", 1}, {"Town", 2}, {"Room", 3}};

    private void Start()
    {
        filePath = Application.persistentDataPath + "/Saves";
        if(!System.IO.Directory.Exists(filePath))
            System.IO.Directory.CreateDirectory(filePath);
            
        screenShotPath = Application.persistentDataPath + "/SavePictures";
        if(!System.IO.Directory.Exists(screenShotPath))
            System.IO.Directory.CreateDirectory(screenShotPath);

        enemySaves = GameObject.FindGameObjectsWithTag("Enemy");
    }
    
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        var time = DateTime.Now;
        FileStream fs = new FileStream(filePath + $"/save-{time.Year}-{time.Month}-{time.Day}-{time.Hour}-{time.Minute}-{time.Second}.gamesave", FileMode.Create);
        Save save = new Save();
        save.SaveMainPlayer(mainPlayerSave);
        save.SaveEnemies(enemySaves);
        save.SaveVars();
        save.Scene = gameObject.scene.name;
        save.Name = $"save {String.Format("{0:dd.MM.yyyy HH:mm:ss}", time)}";
        save.ScreenShotPath = screenShotPath + $"/saveScreenshot-{time.Year}-{time.Month}-{time.Day}-{time.Hour}-{time.Minute}-{time.Second}.png";
        ScreenCapture.CaptureScreenshot(screenShotPath + $"/saveScreenshot-{time.Year}-{time.Month}-{time.Day}-{time.Hour}-{time.Minute}-{time.Second}.png");
        bf.Serialize(fs, save);
        fs.Close();
    }

    public void Load(Save save)
    {
        if (gameObject.scene.name != save.Scene)
        {
            Variables.LoadedSave = save;
            sceneManager.ChangeScene(sceneIndexFromName[save.Scene]);
            return;
        }
        
        mainPlayerSave.GetComponent<PlayerMovement>().LoadData(save.mainPlayerData);
        for (var i = 0; i < enemySaves.Length; i++)
        {
            enemySaves[i].GetComponent<AINavigation>().LoadData(save.enemiesData[i]);
        }
        Variables.IsFirstStartGame = save.IsFirstStartGame;
        Variables.MoveTutorialComplete = save.MoveTutorialComplete;
        Variables.TPTutorialComplete = save.TPTutorialComplete;
        Variables.ForestStage = save.ForestStage;
        Variables.TownStage = save.TownStage;
        Variables.RoomStage = save.RoomStage;

        camera.GetComponent<CameraFollow>().CenterOnPlayer();
    }
}





[System.Serializable]
public class Save
{
    [System.Serializable]
    public struct Vec3
    {
        public float x, y, z;

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [System.Serializable]
    public struct MainPlayer
    {
        public Vec3 position;

        public MainPlayer(Vector3 position)
        {
            this.position = new Vec3(position.x, position.y, position.z);
        }
    }

    [System.Serializable]
    public struct Enemy
    { 
        public Vec3 position;
        public float rotation;

        public Enemy(Vector3 position, float rotation)
        {
            this.position = new Vec3(position.x, position.y, position.z);
            this.rotation = rotation;
        }
    }

    public List<Enemy> enemiesData = new List<Enemy>();
    public MainPlayer mainPlayerData = new MainPlayer();
    public bool IsFirstStartGame = false;
    public bool MoveTutorialComplete = false;
    public bool TPTutorialComplete = false;
    public int ForestStage = 0;
    public int TownStage = 0;
    public int RoomStage = 0;
    public string Scene = "";
    public string ScreenShotPath = "";
    public string Name = "";

    public void SaveMainPlayer(GameObject mainPlayer)
    {
        mainPlayerData = new MainPlayer(mainPlayer.transform.position);
    }

    public void SaveEnemies(GameObject[] enemies)
    {
        foreach (var enemy in enemies)
        {
            var position = enemy.transform.position;
            var rotation = enemy.GetComponent<AINavigation>().rotation;
            enemiesData.Add(new Enemy(position, rotation));
        }
    }

    public void SaveVars()
    {
        IsFirstStartGame = Variables.IsFirstStartGame;
        MoveTutorialComplete = Variables.MoveTutorialComplete;
        TPTutorialComplete = Variables.TPTutorialComplete;
        ForestStage = Variables.ForestStage;
        TownStage = Variables.TownStage;
        RoomStage = Variables.RoomStage;
    }
}
