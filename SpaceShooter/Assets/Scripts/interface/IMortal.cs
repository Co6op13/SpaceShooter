using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMortal 
{
    public int CurrentHP { get; set; }
    public int MaxHP { get; set; }
}
