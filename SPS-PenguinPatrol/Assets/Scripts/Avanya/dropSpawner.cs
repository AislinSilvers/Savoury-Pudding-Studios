using UnityEngine;

public class dropSpawner : MonoBehaviour
{
    [SerializeField] public int notesPlayed = 0;
    public bool patternDone;

    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;

    public Transform drop;

    void Start()
    {
        patternDone = false;
        //Invoke("SpawnDrop1",2f);
    }

    void Update()
    {
        if (patternDone == false)
        {
          Invoke("SpawnDrop1",0);  
        }
    }
    void SpawnDrop1()
    {
        // notesPlayed++;
        patternDone = true;
        Drop1();
        Invoke("SpawnDrop3",1.3f);
    }
    void SpawnDrop2()
    {
        Drop2();
        // notesPlayed++;
        Invoke("SpawnDrop4",1.3f);
    }
void SpawnDrop3()
    {
        Drop3();
        // notesPlayed++;
        Invoke("SpawnDrop2",1.3f);
    }
    void SpawnDrop4()
    {
        Drop4();
        // notesPlayed++;
        Invoke("SpawnDrop5",1.3f);
    }
void SpawnDrop5()
    {
        Drop5();
        // notesPlayed++;
        //patternDone == true;
        Invoke("AllSpawn",2f);
    } 

    void Drop1()
    {
         Transform dropWater = Instantiate(drop, spawn1.position, spawn1.rotation);
    }
     void Drop2()
    {
        Transform dropWater = Instantiate(drop, spawn2.position, spawn2.rotation);
    }
     void Drop3()
    {
        Transform dropWater = Instantiate(drop, spawn3.position, spawn3.rotation);
    }
     void Drop4()
    {
        Transform dropWater = Instantiate(drop, spawn4.position, spawn4.rotation);
    }
     void Drop5()
    {
        Transform dropWater = Instantiate(drop, spawn5.position, spawn5.rotation);
    }

    void AllSpawn()
    {
        Invoke("Drop1",0);
        Invoke("Drop2",0);
        Invoke("Drop3",0);
        Invoke("Drop4",0);
        Invoke("Drop5",0);
        Invoke("SetDoneFalse",2f);  
         
    }   

    void SetDoneFalse()
    {
        patternDone = false;
    }
}
