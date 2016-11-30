using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionManager : MonoBehaviour
{
    public int NumberOfColliders = -1;
    public List<MeshCollider> colliders = new List<MeshCollider>();
    public bool SpamEnabled = false;

    public void FindColliders()
    {
        colliders = new List<MeshCollider>(FindObjectsOfType<MeshCollider>());
        NumberOfColliders = colliders.Count;
    }

    public void GenerateColliders()
    {
        MeshFilter[] meshes = FindObjectsOfType<MeshFilter>();
        for (int i = 0; i < meshes.Length; i++)
        {
            MeshCollider collider = meshes[i].gameObject.AddComponent<MeshCollider>();
            collider.sharedMesh = meshes[i].sharedMesh;
        }
        FindColliders();
    }

    public void RemoveColliders()
    {
        FindColliders();
        for (int i = 0; i < colliders.Count; i++)
        {
            DestroyImmediate(colliders[i]);
        }
        colliders.Clear();
        NumberOfColliders = 0;
    }
}
