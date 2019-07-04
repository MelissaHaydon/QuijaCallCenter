using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier {
   
    public readonly float value;
    public readonly StatModType statType;
    public readonly int statOrder;
    public readonly object statSource;

    public StatModifier(float newValue, StatModType type, int order, object source)
    {
        value = newValue;
        statType = type;
        statOrder = order;
        statSource = source;

    }

    public StatModifier (float value, StatModType type) : this(value, type, (int)type, null) { }

    public StatModifier(float value, StatModType type, int order) : this(value, type, order, null) { }

    public StatModifier(float value, StatModType type, object source) : this(value, type, (int)type, source) { }
}

public enum StatModType
{
    Flat = 100,
    PercentAdd = 200,
    PercentMult = 300,
}
