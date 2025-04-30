using UnityEngine;

public class ObjetoInteractuable : MonoBehaviour, IInteractable
{
    public GameObject objetoParaActivar; // Objeto hijo del jugador que se va a activar
    public MeshRenderer meshParaOcultar; // El mesh que se apaga al interactuar

    public void Interact()
    {
        Debug.Log($"{name} fue interactuado.");

        if (meshParaOcultar != null)
            meshParaOcultar.enabled = false;

        if (objetoParaActivar != null)
            objetoParaActivar.SetActive(true);
    }

    public void Highlight(bool highlight)
    {
        if (meshParaOcultar != null)
        {
            meshParaOcultar.material.color = highlight ? Color.yellow : Color.white;
        }
    }
}
