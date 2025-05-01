using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particucles : MonoBehaviour
{
    public Material material;
    public ParticleSystem energyBurst;

    private float charge = 0f;
    private bool charged = false;

    void Update()
    {
        if (!charged)
        {
            charge += Time.deltaTime;
            charge = Mathf.Clamp01(charge);

            material.SetFloat("_ChargeProgress", charge);

            if (charge >= 1f)
            {
                charged = true;
                energyBurst.Play(); // Lanza las partículas
                StartCoroutine(ResetCharge());
            }
        }
    }
    IEnumerator ResetCharge()
    {
        yield return new WaitForSeconds(1f); // Espera antes de recargar
        charge = 0f;
        charged = false;
    }
}
