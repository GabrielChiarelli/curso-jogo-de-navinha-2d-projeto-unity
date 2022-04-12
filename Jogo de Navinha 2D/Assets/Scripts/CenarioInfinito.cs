using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioInfinito : MonoBehaviour
{
    public float velocidadeDoCenario;

    // Update is called once per frame
    void Update()
    {
        MovimentarCenario();
    }

    private void MovimentarCenario()
    {
        Vector2 deslocamentoDoCenario = new Vector2(Time.time * velocidadeDoCenario, 0f);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamentoDoCenario;
    }
}
