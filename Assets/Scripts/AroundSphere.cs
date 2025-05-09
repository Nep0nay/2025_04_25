using UnityEngine;

public class AroundSphere : MonoBehaviour
{
    private float _Speed = 100f;

    [SerializeField]
    private Transform _Cubetf;

    private Vector3 _axis = new Vector3(0, 1, 0);

    void Update()
    {
        _axis = _axis.normalized;

        transform.RotateAround(_Cubetf.position, _axis, Time.deltaTime * _Speed); //°øÀü
    }
}
