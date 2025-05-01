using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscenaTrigger : MonoBehaviour
{
    public string nombreDeEscena; // Nombre exacto de la escena que querés cargar
    public string tagDelObjetoQueActiva = "Player"; // El tag del objeto que debe activar el cambio
    public ObjetoInteractuable winCoindition;

    void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag(tagDelObjetoQueActiva))
        if (winCoindition._isInVitrina)
        {
            SceneManager.LoadScene(nombreDeEscena);
        }
    }
}
