using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpell", menuName = "Spell")]
public class Spell : ScriptableObject {

    public int damage;
    public string spellName;
    public string spellDescription;
    public Effect[] effects;
    
}
