using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField]
    private Image _hp;

    private int _maxHP = 100;
    private int _currentHP = 100;

    void Start()
    {
        //0 ~ 1������ �ִ� �ּҰ� �������ֽ��ϴ�.
        _hp.fillAmount = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _currentHP -= 20;
            float remainHP = (float)_currentHP / (float)_maxHP;
            _hp.fillAmount = remainHP;
        }
    }
}
