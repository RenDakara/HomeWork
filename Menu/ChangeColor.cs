using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    private Button _button;
    private Color _targetColot;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ColorChange);
    }

    private void ColorChange()
    {
        ColorBlock colorBlock = _button.colors;
        colorBlock.selectedColor = Color.red;
        _button.colors = colorBlock;
    }
}
