using System;
using UnityEngine;

public class AbilityButton : BaseButton
{
    [SerializeField] private Ability ability;

    public void SetAction(Action<Ability> action)
    {
        // base.SetAction(action);
        Debug.Log($"Set ability {ability.ToString()} action");

        _button.onClick.AddListener(() =>
        {
            action?.Invoke(ability);
            Debug.Log("USING");
        });
    }
}