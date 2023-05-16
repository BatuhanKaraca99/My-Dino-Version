using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable] //to see in editor
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1f)] //for editor
        public float spawnChance; //0 >-----< 1
    }

    public SpawnableObject[] objects; //our variable

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value; //random number between 0 and 1

        foreach(var obj in objects) //from our variables
        {
            if (spawnChance < obj.spawnChance) //if random number < our variable's spawn chance
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position; //offset based on spawner's position
                break; //dont spawn again
            }

            spawnChance -= obj.spawnChance; //decrease spawn chance
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}

