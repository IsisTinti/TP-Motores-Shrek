using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public Transform Player;
    public int NumberOfEnemiesToSpawn;
    public float SpawnDelay = 1f;
    public List<Enemy> EnemyPrefabs = new List<Enemy>();
    public SpawnMethod EnemySpawnMethod = SpawnMethod.RoundRobin;

    private NavMeshTriangulation Triangulation;
    private Dictionary<int, ObjectPool> enemyObjectPools = new Dictionary<int, ObjectPool>();

    private void Awake()
    {
        for (int i = 0; i < EnemyPrefabs.Count; i++)
        {
            enemyObjectPools.Add(i, ObjectPool.CreateInstance(EnemyPrefabs[i],NumberOfEnemiesToSpawn));
        }

    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
        Triangulation = NavMesh.CalculateTriangulation();

    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(SpawnDelay);

        int SpawnedEnemies = 0;

        while (SpawnedEnemies < NumberOfEnemiesToSpawn)
        {
            if (EnemySpawnMethod == SpawnMethod.RoundRobin)
            {
                SpawnRoundRobinEnemy(SpawnedEnemies);
            }

            else if (EnemySpawnMethod == SpawnMethod.Random)
            {
              SpawnRandomEnemy();
            }

            SpawnedEnemies++;
            yield return wait;
        }

    }

    private void SpawnRoundRobinEnemy(int SpawnedEnemies)
    {
        int SpawnIndex = SpawnedEnemies % EnemyPrefabs.Count;

        DoSpawnEnemy(SpawnIndex);
    }

    private void SpawnRandomEnemy()
    {   
        DoSpawnEnemy(Random.Range(0, EnemyPrefabs.Count));

    }

    private void DoSpawnEnemy(int SpawnIndex)
    {
        PoolableObject poolableobject = enemyObjectPools[SpawnIndex].GetObject();

        if (poolableobject != null)
        {
            Enemy enemy = poolableobject.GetComponent<Enemy>();
       

            int VertexIndex = Random.Range(0, Triangulation.vertices.Length);

            NavMeshHit Hit;

            if (NavMesh.SamplePosition(Triangulation.vertices[VertexIndex], out Hit, 2f,-1))
            {
                enemy.agent.Warp(Hit.position);
                enemy.agent.enabled = true;
                enemy.movement.Player = Player;
                enemy.movement.StartChasing();
            }

            else
            {
                Debug.LogError($"no se puede poner el agente en el NavMesh. se intento usar: {Triangulation.vertices[VertexIndex]}");
            }
        }

        else
        {
            Debug.LogError($"No se puede buscar al enemigo de { SpawnIndex} desde object pool. esta fuera del objeto?");

        }
    }


    public enum SpawnMethod
    {
        RoundRobin,
        Random 
    }

}
