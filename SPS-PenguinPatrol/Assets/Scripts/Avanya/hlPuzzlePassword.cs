using UnityEngine;

public class hlPuzzlePassword : MonoBehaviour
{

    public Material regularMat;
    public Material newMat;

    public AudioClip crystalSound;

    public 
       void Start()
    {
        GetComponent<SpriteRenderer>().material = regularMat;
    }

     void ResetMats()
    {
        GetComponent<SpriteRenderer>().material = regularMat;
    }
  
    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "drop"){
            GetComponent<SpriteRenderer>().material = newMat;
            soundFXManager.instance.playSoundFXClip(crystalSound, transform, 0.1f);
            Invoke("ResetMats",0.7f);
        }
    }
}
