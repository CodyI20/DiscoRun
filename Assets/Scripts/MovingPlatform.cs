using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 10f;
    private float speed;
    [SerializeField] private float rayMaxDistance = 10f;

    [Range(3.4f,45)]
    [SerializeField] private float speedInterpolator;
    Rigidbody rb;
    bool hasHitRaycastZone = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        speed = _maxSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.right*speed*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasHitRaycastZone && Physics.Raycast(transform.position, Vector3.down, rayMaxDistance, LayerMask.GetMask("PlatformRayCheck"))) //Might get stuck due to interpolation
        {
            hasHitRaycastZone=true;
            _maxSpeed *= -1;
        }
        if (hasHitRaycastZone && !Physics.Raycast(transform.position, Vector3.down, rayMaxDistance, LayerMask.GetMask("PlatformRayCheck")))
        {
            hasHitRaycastZone = false;
        }
        if(speed != _maxSpeed)
        {
            speed = Mathf.Lerp(speed, _maxSpeed, speedInterpolator * Time.deltaTime);
        }
        Debug.DrawRay(transform.position, Vector3.down, Color.magenta);
    }
}
