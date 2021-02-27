using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnBlock : MonoBehaviour
{

    public List<GameObject> bloques;
    public float spawnTime;
    public Vector2 offsetX;
    private float counter;

    void Start()
    {
        counter = spawnTime;
    }

     void Update()
    {
        counter -= Time.deltaTime;
        if(counter <= 0)
        {
            counter = spawnTime;
            int random = Random.Range(0, bloques.Count);
            Instantiate(bloques[random], calculatePosition(), calculateRotation());
        }
    }

    Vector2 calculatePosition()
    {
        int random = (int)Random.Range(offsetX.x, offsetX.y);
        Vector2 pos = new Vector2(transform.position.x + random, transform.position.y);

        return pos;
    }

    Quaternion calculateRotation()
    {
        int randomRot = (int)Random.Range(1, 4);
        float rotZ = transform.rotation.eulerAngles.z + (90 * randomRot);
        Quaternion rot = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotZ));

        return rot;
    }
}
