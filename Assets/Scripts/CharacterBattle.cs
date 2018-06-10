using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private BattleController controller;

    // Use this for initialization
    void Start () {
        currentHitpoints = 100;
        maxHitpoints = currentHitpoints;
        currentManapoints = 10;
        maxManapoints = currentManapoints;
        rend = GetComponent<SpriteRenderer>();
        rend.color = new Vector4(0, 1, 0, 1);
        targets = GameObject.FindObjectsOfType<EnemyBattle>();
        controller = GameObject.FindObjectOfType<BattleController>();
    }

    public void Attack()
    {
        if(currentSpell != 0)
        {
            targets[currentTarget].IsAttacked(spells[currentSpell]);
            currentSpell = 0;
            controller.Invoke("Next", 1);
        }
        else
        {
            Debug.Log("Choose spell!");
        }
        foreach(Button button in GameObject.FindGameObjectWithTag("Spells").GetComponentsInChildren<Button>())
        {
            button.interactable = false;
        }

    }

    public void IsAttacked(Spell spelled)
    {
        currentHitpoints -= spelled.damage;

        if (effects.Capacity == 0)
        {
            effects.AddRange(spelled.effects);
        }
        else
        {
            AddEffects(spelled.effects);
        }

        Debug.Log("Character takes " + spelled.damage + " damage");

        if (currentHitpoints < 1)
        {
            Debug.Log("Game Over!");
            foreach(Button button in GameObject.FindObjectsOfType<Button>())
            {
                if (button.name == "Attack")
                {
                    button.interactable = false;
                    break;
                }
            }
        }
        else
        {
            rend.color = new Vector4(1 - (float)currentHitpoints / maxHitpoints, (float)currentHitpoints / maxHitpoints, 0, 1);
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

    private void AddEffects(Effect[] spellEffects)
    {
        foreach (Effect effect in spellEffects)
        {
            for (int i = 0; i < effects.Capacity; i++)
            {
                if (effect.effectName == effects[i].effectName)
                {
                    if (effect.time > effects[i].time)
                    {
                        effects[i] = effect;
                        break;
                    }
                    break;
                }
                if (i == effects.Capacity - 1)
                {
                    effects.Add(effect);
                }
            }
        }
    }

    public void Turn()
    {
        foreach (Button button in GameObject.FindGameObjectWithTag("Spells").GetComponentsInChildren<Button>())
        {
            button.interactable = true;
        }
    }
}
