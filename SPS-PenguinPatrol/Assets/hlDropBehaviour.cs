using UnityEngine;

public class hlDropBehaviour : MonoBehaviour
{
        void Awake()
    {
        Invoke("Delete",0.1f);
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
