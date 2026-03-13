using System;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public int score;
    public Vector2Int direction = Vector2Int.right;
    private Vector2Int input;
    public List<Transform> segments = new List<Transform>();
    public Transform segmentPreFab;
    public bool ativo = false;
    public GameStateManager gameState;

    public void Start()
    {
        ativo = true; // remover essa linha depois.

        // Reseta a cobra para o tamanho inicial.
        // Faz isso limpando a lista, adicionando novamente a “cabeça”.       
        segments.Clear();
        segments.Add(transform);
        score = 0;
        direction = Vector2Int.right;
    }

    public void setAtivo(bool estado_player)
    {
        ativo = estado_player;
    }


    private void Update()
    {
        if (!ativo)
            return;

        // permite apenas mover para cima ou para baixo enquanto se desloca no eixo X
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = Vector2Int.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = Vector2Int.down;
            }
        }
        // Só pode mover para a esquerda ou direita se estiver movendo na        
        // direção Y.
        else if (direction.y != 0f)
        {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    direction = Vector2Int.right;
                }
                else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    direction = Vector2Int.left;
                }
            }
        }
    
    


private void FixedUpdate()
    {
        if (!ativo)
            return;
        // Seta cada segmento da cobra para ser o mesmo ao daquele que ele segue. 
        // Isso deve ser feito em ordem reversa para que a posição seja setada para 
        // a posição prévia do segmento, evitando que eles fiquem todos um em cima do outro. 
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        // Move a cobra na direção que ele está apontando. 
        // Arredonda os valores para alinhar ao grid
        int x = Mathf.RoundToInt(transform.position.x) + direction.x;
        int y = Mathf.RoundToInt(transform.position.y) + direction.y;
        transform.position = new Vector2(x, y);
    }
}