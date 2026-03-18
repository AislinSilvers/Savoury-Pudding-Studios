using UnityEngine;

public class movePiano : MonoBehaviour
{

    //DISCLAIMER: THIS IS A COPY OF A SCRIPT FROM THE RECENTLY RENAMED "EXTRA" FOLDER, BUT THE RENAMING OF THE FOLDER 
    //WAS CAUSING ISSUES WITH GITHUB SO I HAVE JUST COPIED THE ENTIRE SCRIPT INSTEAD OF EDITING IT TO INCLUDE
    //THE PIANO ALONGSIDE THE CRYSTALS FROM THE OTHER SCRIPT - AVANYA
    [Header("Crystal Object")]
    public Transform piano;
    // i changed these into objects because i felt it was easier than writing all the values manually lol 
    // - avanya

    //public Vector3 startPosition;
    //public Vector3 endPosition;
    public float animSpeed = 1f;

    public Transform startPos;
    public Transform endPos;


    private bool animating = false;

    void Start()
    {
        piano.localPosition = startPos.transform.position;
    }

    public void RaiseCrystals()
    {
        animating = true;
    }

    void Update()
    {
        if (!animating) return;

        piano.localPosition = Vector3.Lerp(
            piano.localPosition,
            endPos.transform.position,
            animSpeed * Time.deltaTime
        );

        if (Vector3.Distance(piano.localPosition, endPos.transform.position) < 0.01f)
        {
            // crystals.localPosition = endPosition;
            piano.localPosition = endPos.transform.position;
            animating = false;

        }
    }
}