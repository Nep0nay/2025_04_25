using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    [SerializeField]
    private Slider _hpslider;

    private float _sliderTime = 1f;
    private float _acctime = 0f;

    private bool _running;


    void Start()
    {
        //_hpslider.value = _hpslider.maxValue = _sliderTime;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _running = true;
        }

        if (_running == true) 
        {
            _acctime += Time.deltaTime;

            _hpslider.value = 0 + (_acctime / _sliderTime);
            _acctime = _hpslider.value;

            if (_acctime >= _sliderTime)
            {
                _running = false;
                _acctime = 0;
            }
        }
    }
}
