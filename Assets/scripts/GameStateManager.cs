
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour   {
    GameBaseState currentState;
    // instancias de cada um dos estados do jogo
    public AberturaGameState telaInicialState = new AberturaGameState();
    public CreditosGameState telaCreditosState = new CreditosGameState();
    public JogoGameState jogoState = new JogoGameState();
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

}



