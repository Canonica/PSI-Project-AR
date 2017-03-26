using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VFXManager : MonoBehaviour {

    public static VFXManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        FillList();
    }

    public List<GameObject> listOfVFX;
    public List<string> listOfVFXNames;

    public List<GameObject> listOfCurrentVFX;


    void FillList()
    {
        Object[] allVFX = Resources.LoadAll("VFX/", typeof(GameObject));
        foreach(Object parObject in allVFX)
        {
            listOfVFX.Add((GameObject)parObject);
            listOfVFXNames.Add(parObject.name);
        }
    }


    /// <summary>
    /// Gets VFX from the resource list, Context is required for context specific fxs
    /// </summary>
    /// <param name="parString">Get it from the VFXs class</param>
    /// <param name="context"> use VfxContext, optional for generic vfxs</param>
    /// <returns></returns>
    public GameObject GetVFX(string parString)
    {
        string nameToFind = parString;
        nameToFind = "VFX_" + parString;

        GameObject VFX = listOfVFX.Find(x => x.name == nameToFind);

        if (VFX == null)
        {
            Debug.Log("String sent to getVFX " + parString);
            Debug.Log("Resources/VFX/" + nameToFind + " does not exist");
            return null;
        }
        else
        {
            return VFX;
        }
    }

    public void PlayVFX(GameObject VFX, Transform parTransform)
    {
        Instantiate(VFX, parTransform.position, Quaternion.identity);
    }
}
