using UnityEngine;

public class SueloInfinito : MonoBehaviour
{
    public Transform transformDelOtroSuelo;
    public Pajarito scriptPajaro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Validad si el pajarito está muerto
        //Debug.Log("Esta Muerto: "+ scriptPajaro.estaMuerto);
        //Debug.Log("Partida Empezada: "+ scriptPajaro.partidaEmpezada);
        if(scriptPajaro.estaMuerto == false && scriptPajaro.partidaEmpezada == true){
           //Cada frame movemos el suelo hacia la izquierda
            //Para controlar la velocidad se multiplica por el Time.deltaTime de esta forma conseguimos que el movimiento sea independiente de la velocidad de fotogramas
            transform.position = transform.position - new Vector3(0.8f * Time.deltaTime,0,0);
            if(transform.position.x <= -5){
                //Si la posición del suelo es menor o igual a -5, lo movemos a la posición 5
                //Para evitar que se posicione en otro lugar, mantenemos la posición en Y y Z
                transform.position = new Vector3(transformDelOtroSuelo.position.x + 5f,transform.position.y,transform.position.z);
            }

            //NO es posible modicar el valor de transform.position.x directamente 
        }else{
            //Si el pájaro está muerto, el suelo se detiene
            transform.position = transform.position;
        }

        
    }
}
