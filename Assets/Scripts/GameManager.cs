using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxNumberofMonsters = 3;
    public Transform[] spawners;
    public GameObject monsterPrefab;


    private bool isPlaying = false;
    private int numberOfMonsters;

    // SINGLETON
    private static GameManager _Instance;
    public static GameManager Instance { get => _Instance; }

    private void Awake()
    {
        // Singleton feature
        if (_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartGame", 5);
    }

    void StartGame()
    {
        isPlaying = true;
        StartCoroutine(monsterSpawner());
    }
    
    IEnumerator monsterSpawner()
    {
        while (isPlaying)
        {
            if(numberOfMonsters <= maxNumberofMonsters)
            {
                Instantiate(monsterPrefab, spawners[Random.Range(0, spawners.Length)].position, Quaternion.identity);
                numberOfMonsters++;
            }
            yield return new WaitForSeconds(3);
        }
        
    }

    public void MonsterDied()
    {
        if (numberOfMonsters > 0)
        {
            numberOfMonsters--;
        }
    }


}
