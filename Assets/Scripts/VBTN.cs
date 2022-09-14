using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class VBTN : MonoBehaviour
{
    public VirtualButtonBehaviour vb;

    public GameObject _terrain, _factory;
    public AudioSource _terrainSound, _factorySound;

    public UnityEvent ButtonPressed;
    public UnityEvent ButtonReleased;

    private void OnEnable()
    {
        vb.RegisterOnButtonPressed(OnButtonPressed);
        vb.RegisterOnButtonReleased(OnButtonReleased);
        Debug.Log("Start");
    }

    private void OnDestroy()
    {
        vb.UnregisterOnButtonPressed(OnButtonPressed);
        vb.UnregisterOnButtonReleased(OnButtonReleased);
        Debug.Log("OnDestroy");
    }

    void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        ButtonPressed?.Invoke();
        //_terrain.SetActive(true);
        Debug.Log("Found");
    }

    void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        ButtonReleased?.Invoke();
        //_terrain.SetActive(false);
        Debug.Log("Lost");
    }
}
