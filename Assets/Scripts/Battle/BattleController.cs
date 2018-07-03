using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour {

    static List<GameObject> persons = new List<GameObject>();
    static int currentPerson = 0;
    public GameObject p;
    static Transform point;

    private void Start () {
        point = p.GetComponent<Transform>();
        if (persons.Count != 0)
        {
            currentPerson = 0;
            foreach (GameObject person in persons)
            {
                Destroy(person.gameObject);
            }
            persons.RemoveRange(0, persons.Count);
        }

        persons.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        persons.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        point.position = persons[0].transform.position + Vector3.up * 2;
	}
	
    public static void Next()
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
        point.position = persons[currentPerson].transform.position + Vector3.up * 2;
    }

    public static void SwitchTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
