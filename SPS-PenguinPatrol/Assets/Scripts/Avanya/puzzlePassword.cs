using UnityEngine;

public class puzzlePassword : MonoBehaviour
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
  
    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "drop"){
            GetComponent<MeshRenderer>().material = newMat;
            Invoke("ResetMats",0.7f);
        }
    }
}
