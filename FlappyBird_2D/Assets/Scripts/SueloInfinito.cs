using UnityEngine;

public class SueliInfinito : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Cada frame movemos el suelo hacia la izquierda
        transform.position = transform.position - new Vector3(0.1f,0,0);
    }
}
