
using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public Rigidbody bulletRigidBody;
  

  public void Movement(Vector3 direction)
  {
    bulletRigidBody.velocity = direction;
  }
}
