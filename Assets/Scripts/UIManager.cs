using UnityEngine;
using System.Collections.Generic;
using static Unity.Burst.Intrinsics.X86.Avx;
using System.Xml.Linq;
using UnityEngine.UI;
using Gpm.Common.ThirdParty.MessagePack.Resolvers;


public class UIBase : MonoBehaviour
{

}


public class UIManager : MonoSingletone<UIManager>
{
    [SerializeField]
    private Transform _canvasTrasn;


    // �����̳ʿ� �����ؼ� �����ϸ� �ȴ�. 
    private Dictionary<string, UIBase> _container =  new Dictionary<string, UIBase>();

    private string _uiPath = "Prefab/";


    public void CreateUI<T>() where T : UIBase
    {   
        //StartUI
        GameObject STresGO = Resources.Load<GameObject>(_uiPath + typeof(T).ToString());
        GameObject STsceanGO = Instantiate(STresGO, _canvasTrasn, false);
        T STcomp = STsceanGO.GetComponent<T>();
        _container.Add(typeof(T).ToString(), STcomp);

    }

    private void RemoveContainerUI(string uiName)
    {
        UIBase strtui;
        bool result = _container.TryGetValue(uiName, out strtui);

        if (result)
        {
            Debug.Log(strtui.gameObject.name);
            Destroy(strtui.gameObject);
            _container.Remove(uiName);
        }
    }

    public void CreateStartUI()
    {
        // ModeUI �������� ���ҽ��� �ε��ؼ�, Instantiate�Ѵ�. 
        GameObject resGO = Resources.Load<GameObject>("Prefab/StartUI");
        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        StartUI comp = sceanGO.GetComponent<StartUI>();

        _container.Add(typeof(StartUI).ToString(), comp);
    }

    public void CreateModeUI()
    {
        RemoveContainerUI("StartUI");

        // ���ӸŴ����� ModUI������ְ� �־��µ� 
        GameObject resGO = Resources.Load<GameObject>("Prefab/ModeUI");

        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        ModeUI uiComp = sceanGO.GetComponent<ModeUI>();

        _container.Add("ModeUI", uiComp);

        uiComp.AddTimeClickEvent(GameManager.Instance.OnClickTimeAttackMode);
        uiComp.AddTimeClickEvent(RemoveModeUI);
        
    }

    

    private void RemoveModeUI()
    {
        RemoveContainerUI("ModeUI");
    }

    public void CreateScoreUI()
    {
        
        // ���� UI �ε��ϴ� �κ� 
        GameObject scoreUIRes = Resources.Load<GameObject>("Prefab/ScoreUI");
        GameObject scoreUIGo = Instantiate(scoreUIRes, _canvasTrasn, false);
        ScoreUI scoreUIComp = scoreUIGo.GetComponent<ScoreUI>();

        _container.Add("ScoreUI", scoreUIComp);
        
    }

    public void AddScore()
    {
        UIBase strtui;
        bool result = _container.TryGetValue("ScoreUI", out strtui);

        if (result)
        {
            ScoreUI comp;

            comp = strtui as ScoreUI;

            if (comp != null)
            {
                comp.ChangeScore(2000);
            }
        }

        //scoreUIComp.ChangeScore(20000); 
    }
}
