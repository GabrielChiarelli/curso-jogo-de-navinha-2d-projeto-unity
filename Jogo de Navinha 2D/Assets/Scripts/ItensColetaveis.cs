using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensColetaveis : MonoBehaviour
{
    public bool itemDeEscudo;
    public bool itemDeLaserDuplo;
    public bool itemDeVida;

    public int vidaParaDar;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(itemDeEscudo == true)
            {
                other.gameObject.GetComponent<VidaDoJogador>().AtivarEscudo();
            }

            if(itemDeLaserDuplo == true)
            {
                other.gameObject.GetComponent<ControleDoJogador>().temLaserDuplo = false;

                other.gameObject.GetComponent<ControleDoJogador>().tempoAtualDosLasersDuplos = other.gameObject.GetComponent<ControleDoJogador>().tempoMaximoDosLasersDuplos;

                other.gameObject.GetComponent<ControleDoJogador>().temLaserDuplo = true;
            }

            if(itemDeVida == true)
            {
                other.gameObject.GetComponent<VidaDoJogador>().GanharVida(vidaParaDar);
            }

            Destroy(this.gameObject);
        }
    }

}
