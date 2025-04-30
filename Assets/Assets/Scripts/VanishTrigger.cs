using UnityEngine;

public class VanishTrigger : MonoBehaviour
{
    public GameObject objetoADesactivar1;
    public GameObject objetoADesactivar2;
    public Collider colliderAHabilitar;
    public Material dissolveMaterial; // Material con shader de dissolve
    public string tagDelObjetoQueActiva = "Player";
    public string propiedadShader = "_DissolveAmount";
    public float duracionDissolve = 5f;

    private bool disolviendo = false;
    private float dissolveValor = 0f;

    private Renderer rend1, rend2;
    private Material[] matArray1, matArray2;

    void Start()
    {
        if (objetoADesactivar1 != null)
            rend1 = objetoADesactivar1.GetComponent<Renderer>();
        if (objetoADesactivar2 != null)
            rend2 = objetoADesactivar2.GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagDelObjetoQueActiva) && !disolviendo)
        {
            // Activar collider externo
            if (colliderAHabilitar != null)
                colliderAHabilitar.enabled = true;

            // Aplicar material de dissolve a cada objeto
            if (rend1 != null)
                AplicarDissolveAMateriales(rend1, out matArray1);
            if (rend2 != null)
                AplicarDissolveAMateriales(rend2, out matArray2);

            disolviendo = true;
        }
    }

    void Update()
    {
        if (!disolviendo) return;

        dissolveValor = Mathf.Clamp01(dissolveValor + Time.deltaTime / duracionDissolve);

        if (matArray1 != null)
        {
            foreach (var m in matArray1)
                m.SetFloat(propiedadShader, dissolveValor);
        }

        if (matArray2 != null)
        {
            foreach (var m in matArray2)
                m.SetFloat(propiedadShader, dissolveValor);
        }

        if (dissolveValor >= 1f)
        {
            if (objetoADesactivar1 != null)
                objetoADesactivar1.SetActive(false);
            if (objetoADesactivar2 != null)
                objetoADesactivar2.SetActive(false);

            disolviendo = false;
        }
        Debug.Log("Dissolve: " + dissolveValor);
    }

    void AplicarDissolveAMateriales(Renderer renderer, out Material[] nuevosMateriales)
    {
        Material[] originales = renderer.materials;
        nuevosMateriales = new Material[originales.Length];

        for (int i = 0; i < originales.Length; i++)
        {
            nuevosMateriales[i] = new Material(dissolveMaterial); // instanciar por separado
        }

        renderer.materials = nuevosMateriales;
    }
}
