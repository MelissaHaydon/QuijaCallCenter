using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.ObjectModel;

public class EmployeeStat {

    private bool isDirty = true;
    public float baseValue;
    public float lastBaseValue;

    private readonly List<StatModifier> statModifiers;
    public ReadOnlyCollection<StatModifier> StatModifiers;

    public EmployeeStat (float newBaseValue)
    {
        baseValue = newBaseValue;
        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    public float Value
    {
        get
        {
            if (isDirty || lastBaseValue != baseValue)
            {
                lastBaseValue = baseValue;
                baseValue = CalculateFinalValue();
                isDirty = false;
            }
            return baseValue;
        }
    }

    public void AddModifier(StatModifier mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);
    }

    private int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.statOrder < b.statOrder)
            return -1;
        else if (a.statOrder > b.statOrder)
            return 1;
        return 0;

    }

    public bool RemoveModifier(StatModifier mod)
    {
        if (statModifiers.Remove(mod))
        {
            isDirty = true;
            return true;
        }
        return false;
    }

    public bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;

        for (int i = statModifiers.Count - 1; i >= 0; i++)
        {
            if(statModifiers[i].statSource == source)
            {
                isDirty = true;
                didRemove = true;
                statModifiers.RemoveAt(i);
            }
        }
        return didRemove;
    }

    private float CalculateFinalValue()
    {
        float finalValue = baseValue;
        float sumPercentAdd = 0;

        for(int i = 0; i < statModifiers.Count; i++)
        {
            StatModifier mod = statModifiers[i];

            if(mod.statType == StatModType.PercentMult)
            {
                finalValue *= 1 + mod.value;
            }
            else if(mod.statType == StatModType.Flat)
            {
                finalValue += mod.value;
            }
            else if(mod.statType == StatModType.PercentAdd)
            {
                sumPercentAdd += mod.value;

                if(i+1 >= statModifiers.Count || statModifiers[i+1].statType != StatModType.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
        }
        return (float)Math.Round(finalValue, 4);
    }

}
