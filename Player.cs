using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player
{
    System.Random random = new System.Random();

    int velPlayer;

    public Game1 game;
    public RayCasting raycasting;
    public Cerebro cerebro;

    public bool death = false;
    public Color corPlayer;

    public int pontuacao;

    public int olhos = 8;

    public Vector2 posicaoPlayer;

    public int genesMutaveis;

    public Player(Game1 game)
    {
        this.game = game;
        // TODO: Add your initialization logic here
        // Setando a posição inicial do Mapa:

        // Setando a posição inicial do jogador:
        posicaoPlayer = new Vector2(263, 238);

        genesMutaveis = game.numGenesMutado;


        // Setando a Cor do Jogador:
        corPlayer = new Color(random.Next(256), random.Next(256), random.Next(256), 255);

        // Setando a Velocidade do Jogador;
        velPlayer = 1;

        cerebro = new Cerebro(this);


    }
    public void IniciaVisao()
    {
        raycasting = new RayCasting(this);
    }

    public void CriaRaciocinio()
    {
        cerebro.PreencherPesosIniciais();
    }

    public void ChecaMorte()
    {


            for (int i = 0; i < game.playerTexture.Width; i++)
        {
            if (game.MatrizColisao[(int)posicaoPlayer.X - game.playerTexture.Width / 2, (int)posicaoPlayer.Y - game.playerTexture.Width / 2 + i] == -1)
            {
                Morto();
            }

            if (game.MatrizColisao[(int)posicaoPlayer.X + game.playerTexture.Width / 2, (int)posicaoPlayer.Y - game.playerTexture.Width / 2 + i] == -1)
            {
                Morto();
            }
            if(i < game.playerTexture.Width - 2)
            {
                if (game.MatrizColisao[(int)posicaoPlayer.X - (game.playerTexture.Width / 2) + 1 + i, (int)posicaoPlayer.Y - game.playerTexture.Width / 2] == -1)
                {
                    Morto();
                }
                if (game.MatrizColisao[(int)posicaoPlayer.X - (game.playerTexture.Width / 2) + 1 + i, (int)posicaoPlayer.Y + game.playerTexture.Width / 2] == -1)
                {
                    Morto();
                }
            }
        }
    }

    public void Morto()
    {
        death = true;
        //corPlayer.R = 0;
        //corPlayer.G = 0;
        //corPlayer.B = 0;
        corPlayer.A = 150;
    }

    public void Move()
    {

        cerebro.Processamento();

        
        if (cerebro.saidaBool[0] && !death)
        {
            if (game.MatrizColisao[(int)posicaoPlayer.X - game.playerTexture.Width / 2, (int)posicaoPlayer.Y - velPlayer - game.playerTexture.Height / 2] != 0 &&
                game.MatrizColisao[(int)posicaoPlayer.X + game.playerTexture.Width / 2, (int)posicaoPlayer.Y - velPlayer - game.playerTexture.Height / 2] != 0)
                posicaoPlayer.Y -= velPlayer;
        }
        if (cerebro.saidaBool[1] && !death)
        {
            if (game.MatrizColisao[(int)posicaoPlayer.X - game.playerTexture.Width / 2, (int)posicaoPlayer.Y + velPlayer + game.playerTexture.Height / 2] != 0 &&
                game.MatrizColisao[(int)posicaoPlayer.X + game.playerTexture.Width / 2, (int)posicaoPlayer.Y + velPlayer + game.playerTexture.Height / 2] != 0)
                posicaoPlayer.Y += velPlayer;
        }
        if (cerebro.saidaBool[2] && !death)
        {
            if (game.MatrizColisao[(int)posicaoPlayer.X + velPlayer + game.playerTexture.Width / 2, (int)posicaoPlayer.Y - game.playerTexture.Height / 2] != 0 &&
                game.MatrizColisao[(int)posicaoPlayer.X + velPlayer + game.playerTexture.Width / 2, (int)posicaoPlayer.Y + game.playerTexture.Height / 2] != 0)
                posicaoPlayer.X += velPlayer;
        }
        if (cerebro.saidaBool[3] && !death)
        {
            if (game.MatrizColisao[(int)posicaoPlayer.X - velPlayer - game.playerTexture.Width / 2, (int)posicaoPlayer.Y - game.playerTexture.Height / 2] != 0 &&
                game.MatrizColisao[(int)posicaoPlayer.X - velPlayer - game.playerTexture.Width / 2, (int)posicaoPlayer.Y + game.playerTexture.Height / 2] != 0)
                posicaoPlayer.X -= velPlayer;
        }
        /*
        if (Keyboard.GetState().IsKeyDown(Keys.W))
        {
            if (game.MatrizColisao[(int)posicaoPlayer.X - game.playerTexture.Width / 2, (int)posicaoPlayer.Y - velPlayer - game.playerTexture.Height / 2] != 0 &&
                game.MatrizColisao[(int)posicaoPlayer.X + game.playerTexture.Width / 2, (int)posicaoPlayer.Y - velPlayer - game.playerTexture.Height / 2] != 0)
                posicaoPlayer.Y -= velPlayer;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.S))
        {
            if (game.MatrizColisao[(int)posicaoPlayer.X - game.playerTexture.Width / 2, (int)posicaoPlayer.Y + velPlayer + game.playerTexture.Height / 2] != 0 &&
                game.MatrizColisao[(int)posicaoPlayer.X + game.playerTexture.Width / 2, (int)posicaoPlayer.Y + velPlayer + game.playerTexture.Height / 2] != 0)
                posicaoPlayer.Y += velPlayer;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.D))
        {
            if (game.MatrizColisao[(int)posicaoPlayer.X + velPlayer + game.playerTexture.Width / 2, (int)posicaoPlayer.Y - game.playerTexture.Height / 2] != 0 &&
                game.MatrizColisao[(int)posicaoPlayer.X + velPlayer + game.playerTexture.Width / 2, (int)posicaoPlayer.Y + game.playerTexture.Height / 2] != 0)
                posicaoPlayer.X += velPlayer;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.A))
        {
            if (game.MatrizColisao[(int)posicaoPlayer.X - velPlayer - game.playerTexture.Width / 2, (int)posicaoPlayer.Y - game.playerTexture.Height / 2] != 0 &&
                game.MatrizColisao[(int)posicaoPlayer.X - velPlayer - game.playerTexture.Width / 2, (int)posicaoPlayer.Y + game.playerTexture.Height / 2] != 0)
                posicaoPlayer.X -= velPlayer;
        }*/

        pontuacao = game.MatrizPontuacao[(int)posicaoPlayer.X, (int)posicaoPlayer.Y];
    }
}