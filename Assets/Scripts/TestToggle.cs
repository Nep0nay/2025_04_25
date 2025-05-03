using UnityEngine;
using UnityEngine.UI;

public class TestToggle : MonoBehaviour
{
    [SerializeField]
    private Toggle _toggle;
    void Start()
    {
        _toggle.onValueChanged.AddListener(OnToggleCallback);
    }

    private void OnToggleCallback(bool ison)
    {
        Debug.Log("토글의 상태" + ison);

    }

    void Update()
    {
        
    }
}
