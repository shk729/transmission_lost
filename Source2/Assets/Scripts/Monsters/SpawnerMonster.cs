using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMonster : MonoBehaviour {

	[SerializeField]
	private GameObject[] monstersArray;
	private List<GameObject> monstersList = new List<GameObject>();

	public float monsterSpawnDelay =2f;
	private bool spawningProcess = true;


	public void ActivateSpawner() {
		spawningProcess = false;
	}

	void Start()
	{
		MonstersInitialization ();

	}

	void MonstersInitialization ()
	{
		for (int i = 0; i < monstersArray.Length; i++)
		{
			GameObject obj = Instantiate(monstersArray[i], transform.position, Quaternion.identity) as GameObject;
            monstersList.Add(obj);
			monstersList[i].SetActive(false);
		}
	}

	void FixedUpdate()
	{
		if (!spawningProcess)
			MonstersSpawn ();
	}

	void MonstersSpawn()
	{	
		spawningProcess = true;
		StartCoroutine (NextMonsterDelay (0, monsterSpawnDelay));
	} 


	IEnumerator NextMonsterDelay(int i,float delay)
	{
		if (i< monstersList.Count) {
			monstersList[i].gameObject.transform.position = transform.position;
			monstersList[i].SetActive(true);
			yield return new WaitForSeconds(delay);
			i++;
			//StartCoroutine (NextMonsterDelay (i, monsterSpawnDelay));
		}
	}

}
