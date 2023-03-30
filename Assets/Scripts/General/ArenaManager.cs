using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] private RoundInfo[] unitRounds;
    [SerializeField] private ParticleSystem spawnEffect;
    [SerializeField] private float roundsInterval;
    [SerializeField] private float arenaSize;

    private List<Entity> enemiesInArena;
    private bool hasStartedRound = false;
    private int currentRound = -1;

    public static ArenaManager instance { get => _instance; }
    private static ArenaManager _instance;

    void Awake()
    {
        if (instance == null)
            _instance = this;

        enemiesInArena = new List<Entity>();
        FinishTheRound();
    }

    void Update()
    {
        if (enemiesInArena.Count <= 0 && hasStartedRound)
            FinishTheRound();
    }

    private void FinishTheRound()
    {
        currentRound++;
        hasStartedRound = false;
        StartCoroutine(StartNewRound());
    }

    IEnumerator StartNewRound()
    {
        yield return new WaitForSeconds(roundsInterval);
        hasStartedRound = true;

        unitRounds[currentRound].Spawn(arenaSize);
    }

    public void SpawnArenaEnemy(ActiveEntity enemy, Vector3 pos)
    {
        ActiveEntity enemyObj = Instantiate<ActiveEntity>(enemy, pos, Quaternion.identity);
        FXManager.CreateEffect(spawnEffect, pos);
        enemyObj.transform.parent = transform;

        Subscribe(enemyObj);
        enemyObj.OnDeath += () => Unsubscribe(enemyObj);
    }

    public void Subscribe(Entity entity) => enemiesInArena.Add(entity);

    public void Unsubscribe(Entity entity) => enemiesInArena.Remove(entity);
}

[System.Serializable]
public class RoundInfo
{
    public RoundUnitTypeInfo[] enemiesInfo;

    public void Spawn(float arenaSize)
    {
        foreach (RoundUnitTypeInfo enemyInfo in enemiesInfo)
        {
            enemyInfo.Spawn(arenaSize);
        }
    }
}

[System.Serializable]
public class RoundUnitTypeInfo
{
    public ActiveEntity enemy;
    public int amount;

    public void Spawn(float arenaSize)
    {
        for (int i = 0; i < amount;i++)
        {
            Random.InitState(System.DateTime.UtcNow.Millisecond);
            float xPos = Random.Range(-arenaSize, arenaSize);
            float zPos = Random.Range(-arenaSize, arenaSize);

            ArenaManager.instance.SpawnArenaEnemy(enemy, new Vector3(xPos, -5, zPos));
        }
    }
}

/*[System.Serializable]
public class UnitSpawnInfo
{
    public ActiveEntity enemy;
    public int roundAppearance;
    public int startingAmount;
    public float incrementPerRound;
    private float spawnAmount = 0;

    public void Spawn(float currentRound, float arenaSize)
    {
        if (currentRound < roundAppearance)
            return;

        if (spawnAmount <= 0)
            spawnAmount = startingAmount;

        for (int i = 0; i < Mathf.RoundToInt(spawnAmount); i++)
        {
            Random.InitState(System.DateTime.UtcNow.Millisecond);
            float xPos = Random.Range(-arenaSize, arenaSize);
            float zPos = Random.Range(-arenaSize, arenaSize);

            ArenaManager.instance.SpawnArenaEnemy(enemy, new Vector3(xPos, 10, zPos));
        }
    }
}*/