using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class RayCasting
{
    Player player;

    public int[] disCadaRaio;

    public RayCasting(Player player)
	{
        this.player = player;

        double disRadiano;

        disRadiano = 2 * Math.PI / player.olhos;

        disCadaRaio = new int[player.olhos];





        for (int i = 0; i < player.olhos; i++)
		{
            disCadaRaio[i] = 0;
            disCadaRaio[i] = Cast(player.posicaoPlayer, i * disRadiano, disCadaRaio[i]);
        }


    }


    public int Cast(Vector2 posRaio, double angle,int disAndada)
	{

        double cos_radianos = Math.Cos(angle); // Calculo de X
        double sin_radianos = Math.Sin(angle); // Calculo de Y

        posRaio.X = posRaio.X + (float)cos_radianos;
        posRaio.Y = posRaio.Y + (float)sin_radianos;
        
        if (player.game.MatrizColisao[(int)Math.Round((double)posRaio.X), (int)Math.Round((double)posRaio.Y)] == -1)
            return - 1;
        else if (player.game.MatrizColisao[(int)Math.Round((double)posRaio.X), (int)Math.Round((double)posRaio.Y)] == 0)
            return 1;
        else
        {
            int a = Cast(posRaio, angle, disAndada);
            if (a < 0)
                return a - 1;
            else
                return a + 1;
        }
    }
}
