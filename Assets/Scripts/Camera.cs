using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform _camTarget;

    [SerializeField]
    private Transform _camTarget2;

    private Vector3 _offset = new Vector3(-5, 0, 0);

    private Transform _orgTarget;


    void Start()
    {
        _orgTarget = _camTarget;

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            _orgTarget = _camTarget2;
            //카메라가 타겟 따라다니기
            transform.LookAt(_camTarget);
            transform.position = Vector3.Lerp(transform.position, _camTarget.position + _offset, Time.deltaTime * 10);

        }
        
    }
}
