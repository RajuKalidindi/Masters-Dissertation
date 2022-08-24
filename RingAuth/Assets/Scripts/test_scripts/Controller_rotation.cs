using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class Controller_rotation : MonoBehaviour
{
    public Rigidbody m_Rigidbody;

    private int count;

    public TextMeshProUGUI enteredDigit;
    private double ring_position;
    private int number;


    private InputDevice target;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightController = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightController, devices);

        if (devices.Count > 0)
        {
            target = devices[0];
        }

        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition| RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationY;

        count = 1;

        int start_rotation = Random.Range(0, 359);

        //int start_rotation = 0;
        transform.Rotate(0f, 0f, start_rotation);
        //transform.eulerAngles = Vector3(0,0,start_rotation);
        ring_position = start_rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Quaternion rotation;
        //if (target.TryGetFeatureValue(CommonUsages.deviceRotation, out rotation))
        //{
        //    m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        //    m_Rigidbody.transform.rotation = rotation;
        //}
        //Debug.Log(rotation);

        //transform.Rotate(rotation * Time.deltaTime);
        
        target.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue)
        {
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            transform.Rotate(0f, 0f, 0f);
            count = 2;

            if (ring_position >= 0.0 & ring_position <= 35.0) number = 0;
            else if (ring_position >= 36.0 & ring_position <= 71.0) number = 1;
            else if (ring_position >= 72.0 & ring_position <= 107.0) number = 2;
            else if (ring_position >= 108.0 & ring_position <= 143.0) number = 3;
            else if (ring_position >= 144.0 & ring_position <= 179.0) number = 4;
            else if (ring_position >= 180.0 & ring_position <= 215.0) number = 5;
            else if (ring_position >= 216.0 & ring_position <= 251.0) number = 6;
            else if (ring_position >= 252.0 & ring_position <= 287.0) number = 7;
            else if (ring_position >= 288.0 & ring_position <= 323.0) number = 8;
            else if (ring_position >= 324.0 & ring_position <= 359.0) number = 9;

            enteredDigit.text = number.ToString();
        }
        if (count == 1)
        {
            transform.Rotate(0f, 0f, -0.2f);

            ring_position += 0.3;
            if (ring_position >= 360.0) ring_position = ring_position / 360.0;
        }

    }
}
