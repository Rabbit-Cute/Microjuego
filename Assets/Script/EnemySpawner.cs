using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRatePerMinute = 30f;   // meteo que genera cada min
    public float spawnRateIncrement = 1f;    // Aumentar numero de meteo por min
    public float xLimit = 40f;                // Radio de X
    public float yLimit = 24f;                // Radio de Y
    public float spawnOffset = 3f;           // offset del X y Y

    private float spawnNext = 0;             // 下次生成的时间

    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60f / spawnRatePerMinute;
            spawnRatePerMinute += spawnRateIncrement;
            SpawnMeteor();
        }
    }

    void SpawnMeteor()
    {
        int side = Random.Range(0, 4);       // 0=up 1=down 2=left 3=right
        Vector3 spawnPos = Vector3.zero;
        Vector3 targetPos = Vector3.zero;

        switch (side)
        {
            case 0:
                spawnPos  = new Vector3(Random.Range(-xLimit, xLimit),  yLimit + spawnOffset, 0);
                targetPos = new Vector3(Random.Range(-xLimit, xLimit), -yLimit, 0);
                break;
            case 1:
                spawnPos  = new Vector3(Random.Range(-xLimit, xLimit), -yLimit - spawnOffset, 0);
                targetPos = new Vector3(Random.Range(-xLimit, xLimit),  yLimit, 0);
                break;
            case 2:
                spawnPos  = new Vector3(-xLimit - spawnOffset, Random.Range(-yLimit, yLimit), 0);
                targetPos = new Vector3( xLimit, Random.Range(-yLimit, yLimit), 0);
                break;
            case 3:
                spawnPos  = new Vector3( xLimit + spawnOffset, Random.Range(-yLimit, yLimit), 0);
                targetPos = new Vector3(-xLimit, Random.Range(-yLimit, yLimit), 0);
                break;
        }

        Vector3 dir = (targetPos - spawnPos).normalized;

        GameObject meteor = MeteorPool.Instance.Get(MeteorSize.Large);
        meteor.GetComponent<Meteor>().Activate(spawnPos, dir, MeteorSize.Large);
    }
}