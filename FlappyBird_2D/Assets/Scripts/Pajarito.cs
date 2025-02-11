using UnityEngine;
//Requerida para acceder a TextMeshProUGUI
using TMPro;
public class Pajarito : MonoBehaviour
{
    //Declaramos una variable de tipo Rigidbody2D para acceder al componente Rigidbody2D del pájaro
    public Rigidbody2D rigidbodyPajaro;
    public bool estaMuerto = false;
    public bool partidaEmpezada = false;
    //Referencia a otro script
    public ControladorCanvas controladorCanvas;
    public int puntuacion = 0;
    public TextMeshProUGUI textoPuntuacion, textoPuntuacionMuerte;
    public TextMeshProUGUI textoPuntuacionMaxima;
    public GameObject medallaBronce, medallaPlata, medallaOro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Establecemos la gravedad del pájaro a 0 para que se quede fijo
        rigidbodyPajaro.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(estaMuerto == false){
            if(Input.GetMouseButtonDown(0)){
                rigidbodyPajaro.gravityScale = 1;
                partidaEmpezada = true;
                //Si se presiona el botón izquierdo del ratón, el pájaro salta
                //Para ello le aplicamos una fuerza hacia arriba
                //AL tener GRAVEDAD en el Rigidbody2D, el pájaro caerá, y para que suba aplicamos una fuerza hacia arriba afectando la velocidad del rigidbody con un vector de 2 dimensiones (0,3.5f)
                rigidbodyPajaro.linearVelocity = new Vector2(0,2.5f);
                //Rotamos el transform(pajaro) en el eje Z 30 grados
                //transform.rotation = Quaternion.Euler(0,0,30);
                rigidbodyPajaro.SetRotation(30);
            }
        }
        else{
            //Si el pajaro esta muerto y doy clic, reinicio el juego
            //UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }
        //Para evitar errores, convertimos la puntuación a string
        textoPuntuacion.text = puntuacion.ToString();
        if(rigidbodyPajaro.linearVelocity.y < 0){
            //Si la velocidad del pájaro es menor a 0, rotamos el pájaro en el eje Z -45 grados
            //transform.rotation = Quaternion.Euler(0,0,-45);
            //Al ser un gameobject con rigid body, se recomienda usar el metodo SetRotation y no tocar el Transform
            //Ocupamos DeltaTime, porque esta dentro del UPDATE, dependiendo el refresh de cada equipo en FPS
            rigidbodyPajaro.SetRotation(rigidbodyPajaro.rotation - 280 * Time.deltaTime);
            //Limitamos la rotacion min -90 y max 30
            rigidbodyPajaro.SetRotation(Mathf.Clamp(rigidbodyPajaro.rotation, -90, 30));
        }
    }
    
    //Metodo de la clase MOnoBehaviour que se ejecuta cuando el objeto colisiona con otro objeto
    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("SaLV Si estoy chocando");
        if(estaMuerto == false){
            //Si el pájaro colisiona con cualquier objeto, se establece que el pájaro está muerto
            estaMuerto = true;
            rigidbodyPajaro.linearVelocity = new Vector2(0,0);
            //Una vez que el pájaro está muerto, se muestra el menú de muerte con un delay de 1 seg
            controladorCanvas.Invoke("MostrarMenuMuerte", 1f);
            //controladorCanvas.MostrarMenuMuerte();
            textoPuntuacionMuerte.text = puntuacion.ToString();
            GuardarPuntuacionMaxima();
            if(puntuacion > 10){
                medallaOro.SetActive(true);
            }else if(puntuacion > 5){
                medallaPlata.SetActive(true);
            }else if(puntuacion > 1){
                medallaBronce.SetActive(true);
            }
        }
    }

    public void IncrementarPuntuacion(){
        puntuacion++;
        Debug.Log("Puntuación: " + puntuacion);
    }
    public void GuardarPuntuacionMaxima(){
        //Si la puntuación actual es mayor a la puntuación máxima guardada en el PlayerPrefs
        //Si puntuacionmaxima es nula va tomar el valor de 0
        if(puntuacion > PlayerPrefs.GetInt("PuntuacionMaxima",0)){
            //Se guarda la puntuación máxima en el PlayerPrefs
            //PlayerPrefs es una clase que permite guardar datos en la memoria del dispositivo
            PlayerPrefs.SetInt("PuntuacionMaxima", puntuacion);
        }
            textoPuntuacionMaxima.text = PlayerPrefs.GetInt("PuntuacionMaxima").ToString();
        
    }
}
