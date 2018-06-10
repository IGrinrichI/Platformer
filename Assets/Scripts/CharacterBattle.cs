using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour {

    public int maxHitpoints;
    public int currentHitpoints;
    public int maxManapoints;
    public int currentManapoints;
    public EnemyBattle[] targets;
    public int currentTarget;
    public Spell[] spells;
    public int currentSpell;
    public List<Effect> effects;
    private SpriteRenderer rend;

    // Use this for initialization
    void Start () {
        currentHitpoints = 100;
        maxHitpoints = currentHitpoints;
        currentManapoints = 10;
        maxManapoints = currentManapoints;
        rend = GetComponent<SpriteRenderer>();
        rend.color = new Vector4(0, 1, 0, 1);
        targets = GameObject.FindObjectsOfType<EnemyBattle>();
    }

    public void Attack()
    {
        if(currentSpell != 0)
        {
            targets[currentTarget].IsAttacked(spells[currentSpell]);
            currentSpell = 0;
        }
        else
        {
            Debug.Log("Choose spell!");
        }
    }

    public void IsAttacked(Spell spelled)
    {
        currentHitpoints -= spelled.damage;
        rend.color = new Vector4(1 - (float)currentHitpoints / maxHitpoints, (float)currentHitpoints / maxHitpoints, 0, 1);
        Debug.Log("Character takes " + spelled.damage + " damage");
        if (currentHitpoints < 1)
        {
            Debug.Log("Game Over!");
        }
    }

    public void SetSpell (string spellName)
    {
        for (int i = 0; i < spells.Length; i++)
        {
            if (spellName == spells[i].spellName)
            {
                currentSpell = i;
            }
        }
    }
}
