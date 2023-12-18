using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveModule : MonoBehaviour
{
    private double _velocity = 0.0;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool reversed = false;
    [SerializeField] private bool backwards = false;
    [SerializeField] private float strength = 5f;
    [SerializeField] private float maxRaycastDistance = 4f;

    private Vector3 originalAngles;
    
    public void SetVelocity(double velocity)
    {
        this._velocity = velocity;
    }

    private void Awake()
    {
        originalAngles = transform.localRotation.eulerAngles;
    }

    public void SetAngle(double angle)
    {
        angle = reversed ? -angle : angle;
        angle = backwards ? angle + Mathf.PI : angle;
        angle %= 2 * Mathf.PI;
        
        Vector3 eulerAngles = transform.localRotation.eulerAngles;
        eulerAngles.y = originalAngles.y + Mathf.Rad2Deg * (float)(angle);
        
        // set the angle of the wheel
        transform.localRotation = Quaternion.Euler(eulerAngles);
    }
    
    private void LateUpdate()
    {
        // Apply force if on the ground
        
        
        Debug.Log("Force applied");
        transform.parent.GetComponent<Rigidbody>().AddForceAtPosition(
            strength * (float)_velocity * transform.forward, transform.position, ForceMode.Impulse);
    }
    
    
}
