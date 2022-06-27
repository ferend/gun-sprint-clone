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

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    { 
        currentBullet = Instantiate(bullets, gunBulletPoint.position, gunBulletPoint.rotation); 
        currentBullet.Movement(gunBulletPoint.forward *  40);

    }

    private void Update()
    {
        var dir = Vector3.Dot(gunBulletPoint.forward, Vector3.right) < 0 ? Vector3.back : Vector3.forward;
        _rb.AddTorque(dir * 10);
    }
}
