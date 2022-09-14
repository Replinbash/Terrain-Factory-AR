using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
    [SerializeField] private GameObject _settingsPanel;

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 100f);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Deer") || hit.transform.name == "Deer")
                {
                    _settingsPanel.SetActive(false);

                    for (int i = 0; i < _panels.Length; i++)
                    {
                        _panels[0].SetActive(true);
                        
                    }
                }
            }
        }
#endif
#if UNITY_ANDROID

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 100f);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Deer") || hit.transform.name == "Deer")
                {
                    _settingsPanel.SetActive(false);

                    for (int i = 0; i < _panels.Length; i++)
                    {
                        _panels[0].SetActive(true);
                    }
                }
            }
        }
#endif
    }
}