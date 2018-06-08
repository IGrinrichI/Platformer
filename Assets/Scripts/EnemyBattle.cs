using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour {

    public int currentHitpoints;
    public int fullHitpoints;
    public int currentManapoints;
    public int fullManapoints;
    public int[] basicDamage;
    public CharacterBattle target;
    public int numberInArray;
    public SpriteRenderer renderer;

    // Use this for initialization
    void Start () {
        currentHitpoints = 100;
        fullHitpoints = currentHitpoints;
        currentManapoints = 10;
        fullManapoints = currentManapoints;
        basicDamage = new int[] { 2, 5};
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Vector4(0, 1, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IsAttack(int hit)
    {
        currentHitpoints -= hit;
        renderer.color = new Vector4(1 - (float)currentHitpoints / fullHitpoints, (float)currentHitpoints / fullHitpoints, 0, 1);
        Debug.Log("Enemy" + (numberInArray + 1) + " takes " + hit + " damage");
        if (currentHitpoints < 1)
        {
            gameObject.SetActive(false);
            for (int i = 0; i < target.targets.Length; i++)
            {
                if (target.targets[i].isActiveAndEnabled)
                {
                    target.currentTarget = i;
                    break;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        target.currentTarget = numberInArray;
    }
}
