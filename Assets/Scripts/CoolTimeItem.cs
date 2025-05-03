using UnityEngine;
using UnityEngine.UI;

public class CoolTime : MonoBehaviour
{
    [SerializeField]
    private Image _collTimeImg;

    private float _maxCoolTime = 2.0f;
    private float _currentCoolTime = 0;

    private bool _running;

    void Start()
    {
        _collTimeImg.fillAmount = 1;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            _running = true;
        }
        
        if(_running)
        {
            _currentCoolTime += Time.deltaTime;

            float percent = 1 - (_currentCoolTime / _maxCoolTime);
            _collTimeImg.fillAmount = percent;

            Debug.Log("현재 누적시간 : " + _currentCoolTime);

            if(_currentCoolTime >= _maxCoolTime)
            {
                _running = false;
                _collTimeImg.fillAmount = percent;
                _currentCoolTime = 0;
            }
        }
    }
}
