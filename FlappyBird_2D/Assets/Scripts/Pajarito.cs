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
    public TextMeshProUGUI textoPuntuacion;
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
            }
        }
        else{
            //Si el pajaro esta muerto y doy clic, reinicio el juego
            //UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }
        //Para evitar errores, convertimos la puntuación a string
        textoPuntuacion.text = puntuacion.ToString();
    }
    
    //Metodo de la clase MOnoBehaviour que se ejecuta cuando el objeto colisiona con otro objeto
    void OnCollisionEnter2D(Collision2D collision){
        if(estaMuerto == false){
            //Si el pájaro colisiona con cualquier objeto, se establece que el pájaro está muerto
            estaMuerto = true;
            rigidbodyPajaro.linearVelocity = new Vector2(0,0);
            //Una vez que el pájaro está muerto, se muestra el menú de muerte con un delay de 1 seg
            controladorCanvas.Invoke("MostrarMenuMuerte", 1f);
            //controladorCanvas.MostrarMenuMuerte();
        }
    }

    public void IncrementarPuntuacion(){
        puntuacion++;
        Debug.Log("Puntuación: " + puntuacion);
    }
}
