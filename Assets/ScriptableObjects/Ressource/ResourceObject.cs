using UnityEngine;

[CreateAssetMenu(fileName = "NewResourceName", menuName = "ScriptableObjects/ResourceObject", order = 0)]
public class ResourceObject : ScriptableObject
{
    public ResourceType Type;
    public string Name;
    public Sprite Sprite;
    public GameObject Prefab;
}