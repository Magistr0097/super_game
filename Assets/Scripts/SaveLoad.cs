using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad : MonoBehaviour
{
    string filePath;

    public GameObject[] enemySaves;
    public GameObject mainPlayerSave;

    private void Start()
    {
        filePath = Application.persistentDataPath + "/save.gamesave";
        enemySaves = GameObject.FindGameObjectsWithTag("Enemy");
    }
    
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);
        Save save = new Save();
        save.SaveMainPlayer(mainPlayerSave);
        save.SaveEnemies(enemySaves);
        bf.Serialize(fs, save);
        fs.Close();
    }

    public void Load()
    {
        if (!File.Exists(filePath))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);
        Save save = (Save)bf.Deserialize(fs);
        fs.Close();

        mainPlayerSave.GetComponent<PlayerMovement>().LoadData(save.mainPlayerData);
        for (var i = 0; i < enemySaves.Length; i++)
        {
            enemySaves[i].GetComponent<AINavigation>().LoadData(save.enemiesData[i]);
        }
        Variables.IsFirstStartGame = save.IsFirstStartGame;
        Variables.MoveTutorialComplete = save.MoveTutorialComplete;
        Variables.ForestStage = save.ForestStage;
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
    public int ForestStage = 0;

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
        ForestStage = Variables.ForestStage;
    }
}
