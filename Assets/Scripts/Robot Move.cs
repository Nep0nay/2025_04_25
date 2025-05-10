using Gpm.Common.ThirdParty.MessagePack.Resolvers;
using Unity.VisualScripting;
using UnityEngine;

public class RobotMove : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private AudioSource _audioPlay;

    private float _Speed = 10f;
    private float _rotateSpeed = 10f;
    private bool _isMoving = false;
    private bool _isPlaying = false;

    void Start()
    {
        _isMoving = false;
    }

    public void OnFootstep()
    {
        Debug.Log("OnFootstep");
    }

    public void OnEndEvent()
    {
        Debug.Log("OnEndEvent");
        //_isPlaying = false;

    }

    

    void Update()
    {
         var aniState = _animator.GetCurrentAnimatorStateInfo(0);

        if(aniState.normalizedTime >= 1)
        {
            _isPlaying = false;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * _Speed;
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            _isMoving = true;
            _animator.Play("Walk");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * _Speed;
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            _isMoving = true;
            _animator.Play("Walk");

        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * _Speed;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            _isMoving = true;
            _animator.Play("Walk");

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * _Speed;
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            _isMoving = true;
            _animator.Play("Walk");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.Play("Attack");
            _isPlaying = true;
        }

        

        if (_isMoving == false && _isPlaying == false)
        {
            _animator.Play("Idle");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter : " + other.gameObject.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnTriggerEnter : " + collision.gameObject.name);

    }
}
