
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour   {
    GameBaseState currentState;
    // instancias de cada um dos estados do jogo
    public AberturaGameState telaInicialState = new AberturaGameState();
    public CreditosGameState telaCreditosState = new CreditosGameState();
    public JogoGameState jogoState = new JogoGameState();


    public GameObject player;
    public GameObject food;

    public GameObject parede1;
    public GameObject parede2;
    public GameObject parede3;

    public GameObject parede4;
void Start()    {
        // seta o estado inicial
        currentState = telaInicialState;
        // inicia o estado.
        currentState.enterState(this);

    }

    // Update is called once per frame
    void Update()    {
        currentState.updateState(this);

    }
    
public void switchState(GameBaseState state)    {
      // sai do estado anterior
      currentState.leaveState(this);

      // muda o estado atual
      currentState = state;

      // entra no novo estado
      currentState.enterState(this);
  }

  public void ativarElementosJogo(bool interruptor)
    {
        player.GetComponent<SpriteRenderer>().enabled = interruptor;
        player.GetComponent<Snake>().setAtivo(interruptor);
        food.GetComponent<SpriteRenderer>().enabled = interruptor;
        
        parede1.GetComponent<SpriteRenderer>().enabled = interruptor;
        parede2.GetComponent<SpriteRenderer>().enabled = interruptor;
        parede3.GetComponent<SpriteRenderer>().enabled = interruptor;
        parede4.GetComponent<SpriteRenderer>().enabled = interruptor;
        

    }

}



