using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoJogador : MonoBehaviour
{
    public Rigidbody2D oRigidbody2D;
    public GameObject laserDoJogador;
    public Transform localDoDisparoUnico;
    public Transform localDoDisparoDaEsquerda;
    public Transform localDoDisparoDaDireita;
    public float tempoMaximoDosLasersDuplos;
    public float tempoAtualDosLasersDuplos;
    
    public float velocidadeDaNave;

    public bool temLaserDuplo;
    public bool jogadorEstaVivo;

    private Vector2 teclasApertadas;

    // Start is called before the first frame update
    void Start()
    {
        temLaserDuplo = false;
        jogadorEstaVivo = true;

        tempoAtualDosLasersDuplos = tempoMaximoDosLasersDuplos;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarJogador();

        if(jogadorEstaVivo == true)
        {
            AtirarLaser();
        }

        if(temLaserDuplo == true)
        {
            tempoAtualDosLasersDuplos -= Time.deltaTime;

            if(tempoAtualDosLasersDuplos <= 0)
            {
                DesativarLaserDuplo();
            }
        }
    }

    private void MovimentarJogador()
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        oRigidbody2D.velocity = teclasApertadas.normalized * velocidadeDaNave;
    }

    private void AtirarLaser()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(temLaserDuplo == false)
            {
                Instantiate(laserDoJogador, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
            }
            else
            {
                Instantiate(laserDoJogador, localDoDisparoDaEsquerda.position, localDoDisparoDaEsquerda.rotation);
                Instantiate(laserDoJogador, localDoDisparoDaDireita.position, localDoDisparoDaDireita.rotation);
            }

            EfeitosSonoros.instance.somDoLaserDoJogador.Play();
        }
    }

    private void DesativarLaserDuplo()
    {
        temLaserDuplo = false;
        tempoAtualDosLasersDuplos = tempoMaximoDosLasersDuplos;
    }
}
