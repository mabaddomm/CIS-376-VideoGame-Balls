using UnityEngine;

public class TP2Script : MonoBehaviour
{
    public Vector3 destination;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touch");
        if (other.CompareTag("PlayerTag"))
        {
            Debug.Log("plr touch");
            other.transform.position = destination;
        }
    }
}