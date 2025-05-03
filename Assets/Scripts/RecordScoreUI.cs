using UnityEngine;
using TMPro;
using System;
using System.IO;

[Serializable] // 파일로 쓸수 있거나, 서버에 데이터 보낼 수 있다.
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
        //클래스 -> JSON 변환
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
            Debug.Log("불러오기 완료: " + data.Name + ", Level : " + data.Level);
          
        }
        else
        {
            Debug.LogWarning("저장 파일이 없습니다");
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
