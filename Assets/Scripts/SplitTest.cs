using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class TestData
{
    public string Name = default;
    public string shumi = default;
}

public class SplitTest : MonoBehaviour
{
    string m_test = "aandbandc";//{m_test : aandbandc }
    TestData m_testData = new TestData();

    void Start()
    {
        //string[] a = { "and" };
        //var b = m_test.Split(a, System.StringSplitOptions.None);
        //Debug.Log(m_test);
        //string c = default;

        //foreach (var d in b)
        //{
        //    Debug.Log(d);
        //}
        m_testData.Name = "a";
        m_testData.shumi = "b";
        var c = JsonUtility.ToJson(m_testData);
        Debug.Log(c);

        TestData test = JsonUtility.FromJson<TestData>(c);
        SavePlayerData(test);
    }

    public void SavePlayerData(TestData test)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(test);

        writer = new StreamWriter(Application.dataPath + "/testdata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
