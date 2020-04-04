using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;
	int numEnemiesRemaining;

	private void Start()
	{
		/**numEnemiesRemaining = 10;
		for(int i = 0; i < numEnemiesRemaining; i++)
		{
			_enemy = Instantiate(enemyPrefab) as GameObject;
			float xPos = Random.Range(-10, 10);
			float zPos = Random.Range(-10, 10);
			_enemy.transform.position = new Vector3(xPos, 0, zPos);
			float angle = Random.Range(0, 360);
			_enemy.transform.Rotate(0, angle, 0);
			_enemy.GetComponent<WanderingAI>().SetAlive(true);
		}**/
	}

	void Update() {
		
	}
}
