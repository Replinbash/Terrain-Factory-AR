using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ScaleSettings : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum ObjectType { Scaled, Rotated, Reset };

    [Header("References")]
    public Transform[] targetObjects;

    [Header("Settings")]
    public ObjectType objectType;
    public float speed;
    public bool increase;
    public bool decrease;

    // script settings
    private bool _pointerDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        _pointerDown = true;
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pointerDown = false;
        Debug.Log("OnPointerUp");
    }

    private void Update()
    {
        switch (objectType)
        {
            case ObjectType.Scaled:
                if (_pointerDown && increase)                
                    ScaleUp();                

                else if (_pointerDown && decrease)                
                    ScaleDown();                

                else                
                    return;               
                break;

            case ObjectType.Rotated:
                if (_pointerDown && increase)                
                    Rotate(Vector3.up);                

                else if (_pointerDown && decrease)                
					Rotate(Vector3.down);				

                else                
                    return;                
                break;

            case ObjectType.Reset:
                if (_pointerDown)                
                    ResetGame();
                
                break;
        }        
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ScaleUp()
    {
        foreach (var obj in targetObjects)
        {
            obj.localScale += gameObject.transform.localScale * (Time.deltaTime * speed);
        }
    }

    public void ScaleDown()
    {
        Vector3 targetScale = new Vector3(0, 0, 0);

        foreach (var obj in targetObjects)
        {
            obj.localScale -= gameObject.transform.localScale * (Time.deltaTime * speed);

            if (obj.localScale == targetScale)
            {
                _pointerDown = false; // bozuk þuan.
            }

        }
    }

    public void Rotate(Vector3 direction)
    {        
        foreach (var obj in targetObjects)
        {
            obj.transform.Rotate(direction * speed * Time.deltaTime);
        }            
    }    
}

