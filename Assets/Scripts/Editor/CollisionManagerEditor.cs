using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CollisionManager))]
public class CollisionManagerEditor : Editor
{
    public void OnEnable()
    {
        CollisionManager myTarget = (CollisionManager)target;
        myTarget.FindColliders();
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CollisionManager myTarget = (CollisionManager)target;

        GUILayout.TextArea("Collision Manager pozwala Ci na wygenerowanie colliderów na scenie. " +
                           "Dla każdego obiektu zawierającego Mesh dodany zostanie MeshCollider.");

        if (GUILayout.Button("Dodaj collidery"))
        {
            myTarget.GenerateColliders();
        }
        if (GUILayout.Button("Usuń collidery"))
        {
            myTarget.RemoveColliders();
        }
        GUILayout.Label("Liczba colliderów na scenie:");
        GUILayout.Label(myTarget.NumberOfColliders.ToString());
        myTarget.SpamEnabled = GUILayout.Toggle(myTarget.SpamEnabled, "włącz spam");
        if (myTarget.SpamEnabled)
        {
            GUILayout.TextArea("spam spam spam spam spam spam " +
                               "spam spam spam spam spam spam " +
                               "spam spam spam spam spam spam " +
                               "spam spam spam spam spam spam " +
                               "spam spam spam spam spam spam " + 
                               "spam spam spam spam spam spam " +
                               "spam spam spam spam spam spam " +
                               "spam spam spam spam spam spam " +
                               "spam spam spam spam spam spam " +
                               "spam spam spam spam spam spam ");             
        }
    }

    public void OnSceneGUI()
    {
        CollisionManager myTarget = (CollisionManager)target;
        for(int i = 0; i < myTarget.colliders.Count; i++)
        {
            Handles.DrawDottedLine(myTarget.transform.position, myTarget.colliders[i].transform.position, 15);
        }
    }
}