using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndUI : UIBase
{
    [SerializeField]
    private Button _LobbyButton;

    void Start()
    {
        _LobbyButton.onClick.AddListener(OnClickGotoLobby);
    }

    private void OnClickGotoLobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    void Update()
    {
        
    }
}
