using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Abilityes
{
    public List<Ability> abilities;
}

[Serializable]
public struct Ability
{
    public Ability(int type)
    {
        this.type = (AbilityType)type;
    }

    public AbilityType type;

    public int getAbilityType => (int)type;
}

[Serializable]
public enum AbilityType : int
{
    SpawnUnit = 10,
    RemoveUnit = 20,
    BuyUnit = 30,
    SellUnit = 40
}