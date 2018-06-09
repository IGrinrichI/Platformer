using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour {

    public int maxHitpoints;
    public int currentHitpoints;
    public int maxManapoints;
    public int currentManapoints;
    public CharacterBattle target;
    public Spell[] spells;
    public int currentSpell;
    public Effect[] effects;
    private SpriteRenderer rend;

    // Use this for initialization
    void Start () {
        currentHitpoints = 100;
        maxHitpoints = currentHitpoints;
        currentManapoints = 10;
        maxManapoints = currentManapoints;
        rend = GetComponent<SpriteRenderer>();
        rend.color = new Vector4(0, 1, 0, 1);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBattle>();
	}
	
    public void IsAttacked(Spell spelled)
    {
        currentHitpoints -= spelled.damage;
        rend.color = new Vector4(1 - (float)currentHitpoints / maxHitpoints, (float)currentHitpoints / maxHitpoints, 0, 1);
        Debug.Log("Enemy takes " + spelled.damage + " damage");
        if (currentHitpoints < 1)
        {
            gameObject.SetActive(false);
            int thisTarget = target.currentTarget;
            for (int i = 0; i < target.targets.Length; i++)
            {
                if (target.targets[i].isActiveAndEnabled)
                {
                    target.currentTarget = i;
                    break;
                }
            }
            if (target.currentTarget == thisTarget)
            {
                Debug.Log("You Win!");
            }
        }
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < target.targets.Length; i++)
        {
            if(target.targets[i].name == name)
            {
                target.currentTarget = i;
                break;
            }
        }
    }
}
