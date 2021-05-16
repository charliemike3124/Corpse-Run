using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialResources", menuName = "ScriptableObjects/MaterialResources", order = 1)]
public class MaterialResource : ScriptableObject
{
    [Header("Materials")]
    public List<PhysicMaterial> PhysicMaterials;
    public List<Material> Materials;

}
