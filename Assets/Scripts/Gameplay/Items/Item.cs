using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public UnityAction<PlayerInteractor> myAction;
    public List<ActionName> lst_Actions;
    
    [Header("Outline")]
    [SerializeField] Renderer rdr;
    public Material outlineMaterial;
    private Material[] originalMaterials;

    public void Awake()
    {
        myAction += Interaction;

        originalMaterials = rdr.materials;//recup la liste de material du rdr sans le outline

        //AddOutline(outlineMaterial);
    }

    public void RemoveOutline()
    {
        // Enlève le matériau d'outline
        rdr.materials = originalMaterials;
    }
    public void AddOutline(Material outlineMat)
    {

        Material[] materialsWithOutline = new Material[originalMaterials.Length + 1]; // nouvelle liste de mat + 1 vide
        originalMaterials.CopyTo(materialsWithOutline, 0);//met le mat originals en index 0
        materialsWithOutline[originalMaterials.Length] = outlineMat;
        rdr.materials = materialsWithOutline;
    }

    public void OnDestroy()
    {
        myAction = null;
    }    


    [Serializable]
    public class ActionName
    {
        public Item item = null;
        public bool global;
        public string name;
    }


    public virtual string SetActionDebug(bool b, PlayerInteractor player)
    {
        if(this != player.handObject)
        {
            if (player.pRole.currentRole == PlayerRole.AllRoles.Priest)
            {
                player.outlineMat.color = Color.blue;
            }
            else if (player.pRole.currentRole == PlayerRole.AllRoles.Demon)
            {
                player.outlineMat.color = Color.red;
            }
            AddOutline(player.outlineMat);

        }

        foreach (var v in lst_Actions)
        {
            if (v.global)
                return v.name;
            if(v.item == player.handObject)
            {
                return v.name;
            }
        }

        return null;

    }

    public virtual void Interaction(PlayerInteractor player)
    {

    }
}
