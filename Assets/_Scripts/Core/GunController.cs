using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Bullet bullets;
    public Transform gunBulletPoint;
    private Bullet currentBullet;
    private Rigidbody _rb;
    private float _bulletSpeed = 60;
    private float _torque = 120;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    { 
        currentBullet = Instantiate(bullets, gunBulletPoint.position, gunBulletPoint.rotation); 
        currentBullet.Movement(gunBulletPoint.forward *  _bulletSpeed);
        
        var dir = Vector3.Dot(gunBulletPoint.forward, Vector3.right) < 0 ? Vector3.back : Vector3.forward;
        
        float angularPoint = Mathf.InverseLerp(0, 10, Mathf.Abs(_rb.angularVelocity.z));
        float amount = Mathf.Lerp(0, 150, angularPoint);
        float torque = _torque + amount;

        _rb.AddTorque(dir * torque);
    }
}
