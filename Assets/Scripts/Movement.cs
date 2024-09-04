 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    Rigidbody _rb;
    float _speed;
    float _forceJump;
    Transform _transform;

    public Movement(Transform transform, Rigidbody rb, float speed, float forceJump)
    {
        _transform = transform;
        _rb = rb;
        _forceJump = forceJump;
        _speed = speed;
    }

    public void Move(float v, float h)
    {
        var dir = _transform.forward * v;
        dir += _transform.right * h;

        _transform.position += dir * _speed * Time.deltaTime;
    }

    public void Jump()
    {
        _rb.AddForce(Vector3.up * _forceJump, ForceMode.Impulse);
    }

    public void SpeedUp(float add)
    {
        _speed += add;
    }

    public void ForceJumpUp(float add)
    {
        _forceJump += add;
    }

    public void ArtificialOnCollisionEnter(Collision collision)
    {

    }
}
