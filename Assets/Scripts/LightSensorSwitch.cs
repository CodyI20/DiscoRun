using UnityEngine;

public class LightSensorSwitch : MonoBehaviour
{
    private Transform _target;
    private Light _light;
    private float timeItSwitchedLights = 0.0f;
    [SerializeField] private float lightSwitchDelay;
    [SerializeField] private float lightSwitchDistance;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _target = PlayerMovement.player.transform;
    }

    void LightSwitch()
    {
        if (Vector3.Distance(_target.position, transform.position) <= lightSwitchDistance)
        {
            timeItSwitchedLights = Time.timeSinceLevelLoad;
        }
        _light.enabled = Time.timeSinceLevelLoad <= timeItSwitchedLights + lightSwitchDelay;
    }

    // Update is called once per frame
    void Update()
    {
        LightSwitch();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, lightSwitchDistance);
    }
}
