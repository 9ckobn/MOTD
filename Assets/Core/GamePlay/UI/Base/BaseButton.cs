using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BaseButton : MonoBehaviour
{
    protected Button _button;

    public void Awake()
    {
        _button = GetComponent<Button>();
    }

    public virtual void SetAction(Action action)
    {
        _button.onClick.AddListener(()=>action?.Invoke());
    }
}
