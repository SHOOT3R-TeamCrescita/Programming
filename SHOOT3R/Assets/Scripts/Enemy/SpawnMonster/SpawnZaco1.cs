using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZaco1 : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    GameObject Zaco;
    public float SpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer(SpawnTime));
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnZaco()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);

        GameObject ZacoA = Instantiate(Zaco, transform.position, rotation);
        Zaco1 zac = Zaco.GetComponent<Zaco1>();
        zac.target = target;
        
    }
    private IEnumerator SpawnTimer(float waitTIme)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTIme);
            SpawnZaco();
        }
    }
}
