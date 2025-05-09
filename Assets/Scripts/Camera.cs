using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform _camTarget;

    [SerializeField]
    private Transform _camTarget2;

    private Vector3 _offset = new Vector3(-5, 0, 0);

    private Transform _orgTarget;



    public float duration = 0.5f;      // ��鸱 �ð�
    public float magnitude = 0.1f;     // ��鸲�� ũ��
    public float frequency = 25.0f;    // ��鸲�� ���ļ�

    private Vector3 originalPos;
    private float elapsed = 0.0f;
    private bool isShaking = false;

    void Start()
    {
        _orgTarget = _camTarget;
        originalPos = transform.localPosition;
    }
    public void StartShake()
    {
        elapsed = 0.0f;
        isShaking = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            _orgTarget = _camTarget2;
            //ī�޶� Ÿ�� ����ٴϱ�
            transform.LookAt(_camTarget);
            transform.position = Vector3.Lerp(transform.position, _camTarget.position + _offset, Time.deltaTime * 10);

        }
        


        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartShake();
        }

        if (isShaking)
        {
            elapsed += Time.deltaTime;

            float x = Mathf.Sin(elapsed * frequency) * magnitude;
            float y = Mathf.Cos(elapsed * frequency) * magnitude;

            transform.localPosition = originalPos + new Vector3(x, y, 0);

            if (elapsed >= duration)
            {
                isShaking = false;
                transform.localPosition = originalPos;
            }
        }
    }
}
