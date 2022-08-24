using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using TMPro;
public class R2_rotation : MonoBehaviour
{
    public TextMeshProUGUI enteredDigit;
    public double ring_position;
    public int number;

    public Rigidbody m_Rigidbody;

    private InputDevice target;
    private int count;
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

        count = 1;

        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        enteredDigit = gameObject.GetComponent<TextMeshProUGUI>();

        int start_rotation = Random.Range(0, 359);

        //int start_rotation = 0;
        transform.Rotate(0f, 0f, start_rotation);
        //transform.eulerAngles = Vector3(0,0,start_rotation);
        ring_position = start_rotation;
        number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enteredDigit.text = count.ToString();

        target.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
        if (secondaryButtonValue)
        {
            if(count == 4)
            {
                m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll; 
            }
            count += 1;
        }
        target.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        //if(count == 2)
        //{
           // m_Rigidbody.constraints = RigidbodyConstraints.None;
         //   m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        //}
        if (primaryButtonValue && count == 3)
        {
            //c += 1;
            m_Rigidbody.constraints = RigidbodyConstraints.None;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        }

        //if (c == 1)
        //{
        //  m_Rigidbody.constraints = RigidbodyConstraints.None;
        //  m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        //}
        else if (!primaryButtonValue && count == 3)
        {
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        
    }
}
