using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cargarScene : MonoBehaviour
{
    public string nombreEscena;

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(nombreEscena);

        }
    }
    public void Cargar()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
