using UnityEngine;

public class ControladorCanvas : MonoBehaviour
{
    //PAra poder modificar su visibilidad desde el editor de Unity, se declara como publica
    public GameObject menuPrincipal;
    public GameObject Pajadito;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Necesita ser publica, para ser llamada desde el Trigger del Button.
    public void EsconderMenuPrincipal(){
        menuPrincipal.SetActive(false);
        Pajadito.SetActive(true);
    }
}
