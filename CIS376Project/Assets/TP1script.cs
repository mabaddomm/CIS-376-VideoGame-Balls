using UnityEngine;

public class TP1Script : MonoBehaviour
{
    public Vector3 destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTag"))
        {
            other.transform.position = destination;
        }
    }
}