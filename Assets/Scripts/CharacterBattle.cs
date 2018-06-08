using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour {

    public int hitpoints;
    public int manapoints;
    public int[] basicDamage;
    public EnemyBattle[] targets;
    public int currentTarget;

    // Use this for initialization
    void Start () {
        basicDamage = new int[] { 1, 5 };
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Attack()
    {
        targets[currentTarget].IsAttack(Random.Range(basicDamage[0], basicDamage[1]));
    }
}
