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
    private bool mobil;
    public Transform pointer;

    // Use this for initialization
    void Start () {
        currentHitpoints = 100;
        maxHitpoints = currentHitpoints;
        currentManapoints = 10;
        maxManapoints = currentManapoints;
        rend = GetComponent<SpriteRenderer>();
        rend.color = new Vector4(0, 1, 0, 1);
        targets = GameObject.FindObjectsOfType<EnemyBattle>();
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
    //Каст спелла в цель (Enemy)
    public void Attack()
    {
        if(currentSpell != 0)
        {
            targets[currentTarget].IsAttacked(spells[currentSpell]);
            currentSpell = 0;
            Invoke("Next", 1);

            foreach (Button button in GameObject.FindGameObjectWithTag("Spells").GetComponentsInChildren<Button>())
            {
                button.interactable = false;
            }
            GameObject.Find("Attack").GetComponent<Button>().interactable = false;
        }
        else
        {
            Debug.Log("Choose spell!");
        }
    }
    //Что происходит, когда тебя атакуют каким-то спеллом
    public void IsAttacked(Spell spelled)
    {
        currentHitpoints -= spelled.damage;

        if (effects.Count == 0)
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
    //Выбор спелла
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
    //Добавление эффектов от спелла
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
    //Ход
    public void Turn()
    {
        FeelEffects();
        if(mobil == true)
        {
            foreach (Button button in GameObject.FindGameObjectWithTag("Spells").GetComponentsInChildren<Button>())
            {
                button.interactable = true;
            }
            GameObject.Find("Attack").GetComponent<Button>().interactable = true;
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
