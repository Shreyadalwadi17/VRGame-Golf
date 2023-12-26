using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClubFixed : XRGrabInteractable
{
    public Rigidbody rb;
    //private FixedJoint fixedJoint;

    private XRGrabInteractable xRGrabInteractable;
    private XRDirectInteractor xRBaseController;

    void Start()
    {
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
        xRGrabInteractable.selectEntered.AddListener(OnGrab);

        rb = GetComponent<Rigidbody>();
    }

    private void OnGrab(SelectEnterEventArgs arg0)
    {
        Debug.Log(arg0.interactorObject);
        Debug.Log("Bat Grabbed");

        rb.isKinematic = false;

        XRDirectInteractor xRController = arg0.interactorObject.transform.GetComponent<XRDirectInteractor>();


        if (xRController != null )
        {
            Debug.Log("xrController Found");
        FixedJoint fixedJoint = xRController.GetComponent<FixedJoint>();

            if(fixedJoint != null)
            {
                Debug.Log("Fixed Joint Found");
                fixedJoint.connectedBody = rb;
            }
            else
            {
                Debug.Log("Fixed Joint not Found");
            }

        }
        else
        {
            Debug.Log("xrController Not Found");
        }

        //xRBaseController = xRController;

        //fixedJoint = xRBaseController.GetComponent<FixedJoint>();
        //fixedJoint = arg0.interactorObject.transform.GetComponent<FixedJoint>();
        //Invoke(nameof(AttachFixedJoint), 0.1f);
        //AttachFixedJoint();
        //ChangeBatLayers();
    }

    //public void AttachFixedJoint()
    //{
    //    if (fixedJoint != null)
    //    {
    //        Debug.Log("Fixed Joint Found");
    //        fixedJoint.connectedBody = rb;
    //    }
    //    else
    //    {
    //        Debug.Log("No Fixed Joint");
    //    }
    //}

    //public void Triggerhaptics()
    //{
    //    if (xRBaseController != null)
    //    {
    //        Debug.Log("XRController Found");

    //        xRBaseController.SendHapticImpulse(HapticsAmplitude, HapticsDuration);
    //    }
    //    else
    //    {
    //        Debug.Log("XRController Not Found");
    //    }
    //}
}
