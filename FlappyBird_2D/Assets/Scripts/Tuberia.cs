using UnityEngine;

public class Tuberia : MonoBehaviour
{
    public Pajarito scriptPajaro;
    public Transform transformPajaro;
    public bool HaSumadoPunto = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Establecemos la posición inicial de la tubería
        transform.position = new Vector3(transform.position.x,Random.Range(-0.5f,0.75f),transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(scriptPajaro.estaMuerto == false && scriptPajaro.partidaEmpezada == true){
             //Cada frame movemos el suelo hacia la izquierda
            //Para controlar la velocidad se multiplica por el Time.deltaTime de esta forma conseguimos que el movimiento sea independiente de la velocidad de fotogramas
            transform.position = transform.position - new Vector3(0.8f * Time.deltaTime,0,0);
            if(transform.position.x <= -2.5){
                //Si la posición del suelo es menor o igual a -5, lo movemos a la posición 5
                //Para evitar que se posicione en otro lugar, mantenemos la posición en Y y Z
                //0.5 posisicion mas baja
                //0.75 posicion mas alta
                transform.position = new Vector3(2.5f,Random.Range(-0.5f,0.75f),transform.position.z);
                //HaSumadoPunto = false;
            }
        }
        if(transformPajaro.position.x > transform.position.x){
            Debug.Log(transformPajaro.transform.position.x);
            Debug.Log("Pajaro: " + transformPajaro.position.x + "\n Tuberia: " + transform.position.x);
        }
        //Durante cada paso de frame, vamos a verificar si el pajadito ha cruzado la tuberia
        if(transformPajaro.position.x > transform.position.x && HaSumadoPunto == false){
            scriptPajaro.IncrementarPuntuacion();
            HaSumadoPunto = true;
        }
        
    }
}
