using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

public class Enemy
{
    Game1 game;
    public Vector2 posicaoEnemy;
    int velEnemy;

    public Enemy(Game1 game, Vector2 posicaoInicial)
	{
        this.game = game;
        posicaoEnemy = posicaoInicial;
        velEnemy = 2;

        // Preencher a matriz de colisao
        PreencherMatriz();





    }
    public void Move()
    {

        EsvaziarMatriz();

        posicaoEnemy.X = posicaoEnemy.X + velEnemy;

        if (posicaoEnemy.X == 561 || posicaoEnemy.X == 325)
            velEnemy = velEnemy * -1;
        PreencherMatriz();


    }
    public void PreencherMatriz()
    {
        game.MatrizColisao[(int)posicaoEnemy.X, (int)posicaoEnemy.Y + 4] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X, (int)posicaoEnemy.Y + 5] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X, (int)posicaoEnemy.Y + 6] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X, (int)posicaoEnemy.Y + 7] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X, (int)posicaoEnemy.Y + 8] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 1, (int)posicaoEnemy.Y + 8] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 1, (int)posicaoEnemy.Y + 9] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 1, (int)posicaoEnemy.Y + 10] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 2, (int)posicaoEnemy.Y + 10] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 2, (int)posicaoEnemy.Y + 11] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 3, (int)posicaoEnemy.Y + 11] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 4, (int)posicaoEnemy.Y + 11] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 4, (int)posicaoEnemy.Y + 12] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 5, (int)posicaoEnemy.Y + 12] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 6, (int)posicaoEnemy.Y + 12] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 7, (int)posicaoEnemy.Y + 12] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 8, (int)posicaoEnemy.Y + 12] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 8, (int)posicaoEnemy.Y + 11] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 9, (int)posicaoEnemy.Y + 11] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 10, (int)posicaoEnemy.Y + 11] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 10, (int)posicaoEnemy.Y + 10] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 11, (int)posicaoEnemy.Y + 10] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 11, (int)posicaoEnemy.Y + 9] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 11, (int)posicaoEnemy.Y + 8] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 12, (int)posicaoEnemy.Y + 8] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 12, (int)posicaoEnemy.Y + 7] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 12, (int)posicaoEnemy.Y + 6] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 12, (int)posicaoEnemy.Y + 5] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 12, (int)posicaoEnemy.Y + 4] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 11, (int)posicaoEnemy.Y + 4] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 11, (int)posicaoEnemy.Y + 3] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 11, (int)posicaoEnemy.Y + 2] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 10, (int)posicaoEnemy.Y + 2] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 10, (int)posicaoEnemy.Y + 1] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 9, (int)posicaoEnemy.Y + 1] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 8, (int)posicaoEnemy.Y + 1] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 7, (int)posicaoEnemy.Y] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 6, (int)posicaoEnemy.Y] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 5, (int)posicaoEnemy.Y] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 4, (int)posicaoEnemy.Y] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 4, (int)posicaoEnemy.Y + 1] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 3, (int)posicaoEnemy.Y + 1] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 2, (int)posicaoEnemy.Y + 1] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 2, (int)posicaoEnemy.Y + 2] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 1, (int)posicaoEnemy.Y + 2] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 1, (int)posicaoEnemy.Y + 3] = -1;
        game.MatrizColisao[(int)posicaoEnemy.X + 1, (int)posicaoEnemy.Y + 4] = -1;
    }

    public void EsvaziarMatriz()
    {
        game.MatrizColisao[(int)posicaoEnemy.X, (int)posicaoEnemy.Y + 4] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X, (int)posicaoEnemy.Y + 5] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X, (int)posicaoEnemy.Y + 6] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X, (int)posicaoEnemy.Y + 7] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X, (int)posicaoEnemy.Y + 8] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 1, (int)posicaoEnemy.Y + 8] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 1, (int)posicaoEnemy.Y + 9] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 1, (int)posicaoEnemy.Y + 10] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 2, (int)posicaoEnemy.Y + 10] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 2, (int)posicaoEnemy.Y + 11] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 3, (int)posicaoEnemy.Y + 11] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 4, (int)posicaoEnemy.Y + 11] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 4, (int)posicaoEnemy.Y + 12] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 5, (int)posicaoEnemy.Y + 12] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 6, (int)posicaoEnemy.Y + 12] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 7, (int)posicaoEnemy.Y + 12] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 8, (int)posicaoEnemy.Y + 12] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 8, (int)posicaoEnemy.Y + 11] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 9, (int)posicaoEnemy.Y + 11] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 10, (int)posicaoEnemy.Y + 11] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 10, (int)posicaoEnemy.Y + 10] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 11, (int)posicaoEnemy.Y + 10] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 11, (int)posicaoEnemy.Y + 9] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 11, (int)posicaoEnemy.Y + 8] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 12, (int)posicaoEnemy.Y + 8] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 12, (int)posicaoEnemy.Y + 7] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 12, (int)posicaoEnemy.Y + 6] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 12, (int)posicaoEnemy.Y + 5] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 12, (int)posicaoEnemy.Y + 4] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 11, (int)posicaoEnemy.Y + 4] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 11, (int)posicaoEnemy.Y + 3] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 11, (int)posicaoEnemy.Y + 2] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 10, (int)posicaoEnemy.Y + 2] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 10, (int)posicaoEnemy.Y + 1] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 9, (int)posicaoEnemy.Y + 1] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 8, (int)posicaoEnemy.Y + 1] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 7, (int)posicaoEnemy.Y] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 6, (int)posicaoEnemy.Y] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 5, (int)posicaoEnemy.Y] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 4, (int)posicaoEnemy.Y] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 4, (int)posicaoEnemy.Y + 1] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 3, (int)posicaoEnemy.Y + 1] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 2, (int)posicaoEnemy.Y + 1] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 2, (int)posicaoEnemy.Y + 2] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 1, (int)posicaoEnemy.Y + 2] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 1, (int)posicaoEnemy.Y + 3] = 1;
        game.MatrizColisao[(int)posicaoEnemy.X + 1, (int)posicaoEnemy.Y + 4] = 1;
    }
}
