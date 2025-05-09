using UnityEngine;

public class studytransform : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private Vector3 _direct;
    private bool _move = true;
    private float _Speed = 3f;


    void Update()
    {
        //_yAxisAngle += Time.deltaTime * _rotateSpeed;                              // 물체 회전
        //transform.rotation = Quaternion.Euler(new Vector3(0, _yAxisAngle, 0));

        //if(_move)
        //    transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

        //if(transform.position.x > targetPosition.x )
        //    _move = false;


        /*_direct = targetPosition.position - transform.position;
        _direct.Normalize();

        //transform.position += Time.deltaTime * _direct * _Speed;

        var rotateVec = Vector3.Cross(_direct, new Vector3(0,0,-1));
        transform.position += rotateVec * Time.deltaTime * 50; */


        /*transform.LookAt(target); //Look

        float distance = Vector3.Distance(transform.position, target.position);

        if(distance > 1f)
        {
            transform.position += transform.forward * Time.deltaTime * _Speed;

        }*/


        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);
    }
    //에디터에서만 계속 불리는 함수
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
        
    }
}
