using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using TMPro;


public class Rotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;
    public TextMeshProUGUI enteredDigit;
    public double ring_position;
    public int number;

    public Rigidbody m_Rigidbody;

    public float time;
    public float timeDelay;

    private InputDevice target;
    private int count;

    private float final;

    private string name;
    //[SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        enteredDigit = gameObject.GetComponent<TextMeshProUGUI>();

        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightController = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightController, devices);

        if (devices.Count > 0)
        {
            target = devices[0];
        }

        count = 1;

        time = 0f;
        timeDelay = 3f;
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        name = m_Rigidbody.name;

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
        //if (name == "R1")
        {
            target.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
            if (primaryButtonValue && count == 1)
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
            else if (!primaryButtonValue && count == 1)
            {
                m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
            target.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
            if (secondaryButtonValue)
            {
                m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                count += 1;
                final = transform.localRotation.eulerAngles.z;
            }
        }

        enteredDigit.text = final.ToString();

        //if (name == "R2")
        //{
        //    target.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        //    if (primaryButtonValue && count == 2)
        //    {
        //        //c += 1;
        //        m_Rigidbody.constraints = RigidbodyConstraints.None;
        //        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        //    }

        //    //if (c == 1)
        //    //{
        //    //  m_Rigidbody.constraints = RigidbodyConstraints.None;
        //    //  m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        //    //}
        //    else if (!primaryButtonValue && count == 2)
        //    {
        //        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        //    }
        //    target.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
        //    if (secondaryButtonValue)
        //    {
        //        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        //        count += 1;
        //    }
        //}



        //time += 1f * Time.deltaTime;
        //if (time <= timeDelay)
        //{
        //  m_Rigidbody.constraints = RigidbodyConstraints.None;
        //m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        // transform.Rotate(0f, 0f, 20f);
        //}
        //else if (time > timeDelay && time < 6f)
        //{
        //   m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        //}
        //else
        //{
        //   time = 0f;
        //}



        //transform.Rotate(rotation * Time.deltaTime);
        //transform.Rotate(0f, 0f, -0.2f);
        //transform.eulerAngles = Vector3(0, 0, 5); 

        //Vector3 leftPosition = InputTracking.GetLocalPosition(XRNode.LeftHand);
        //Quaternion leftRotation = InputTracking.GetLocalRotation(XRNode.LeftHand);
        //transform.rotation = leftRotation;

        //var controllerDevice = (UnityEngine.XR.InputDevice)device;
        //Vector3 position;
        //if (controllerDevice.TryGetFeatureValue(CommonUsages.devicePosition, out position))
        //{
        //  transform.localPosition = position;
        //}
        //Quaternion rotation;
        //if (controllerDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out rotation))
        //{
        //   transform.localRotation = rotation;
        //}

        Debug.Log(ring_position);

        
        ring_position += 0.2;
        if (ring_position >= 360.0) ring_position = ring_position / 360.0;
        

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

        Debug.Log(number);


        // Selected number for a disc
        //selected.text = 
    }
}
