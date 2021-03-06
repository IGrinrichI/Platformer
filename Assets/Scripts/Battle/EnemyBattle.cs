﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattle : MonoBehaviour {

    public int maxHitpoints;
    public int currentHitpoints;
    public int maxManapoints;
    public int currentManapoints;
    public CharacterBattle target;
    public Spell[] spells;
    public int currentSpell;
    public List<Effect> effects;
    private SpriteRenderer rend;
    private bool mobil;

    // Use this for initialization
    void Start () {
        currentHitpoints = 100;
        maxHitpoints = currentHitpoints;
        currentManapoints = 10;
        maxManapoints = currentManapoints;
        rend = GetComponent<SpriteRenderer>();
        rend.color = new Vector4(0, 1, 0, 1);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBattle>();
        mobil = true;
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i] = Instantiate(spells[i]);
            for (int j = 0; j < spells[i].effects.Length; j++)
            {
                spells[i].effects[j] = Instantiate(spells[i].effects[j]);
            }
        }
    }
	
    public void IsAttacked(Spell spelled)
    {
        currentHitpoints -= spelled.damage;
        if (effects.Count == 0)
        {
            foreach (Effect effect in spelled.effects)
            {
                effects.Add(Instantiate(effect));
            }
        }
        else
        {
            AddEffects(spelled.effects);
        }

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
                BattleController.SwitchTo("MainScene");
            }
        }
        else
        {
            rend.color = new Vector4(1 - (float)currentHitpoints / maxHitpoints, (float)currentHitpoints / maxHitpoints, 0, 1);
        }
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < target.targets.Length; i++)
        {
            if(target.targets[i].name == name)
            {
                target.currentTarget = i;
                target.pointer.position = transform.position;
                break;
            }
        }
    }

    private void AddEffects(Effect[] spellEffects)
    {
        foreach (Effect effect in spellEffects)
        {
            for (int i = 0; i < effects.Count; i++)
            {
                if (effect.effectName == effects[i].effectName)
                {
                    if (effect.time > effects[i].time)
                    {
                        effects[i] = Instantiate(effect);
                        break;
                    }
                    break;
                }
                if (i == effects.Count - 1)
                {
                    effects.Add(Instantiate(effect));
                }
            }
        }
    }

    public void Turn()
    {
        FeelEffects();
        if (mobil == true)
        {
            target.IsAttacked(spells[Random.Range(0, spells.Length)]);
            Invoke("Next", 1);
        }
        else
        {
            mobil = true;
            Invoke("Next", 1);
        }
    }

    private void Next()
    {
        BattleController.Next();
    }
    //Проверка влияющих эффектов
    private void FeelEffects()
    {
        if (effects.Count != 0)
        {
            foreach (Effect effect in effects)
            {
                if (effects.Count != 0)
                {
                    //Чот вроде свича
                    for (; ; )
                    {
                        if (effect.effectName == "Stun")
                        {
                            mobil = false;
                            effect.time--;
                            break;
                        }
                        else if (effect.effectName == "NonEffect")
                        {
                            break;
                        }
                        Debug.Log("I don't know this effect");
                        break;
                    }
                }
            }
            //Очистка эффектов, чьё время действия кончилось
            for (int i = effects.Count - 1; i > -1; i--)
            {
                if (effects[i].time == 0)
                {
                    Destroy(effects[i]);
                    effects.Remove(effects[i]);
                }
            }
        }
    }
}
