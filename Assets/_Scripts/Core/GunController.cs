using _Scripts.Utilities;
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
        currentBullet.Movement(gunBulletPoint.forward *  Constants.BULLET_SPEED);
        
        Vector3 dir = Vector3.Dot(gunBulletPoint.forward, Vector3.right) < 0 ? Vector3.back : Vector3.forward;
        
        float angularPoint = Mathf.InverseLerp(0, 10, Mathf.Abs(_rb.angularVelocity.z));
        float amount = Mathf.Lerp(0, Constants.LERP_AMOUNT_Y_AXIS, angularPoint);
        float torque = Constants.TORQUE + amount;

        _rb.AddTorque(dir * torque);
        
        //ADD FORCE TO GUN
        // float assistPoint = Mathf.InverseLerp(0, 10, _rb.position.y);
        // float assistAmount = Mathf.Lerp(30, 0, assistPoint);
        Vector3 forceDir = transform.right* Constants.FORCE_AMOUNT + Vector3.down * 10;
        if (_rb.position.y > 10) forceDir.y = Mathf.Min(0, forceDir.y);
        _rb.AddForce(forceDir);
        

    }
}
