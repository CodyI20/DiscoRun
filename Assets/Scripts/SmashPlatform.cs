using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashPlatform : MonoBehaviour
{
    [SerializeField] private float _initialSpeed = 10f;
    private float _smashSpeed;
    [Range(3.4f, 45)]
    [SerializeField] private float speedInterpolator;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _smashSpeed = _initialSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InterpolateSpeed();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(0,_smashSpeed*Time.fixedDeltaTime, 0));
    }

    void InterpolateSpeed()
    {
        _smashSpeed *= 1.02f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            _smashSpeed = _initialSpeed;
            _smashSpeed *= -1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            _smashSpeed = _initialSpeed;
            _smashSpeed *= -1;
        }
    }
}
