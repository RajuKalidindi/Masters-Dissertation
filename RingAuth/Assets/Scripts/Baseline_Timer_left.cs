using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class Baseline_Timer_left : MonoBehaviour
{
    public TextMeshProUGUI time;
    private InputDevice target;
    private float start_time;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
