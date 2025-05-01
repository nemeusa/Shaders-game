using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnergyCharge : MonoBehaviour
{
    public ParticleSystem energyBurst;
    private float charge;
    private bool isCharging;
    private bool hasFired;
    private Renderer rend;
    public ObjetoInteractuable interactuable;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = new Material(rend.material);
        charge = 0;
    }

    void Update()
    {
        if (interactuable._isInVitrina)
        {
            isCharging = true;
            //hasFired = false;
      // opcional: reiniciar carga cada vez que salte
        }

        if (isCharging)
        {
            charge += Time.deltaTime * 0.5f;
            charge = Mathf.Clamp01(charge);

            rend.material.SetFloat("_chargeProgres", charge);
            Debug.Log("Cargando: " + charge.ToString("F2"));

            if (charge >= 1f && !hasFired)
            {
                energyBurst.Play();
                Debug.Log("¡Partículas lanzadas!");
                hasFired = true;
                StartCoroutine(WinScreen());
            }
        }
    }

    IEnumerator WinScreen()
    {
        Debug.Log("Esperando 2 segundos...");
        yield return new WaitForSeconds(3f); // Espera 2 segundos
        Debug.Log("¡Objeto activado!");
        SceneManager.LoadScene("Win");
    }
}
