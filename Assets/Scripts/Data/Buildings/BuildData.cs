using UnityEngine;

[CreateAssetMenu(fileName = "New Building Data", menuName = "Game Data / Building Data")]
public class BuildData : ScriptableObject
{
    public string buildingName;
    public Mesh mesh;
    public GameObject prefab;
}
