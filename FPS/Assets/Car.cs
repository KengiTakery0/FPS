using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] GameObject frontAxelObject;
    [SerializeField] GameObject rearAxelObject;



    [SerializeField] float motorPoswer = 500;
    [SerializeField] float steerPower = 20;

    [SerializeField] GameObject centerofMass;

    Rigidbody rb;

    WheelCollider[] frontAxel;
    WheelCollider[] rearAxel;
    WheelCollider[] wheels;
    WheelCollider[] wheelsOb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerofMass.transform.localPosition;

        frontAxel = GetAxel(frontAxelObject);
        rearAxel = GetAxel(rearAxelObject);

        wheels = frontAxel.Concat(rearAxel).ToArray();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        foreach (var Wheels in wheels)
        {
            Wheels.motorTorque = Input.GetAxis("Vertical") * ((motorPoswer * 5) / 4);
        }
        foreach (var frontwheel in frontAxel)
        {
            frontwheel.steerAngle = Input.GetAxis("Horizontal") * steerPower;
        }

        WheelBehavier(wheels);
    }

    void WheelBehavier(WheelCollider[] wheels)
    {
        Vector3 pos;
        Quaternion rot;

        foreach (var wheel in wheels)
        {
            wheel.GetWorldPose(out pos, out rot);
            wheel.gameObject.transform.rotation = rot;
        }
        // wheels.GetComponentInChildren<Transform>().position = pos;

    }

    WheelCollider[] GetAxel(GameObject axelObject)
    {
        return axelObject.GetComponentsInChildren<WheelCollider>();
    }
}
