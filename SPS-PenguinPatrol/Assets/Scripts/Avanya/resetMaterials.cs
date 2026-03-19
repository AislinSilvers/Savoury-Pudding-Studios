using UnityEngine;

public class resetMaterials : MonoBehaviour
{
   public Material regularMat;
    public Material newMat;
       void Start()
    {
        GetComponent<MeshRenderer>().material = regularMat;
    }

     void ResetMats()
    {
        GetComponent<MeshRenderer>().material = regularMat;
    }
  
    public void ResetMaterial()
    {
       
            GetComponent<MeshRenderer>().material = newMat;
            Invoke("ResetMats",0.7f);
        }
    }

