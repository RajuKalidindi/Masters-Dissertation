using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class Ring_handler_left : MonoBehaviour
{
    public Rigidbody R1;
    public Rigidbody R2;
    public Rigidbody R3;
    public Rigidbody R4;

    private bool R1_rotated;
    private bool R2_rotated;
    private bool R3_rotated;
    private bool R4_rotated;

    private bool R1_isrotating;
    private bool R2_isrotating;
    private bool R3_isrotating;
    private bool R4_isrotating;

    private InputDevice target;
    public TextMeshProUGUI time;
    private float start_time;
    // Start is called before the first frame update
    void Start()
    {
        R1 = gameObject.GetComponent<Rigidbody>();
        R2 = gameObject.GetComponent<Rigidbody>();
        R3 = gameObject.GetComponent<Rigidbody>();
        R4 = gameObject.GetComponent<Rigidbody>();

        R1_isrotating = true;
        R2_isrotating = false;
        R3_isrotating = false;
        R4_isrotating = false;

        R1_rotated = false;
        R2_rotated = false;
        R3_rotated = false;
        R4_rotated = false;

        R1.constraints = RigidbodyConstraints.FreezeAll;
        R2.constraints = RigidbodyConstraints.FreezeAll;
        R3.constraints = RigidbodyConstraints.FreezeAll;
        R4.constraints = RigidbodyConstraints.FreezeAll;

        int start_rotation_1 = Random.Range(0, 359);
        transform.Rotate(0f, 0f, start_rotation_1);

        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftController = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftController, devices);

        if (devices.Count > 0)
        {
            target = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        R1.constraints = RigidbodyConstraints.FreezeAll;
        R2.constraints = RigidbodyConstraints.FreezeAll;
        R3.constraints = RigidbodyConstraints.FreezeAll;
        R4.constraints = RigidbodyConstraints.FreezeAll;
        target.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButtonValue);
        if (triggerButtonValue)
        {
            start_time = Time.time;
        }
        target.TryGetFeatureValue(CommonUsages.gripButton, out bool gripButtonValue);
        if (gripButtonValue)
        {
            time.text = (Time.time - start_time).ToString();
        }
        if (R1_isrotating)
        {
            target.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
            if (primaryButtonValue)
            {
                R1.constraints = RigidbodyConstraints.None;
                R1.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

            }
            else if (!primaryButtonValue)
            {
                R1.constraints = RigidbodyConstraints.FreezeAll;
            }
            target.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
            if (secondaryButtonValue)
            {
                R1_isrotating = false;
                R1_rotated = true;
                R1.constraints = RigidbodyConstraints.FreezeAll;
                R2_isrotating = true;
            }
        }

        else if (R2_isrotating)
        {
            target.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
            if (primaryButtonValue)
            {
                R2.constraints = RigidbodyConstraints.None;
                R2.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            }
            else if (!primaryButtonValue)
            {
                R2.constraints = RigidbodyConstraints.FreezeAll;
            }
            target.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
            if (secondaryButtonValue)
            {
                R2_isrotating = false;
                R2_rotated = true;
                R2.constraints = RigidbodyConstraints.FreezeAll;
                R3_isrotating = true;
            }
        }

        else if (R3_isrotating)
        {
            target.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
            if (primaryButtonValue)
            {
                R3.constraints = RigidbodyConstraints.None;
                R3.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            }
            else if (!primaryButtonValue)
            {
                R3.constraints = RigidbodyConstraints.FreezeAll;
            }
            target.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
            if (secondaryButtonValue)
            {
                R3_isrotating = false;
                R3_rotated = true;
                R3.constraints = RigidbodyConstraints.FreezeAll;
                R4_isrotating = true;
            }
        }

        else if (R4_isrotating)
        {
            target.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
            if (primaryButtonValue)
            {
                R4.constraints = RigidbodyConstraints.None;
                R4.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            }
            else if (!primaryButtonValue)
            {
                R4.constraints = RigidbodyConstraints.FreezeAll;
            }
            target.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
            if (secondaryButtonValue)
            {
                R4_isrotating = false;
                R4_rotated = true;
                R4.constraints = RigidbodyConstraints.FreezeAll;
            }
        }

    }
}
