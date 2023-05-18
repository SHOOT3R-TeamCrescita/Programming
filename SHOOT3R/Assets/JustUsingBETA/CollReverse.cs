using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollReverse : MonoBehaviour
{
    public MeshCollider meshCollider;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!gameObject.activeInHierarchy) return;

        if (!meshCollider) meshCollider = GetComponent<MeshCollider>();

        var mesh = meshCollider.sharedMesh;

        // Reverse the triangles
        mesh.triangles = mesh.triangles.Reverse().ToArray();

        // also invert the normals
        mesh.normals = mesh.normals.Select(n => -n).ToArray();
        Debug.Log("�۵�!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}




