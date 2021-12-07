using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonTest : MonoBehaviour
{
    [System.Serializable]
    public class Player 
    {
        public string name;
        public int genderType;
    }
    
    void Start()
    {
        Player player = new Player();

        player.name = "中島";
        player.genderType = 1;

        string jsonStr = JsonUtility.ToJson(player);

        Debug.Log(jsonStr);

        Player player2 = JsonUtility.FromJson<Player>(jsonStr);

        Debug.Log(player2.name);
        Debug.Log(player2.genderType);

        SavePlayerData(player);
    }

    public void SavePlayerData(Player player)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(player);

        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    public void Loading()
    {

    }
}
