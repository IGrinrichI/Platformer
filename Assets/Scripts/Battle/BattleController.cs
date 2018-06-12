using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour {

    public List<GameObject> persons;
    public int currentPerson;

	void Start () {
        currentPerson = 0;
        persons.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        persons.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
	}
	
    public void Next()
    {
        currentPerson = (currentPerson + 1) % persons.Capacity;
        if (persons[currentPerson].tag == "Player")
        {
            Debug.Log("Now palyer turn.");
            persons[currentPerson].GetComponent<CharacterBattle>().Turn();
        }
        else
        {
            if (persons[currentPerson].activeInHierarchy)
            {
                Debug.Log("Now enemy turn.");
                persons[currentPerson].GetComponent<EnemyBattle>().Turn();
            }
            else
            {
                Next();
            }
        }
    }

    public void SwitchTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
