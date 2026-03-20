using UnityEngine;

public class JogoGameState: GameBaseState
{
    public override void enterState(GameStateManager gameState)  {
        Debug.Log("Entramos no modo jogo");      
        gameState.ativarElementosJogo(true);
        gameState.player.GetComponent<Snake>().resetState();
    }
    public override void updateState(GameStateManager gameState)  {
        if (Input.GetKeyDown(KeyCode.Space))  {
            gameState.switchState(gameState.telaCreditosState);
        }
    }
    public override void leaveState(GameStateManager gameState)  {
        Debug.Log("Saindo do modo jogo");
        gameState.ativarElementosJogo(false);
    }
}
