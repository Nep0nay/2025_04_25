using UnityEngine;
using System.Collections.Generic;
using static Unity.Burst.Intrinsics.X86.Avx;
using System.Xml.Linq;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{

}


// 생성, 관리,삭제를 담당하겠다. 
// 이름으로 관리! 

public class UIManager : MonoSingletone<UIManager>
{
    private Transform _canvasTrasn;

    private Dictionary<string, UIBase> _container =  new Dictionary<string, UIBase>();

    // 컨테이너에 저장해서 관리하면 된다. 

    private string _uiPath = "Prefab/";

    private void Awake()
    {
        if(_canvasTrasn == null)
        {
            gameObject.AddComponent<Canvas>();
            gameObject.AddComponent<CanvasScaler>();
            _canvasTrasn = gameObject.transform;
        }    
        else
            _canvasTrasn = transform;
    }

    public void CreateUI<T>() where T : UIBase
    {   
        //StartUI
        GameObject STresGO = Resources.Load<GameObject>(_uiPath + typeof(T).ToString());
        GameObject STsceanGO = Instantiate(STresGO, _canvasTrasn, false);
        T STcomp = STsceanGO.GetComponent<T>();
        _container.Add(typeof(T).ToString(), STcomp);

        RemoveContainerUI("StartUI");

        //ModeUI
        GameObject MDresGO = Resources.Load<GameObject>(_uiPath + typeof(T).ToString());
        GameObject MDsceanGO = Instantiate(MDresGO, _canvasTrasn, false);
        T MDuiComp = MDsceanGO.GetComponent<T>();
        _container.Add(typeof(T).ToString(), MDuiComp);

        ModeUI modeUI = MDuiComp as ModeUI;
        if (modeUI != null)
        {
            modeUI.AddTimeClickEvent(GameManager.Instance.OnClickTimeAttackMode);
            RemoveContainerUI("ModeUI");
        }

        //ScoreUI
        GameObject scoreUIRes = Resources.Load<GameObject>(_uiPath + typeof(T).ToString());
        GameObject scoreUIGo = Instantiate(scoreUIRes, _canvasTrasn, false);
        T scoreUIComp = scoreUIGo.GetComponent<T>();
        _container.Add(typeof(T).ToString(), scoreUIComp);


        //Add Score
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
        // ModeUI 프리팹을 리소스를 로드해서, Instantiate한다. 
        /*GameObject resGO = Resources.Load<GameObject>("Prefab/StartUI");
        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        StartUI comp = sceanGO.GetComponent<StartUI>();

        _container.Add(typeof(StartUI).ToString(), comp);*/
    }

    public void CreateModeUI()
    {
        /*RemoveContainerUI("StartUI");

        // 게임매니저가 ModUI만들어주고 있었는데 
        GameObject resGO = Resources.Load<GameObject>("Prefab/ModeUI");

        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        ModeUI uiComp = sceanGO.GetComponent<ModeUI>();

        _container.Add("ModeUI", uiComp);

        uiComp.AddTimeClickEvent(GameManager.Instance.OnClickTimeAttackMode);
        uiComp.AddTimeClickEvent(RemoveModeUI);
        */
    }

    private void RemoveModeUI()
    {
        //RemoveContainerUI("ModeUI");
    }

    public void CreateScoreUI()
    {
        /*
        // 게임 UI 로드하는 부분 
        GameObject scoreUIRes = Resources.Load<GameObject>("Prefab/ScoreUI");
        GameObject scoreUIGo = Instantiate(scoreUIRes, _canvasTrasn, false);
        ScoreUI scoreUIComp = scoreUIGo.GetComponent<ScoreUI>();

        _container.Add("ScoreUI", scoreUIComp);
        */
    }

    public void AddScore()
    {
        /*UIBase strtui;
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

        //scoreUIComp.ChangeScore(20000); */
    }
}
