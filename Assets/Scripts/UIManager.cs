using UnityEngine;
using System.Collections.Generic;
using static Unity.Burst.Intrinsics.X86.Avx;
using System.Xml.Linq;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{

}


// ����, ����,������ ����ϰڴ�. 
// �̸����� ����! 

public class UIManager : MonoSingletone<UIManager>
{
    private Transform _canvasTrasn;

    private Dictionary<string, UIBase> _container =  new Dictionary<string, UIBase>();

    // �����̳ʿ� �����ؼ� �����ϸ� �ȴ�. 

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
        // ModeUI �������� ���ҽ��� �ε��ؼ�, Instantiate�Ѵ�. 
        /*GameObject resGO = Resources.Load<GameObject>("Prefab/StartUI");
        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        StartUI comp = sceanGO.GetComponent<StartUI>();

        _container.Add(typeof(StartUI).ToString(), comp);*/
    }

    public void CreateModeUI()
    {
        /*RemoveContainerUI("StartUI");

        // ���ӸŴ����� ModUI������ְ� �־��µ� 
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
        // ���� UI �ε��ϴ� �κ� 
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
