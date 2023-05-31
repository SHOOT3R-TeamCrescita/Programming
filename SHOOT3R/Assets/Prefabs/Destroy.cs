using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            ObjDestroy();
        }
    }

    public void ObjDestroy()
    {
        Destroy(gameObject);
    }
}
