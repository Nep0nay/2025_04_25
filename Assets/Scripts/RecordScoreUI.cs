using UnityEngine;
using TMPro;
using System;
using System.IO;

[Serializable] // ���Ϸ� ���� �ְų�, ������ ������ ���� �� �ִ�.
public class PlayerInfo
{
    public string Name { get; set; }
    public int Level { get; set; }

}

public class TestScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _Text;

    private void SaveToFile()
    {
        PlayerInfo newPlayerInfo = new PlayerInfo();
        newPlayerInfo.Name = "Nep0nay";
        newPlayerInfo.Level = 10;
        //Ŭ���� -> JSON ��ȯ
        string json = JsonUtility.ToJson(newPlayerInfo, true);
        string path = Application.persistentDataPath + "/Nep0nay.txt";

        File.WriteAllText(path, json);
    }

    private void LoadToFile()
    {
        string path = Application.persistentDataPath + "/Nep0nay.txt";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerInfo data = JsonUtility.FromJson<PlayerInfo>(json);
            Debug.Log("�ҷ����� �Ϸ�: " + data.Name + ", Level : " + data.Level);
          
        }
        else
        {
            Debug.LogWarning("���� ������ �����ϴ�");
        }
    }    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

        }

        if (Input.GetKeyDown(KeyCode.W))
        {

        }
    }
}
