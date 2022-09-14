using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFactory : MonoBehaviour
{
    private int _showFactory = 0;
    public int _ShowFactory
    {
        get { return _showFactory; }
        set { _showFactory = Mathf.Clamp(value, 0, 2); }
    }

    public Button _factoryButton;
    public Button _terrainButton;

    private void Start() => _ShowFactory = 0;
    public void FoundTarget()
    {
        _ShowFactory += 1;
        Debug.Log("Hedef Bulundu: " + _ShowFactory);

        if (_ShowFactory == 2)
        {
            _factoryButton.onClick.Invoke();
        }
    }
    public void LostTarget()
    {
        _ShowFactory -= 1;
        Debug.Log("Hedef Bulundu: " + _ShowFactory);

        if (_ShowFactory == 0)
        {
            _terrainButton.onClick.Invoke();
        }
    }
}
