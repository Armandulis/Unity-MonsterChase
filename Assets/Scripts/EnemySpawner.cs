using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPosition, rightPostion;


    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( SpawnMonsters() );
    }

    IEnumerator SpawnMonsters()
    {
        while( true )
        {
            yield return new WaitForSeconds( Random.Range( 1, 5 ) );

            randomIndex = Random.Range( 0, monsterReference.Length );
            randomSide = Random.Range( 0, 2 );

            spawnedMonster = Instantiate( monsterReference[ randomIndex ] );

            // Left side
            if( randomSide == 0)
            {
                spawnedMonster.transform.position = leftPosition.position;
                spawnedMonster.GetComponent<Enemy>().speed = Random.Range( 4, 10);
            }
            else
            {
                // Right Side
                spawnedMonster.transform.position = rightPostion.position;
                spawnedMonster.GetComponent<Enemy>().speed = -Random.Range( 4, 10);
                spawnedMonster.transform.localScale = new Vector3( -1f, 1f,0f );
            }
        } // while loop
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
