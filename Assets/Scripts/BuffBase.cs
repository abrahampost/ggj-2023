using System;
using UnityEngine;

[Serializable]
public class BuffBase
{
    [Serializable]
    public struct Modifier {
        public string modifierType;
        public int modifierValue;

    }
    public Modifier[] modifiers;
    public string description;
}
