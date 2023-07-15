using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    /**/                              ///Enable for custom rotation
    [SerializeField] private float adjustSpeed = 5f;
    [Range(3,50)]
    [SerializeField] private float adjustRotationSpeed = 10f;
    /**/

    private Vector3 _initalOffset;
    [SerializeField] private Vector3 offset; //Good default values: -0.3f, 3.43f, -8.4f;
    [SerializeField] private Vector3 _maximumZoomIn;
    [SerializeField] private Vector3 _maximumZoomOut;

    private void Awake()
    {
        _initalOffset = offset;
    }
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerMovement.player.transform;
    }

    // Update is called once per frame
    void FixedUpdate() //If I have this in Update or LateUpdate, the camera movement is jittery
    {
        CameraPositionChange();
        CameraRotationChange();
        //RotateCamera();
        //transform.LookAt(target);
    }

    private void Update()
    {
        ChangeCameraOffset();
    }

    void CameraPositionChange()
    {
        // Calculate the desired camera position
        Vector3 targetPosition = target.position + target.forward * offset.z;
        targetPosition.y = target.position.y + offset.y;

        // Perform a raycast to check for obstacles between the camera and the player
        RaycastHit hitInfo;
        if (Physics.Linecast(target.position, targetPosition, out hitInfo))
        {
            // Adjust the camera position if an obstacle is detected
            targetPosition = hitInfo.point;
        }

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Slerp(transform.position, targetPosition, Time.deltaTime * adjustSpeed); //Tried using Slerp
    }

    void RotateCamera()
    {
        transform.LookAt(target);
    }

    void CameraRotationChange()
    {
        // Make the camera look at the player
        Vector3 dir = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(dir);

        Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, adjustRotationSpeed * Time.deltaTime); //Tried using Slerp

        transform.rotation = newRotation;
    }

    void ChangeCameraOffset() //Use the scrollwheel to change the camera offset or press 
    {
        offset.y -= Input.GetAxis("Mouse ScrollWheel") * 3.6f;
        offset.z += Input.GetAxis("Mouse ScrollWheel") * 6f;

        offset.y = Mathf.Clamp(offset.y, _maximumZoomIn.y, _maximumZoomOut.y);
        offset.z = Mathf.Clamp(offset.z, _maximumZoomOut.z, _maximumZoomIn.z);

        if (Input.GetMouseButtonDown(2))
        {
            offset = _initalOffset;
        }
    }

}
