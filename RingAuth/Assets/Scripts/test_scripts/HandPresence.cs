using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private InputDevice targetDevice;
    public InputDeviceCharacteristics controller;
    public GameObject handPrefab;
    private GameObject handModel;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controller, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if(devices.Count > 0) 
        {
            targetDevice = devices[0];
            handModel = Instantiate(handPrefab, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        handModel.SetActive(true);
    }
}
