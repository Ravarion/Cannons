using UnityEngine;
using System.Collections;

public class CannonAttribute : MonoBehaviour {

	virtual public void LeftStickMovement(float x, float y)
    {
        Vector3 movementDirection = new Vector3(transform.forward.x, 0, transform.forward.z) * y + new Vector3(transform.right.x, 0, transform.right.z) * x;
        GetComponent<Rigidbody>().AddForce(movementDirection * 0.1f, ForceMode.Impulse);
    }
    virtual public void RightStickMovement(float x, float y)
    {
        //Not used yet.  Currently using MouseLook script
    }

    virtual public void ADown()
    {

    }
    virtual public void AUp()
    {

    }
    virtual public void AHold()
    {
        
    }

    virtual public void BDown()
    {

    }
    virtual public void BUp()
    {

    }
    virtual public void BHold()
    {

    }

    virtual public void XDown()
    {

    }
    virtual public void XUp()
    {

    }
    virtual public void XHold()
    {

    }

    virtual public void YDown()
    {

    }
    virtual public void YUp()
    {

    }
    virtual public void YHold()
    {

    }

    virtual public void LeftBumperDown()
    {

    }
    virtual public void LeftBumperUp()
    {

    }
    virtual public void LeftBumperHold()
    {

    }

    virtual public void RightBumperDown()
    {

    }
    virtual public void RightBumperUp()
    {

    }
    virtual public void RightBumperHold()
    {

    }

    virtual public void LeftTriggerDown()
    {

    }
    virtual public void LeftTriggerUp()
    {

    }
    virtual public void LeftTriggerHold()
    {

    }

    virtual public void RightTriggerDown()
    {

    }
    virtual public void RightTriggerUp()
    {

    }
    virtual public void RightTriggerHold()
    {

    }

    virtual public void StartDown()
    {

    }
    virtual public void StartUp()
    {

    }
    virtual public void StartHold()
    {

    }

    virtual public void SelectDown()
    {

    }
    virtual public void SelectUp()
    {

    }
    virtual public void SelectHold()
    {

    }
}
