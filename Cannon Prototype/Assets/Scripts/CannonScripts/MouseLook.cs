using UnityEngine;
using System.Collections;


/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation


/// To make an FPS style character:
/// - Create a capsule.
/// - Add a rigid body to the capsule
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSWalker script to the capsule


/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public Vector2 sensitivity = new Vector2(15f,15f);
    public Vector2 smoothing = new Vector2(3,3);
    public Vector2 targetDirection;
    public bool lockCursor;

    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    public float rotationX = 0F;
    public float rotationY = 0F;
    Quaternion originalRotation;

    Vector2 _mouseAbsolute;
    Vector2 _smoothMouse;     


    void Update()
    {
        //Delete unless essential in practice
        //Screen.lockCursor=lockCursor;

        //this allows us to clamp based on a target value
        var targetOrientation = Quaternion.Euler(targetDirection);



        if (axes == RotationAxes.MouseXAndY)
        {
            // Read the raw mouse input axis
            var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            //Scale raw input my sensitivity and smoothing
            mouseDelta.x = mouseDelta.x*sensitivity.x*smoothing.x;
            mouseDelta.y = -mouseDelta.y*sensitivity.y*smoothing.y;

            //Interpolate mouse movement to smooth
            _smoothMouse.x = Mathf.Lerp(_smoothMouse.x,mouseDelta.x,1f/smoothing.x);
            _smoothMouse.y = Mathf.Lerp(_smoothMouse.y,mouseDelta.y,1f/smoothing.y);

            _mouseAbsolute += _smoothMouse;

            _mouseAbsolute.x = ClampAngle(_mouseAbsolute.x, minimumX, maximumX);
            transform.localRotation= Quaternion.AngleAxis(-_mouseAbsolute.y, targetOrientation* Vector3.right);
                
            _mouseAbsolute.y = ClampAngle(_mouseAbsolute.y, minimumY, maximumY);

            transform.localRotation *= targetOrientation;

            transform.localRotation *= Quaternion.AngleAxis(_mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));



        }
        /*
        else if (axes == RotationAxes.MouseX)
        {
            var mouseDeltaX = Input.GetAxisRaw("Mouse X");
            rotationX += Input.GetAxis("Mouse X") * sensitivity.x;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        else
        {
            var mouseDeltaY = Input.GetAxisRaw("Mouse Y");
            rotationY += Input.GetAxis("Mouse Y") * sensitivity.y;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }*/
    }
    void Start()
    {
        //set target direction to the starting camera orientation
        targetDirection = transform.localRotation.eulerAngles;

        //Hide the cursor and force it to stay within the game's bounds
        Cursor.lockState = CursorLockMode.Locked;
        // Make the rigid body not change rotation
        //if (GetComponent<Rigidbody>())
        //GetComponent<Rigidbody>().freezeRotation = true;
        //originalRotation = transform.localRotation;
        //originalRotation = Quaternion.Euler(transform.localEulerAngles.x,transform.localEulerAngles.y,0);
        originalRotation = Quaternion.Euler(0, 0, 0);
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}