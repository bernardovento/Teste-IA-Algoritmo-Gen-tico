using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Security.Cryptography;
using System.Security.Principal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class Game1 : Game
{

    System.Random random = new System.Random();


    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    Texture2D mapaTexture;
    public Texture2D playerTexture;
    public Texture2D enemyTexture;
    public int[,] MatrizColisao;
    public int[,] MatrizPontuacao;
    Texture2D blocoTeste;
    public int geracao;

    public int idSimulacao;

    public int maiorDistancia;

    int numIndividuos;
    public int numGenesMutado;
    int numEnemys;
    SpriteFont Ubuntu32;
    Player[] player;
    Enemy[] enemy;

    float pontuacaoMedia;

    int playerMaiorPont;


    float tempoLimite = 5f;
    float tempoPassado = 0f;

    Vector2 mousePos;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {


        // TODO: Add your initialization logic here

        idSimulacao = random.Next(100000000, 999999999);


        // Setando o Tamanho da janela do jogo, para ser igual do Mapa:
        _graphics.IsFullScreen = false;
        _graphics.PreferredBackBufferWidth = 900;
        _graphics.PreferredBackBufferHeight = 600;
        _graphics.ApplyChanges();

        playerMaiorPont = 0;
        geracao = 0;

        base.Initialize();

        pontuacaoMedia = 0;

        numIndividuos = 400;
        numEnemys = 4;
        numGenesMutado = 26;

        player = new Player[numIndividuos];

        for (int i = 0;i < numIndividuos; i++)
        {
            player[i] = new Player(this);
            player[i].CriaRaciocinio();
        }






        // Cria um Vetor do tamanho dos pixels do Mapa:
        Color[] CoresDoMapa = new Color[mapaTexture.Width * mapaTexture.Height];

        // Preenche o vetor CoresDoMapa com as Cores do Mapa:
        mapaTexture.GetData(CoresDoMapa);

        MatrizColisao = new int[mapaTexture.Width, mapaTexture.Height];
        MatrizPontuacao = new int[mapaTexture.Width, mapaTexture.Height];



        for (int x = 0; x < mapaTexture.Width; x++)
        {
            for (int y = 0; y < mapaTexture.Height; y++)
            {
                if(CoresDoMapa[x + y * mapaTexture.Width] == Color.Black)
                {
                    MatrizColisao[x, y] = 0;
                    MatrizPontuacao[x, y] = 9999999;
                }   
                else
                {
                    MatrizColisao[x, y] = 1;
                    MatrizPontuacao[x, y] = 9999999;
                }
            }
        }

        preencherPontuacao(263, 225);

        enemy = new Enemy[numEnemys];

        for (int i = 0; i < numEnemys; i++)
        {
            if (i % 2 == 0)
                enemy[i] = new Enemy(this, new Vector2(557, 256 + i * 25));
            else
                enemy[i] = new Enemy(this, new Vector2(329, 256 + i * 25));

        }

    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // TODO: use this.Content to load your game content here

        mapaTexture = Content.Load<Texture2D>("mapa_900x600");

        Ubuntu32 = Content.Load<SpriteFont>("fonts/Ubuntu32");

        playerTexture = Content.Load<Texture2D>("jogador17x17");

        blocoTeste = Content.Load<Texture2D>("BlocoPreto");

        enemyTexture = Content.Load<Texture2D>("inimigo13x13");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        // TODO: Add your update logic here

        MouseState mouseState = Mouse.GetState();

        if((mouseState.X > 899 || mouseState.X < 1) || (mouseState.Y > 599 || mouseState.Y < 1))
            mousePos = new Vector2(0, 0);
        else
            mousePos = new Vector2(mouseState.X, mouseState.Y);


        for (int i = 0; i < numEnemys; i++)
        {
            enemy[i].Move();
        }


        base.Update(gameTime);

        for(int i = 0; i < numIndividuos; i++)
        {
            player[i].IniciaVisao();

            player[i].Move();

            //player[i].ChecaMorte();
        }


        
        for (int i = 0; i < numIndividuos; i++)
        {
            if (player[i].pontuacao > player[playerMaiorPont].pontuacao)
                playerMaiorPont = i;
        }




        tempoPassado += (float)gameTime.ElapsedGameTime.TotalSeconds; //Contador de tempo
        if (tempoPassado >= tempoLimite)
        {
            pontuacaoMedia = 0;

            for (int i = 0; i < numIndividuos; i++)
            {
                pontuacaoMedia = player[i].pontuacao + pontuacaoMedia;
                player[i].Morto();
                if (!(i == playerMaiorPont))
                {
                    player[i].cerebro.CopiarInteligencia(player[playerMaiorPont].cerebro);
                    player[i].cerebro.MutarGenes();
                }
                player[i].posicaoPlayer.X = 263;
                player[i].posicaoPlayer.Y = 238;
                player[i].corPlayer = player[i].cerebro.corOriginal;
                player[i].death = false;
            }
            if (player[playerMaiorPont].pontuacao > 172)
                tempoLimite = 8;
            if (player[playerMaiorPont].pontuacao > 310)
                tempoLimite = 12;
            geracao++;
            pontuacaoMedia = pontuacaoMedia / numIndividuos;
            if (geracao % 50 == 0)
                player[playerMaiorPont].cerebro.SalvarInteligencia();
            playerMaiorPont = 0;
            tempoPassado = 0f;
        }


    }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();

        _spriteBatch.Draw(mapaTexture, new Vector2(0, 0), Color.White);

        _spriteBatch.DrawString(Ubuntu32, "Tempo da Geracao: " + (int)tempoPassado, new Vector2(10,5), Color.Black);
        _spriteBatch.DrawString(Ubuntu32, "Player de Maior Ponto: " + playerMaiorPont, new Vector2(10, 25), Color.Black);
        _spriteBatch.DrawString(Ubuntu32, "Maior Pontuacao: " + player[playerMaiorPont].pontuacao, new Vector2(10, 45), Color.Black);
        _spriteBatch.DrawString(Ubuntu32, "Geracao: " + geracao, new Vector2(10, 65), Color.Black);
        _spriteBatch.DrawString(Ubuntu32, "Posicao do Mouse Pontuacao: " + MatrizPontuacao[(int)mousePos.X, (int)mousePos.Y], new Vector2(10, 535), Color.Black);
        _spriteBatch.DrawString(Ubuntu32, "Posicao do Mouse Colisao: " + MatrizColisao[(int)mousePos.X, (int)mousePos.Y], new Vector2(10, 555), Color.Black);
        _spriteBatch.DrawString(Ubuntu32, "Pontuacao media da geracao anterior: " + pontuacaoMedia, new Vector2(10, 575), Color.Black);


        
        for (int i = 0; i < numIndividuos;i++)
        {
            _spriteBatch.Draw(playerTexture, new Vector2(player[i].posicaoPlayer.X - 8, player[i].posicaoPlayer.Y - 8), player[i].corPlayer);
            //_spriteBatch.Draw(playerTexture, new Vector2(player[playerMaiorPont].posicaoPlayer.X - 8, player[playerMaiorPont].posicaoPlayer.Y - 8), player[playerMaiorPont].corPlayer);
        }

        //_spriteBatch.Draw(blocoTeste, enemy[1].posicaoEnemy, Color.White);

        // Desenhando inimigos:
        for (int i = 0; i < numEnemys; i++)
        {
            _spriteBatch.Draw(enemyTexture, enemy[i].posicaoEnemy, Color.White);
        }

        // Finaliza Desenhos
        _spriteBatch.End();


        base.Draw(gameTime);
    }
    public void preencherPontuacao(int posX, int posY)
    {
        //Posicao de inicio: X = 263, Y = 225
        //Posicao de chegada: X = 638, Y = 365
        if (!File.Exists("data\\mapaPontuacao\\mapaPontuacao1.txt"))
        {
            MatrizPontuacao[posX, posY] = 0;
            int novo;

            while (true)
            {
                bool mudou = false;

                for (int k = 0; k < mapaTexture.Width; k++)
                {
                    for (int m = 0; m < mapaTexture.Height; m++)
                    {
                        if (MatrizColisao[k, m] == 1)
                        {
                            novo = 1 + MenorVizinho(k, m);
                            if (novo < MatrizPontuacao[k, m])
                            {
                                MatrizPontuacao[k, m] = novo;
                                if(!mudou)
                                {
                                    mudou = true;
                                }
                            }
                        }
                    }
                }


                if (!mudou)
                {
                    break;
                }
            }


            for (int x = 0; x < mapaTexture.Width; x++)
            {
                for (int y = 0; y < mapaTexture.Height; y++)
                {
                    if (MatrizColisao[x, y] == 0)
                    {
                        MatrizPontuacao[x, y] = -1;
                    }
                }
            }
            SalvarPontuacao();
        }
        else
        {
            CarregarPontuacao();
        }

        maiorDistancia = MaiorDistancia();
    }

    int MenorVizinho(int posX, int posY)
    {
        int[] vizinhos = new int[8];

        vizinhos[0] = MatrizPontuacao[posX - 1, posY + 1];
        vizinhos[1] = MatrizPontuacao[posX, posY + 1];
        vizinhos[2] = MatrizPontuacao[posX + 1, posY + 1];
        vizinhos[3] = MatrizPontuacao[posX - 1, posY];

        vizinhos[4] = MatrizPontuacao[posX + 1,posY];
        vizinhos[5] = MatrizPontuacao[posX - 1, posY - 1];
        vizinhos[6] = MatrizPontuacao[posX, posY - 1];
        vizinhos[7] = MatrizPontuacao[posX + 1, posY - 1];

        int menor = 9999999;
        for (int i = 0; i < 8; i++)
        {
            if (vizinhos[i] < menor && vizinhos[i] >= 0)
            {
                menor = vizinhos[i];
            }
        }
        return menor;
    }

    public int MaiorDistancia()
    {
        int maior = 0;
        int indicek = 0, indicem = 0;
        for (int k = 0; k < mapaTexture.Width; k++)
        {
            for (int m = 0; m < mapaTexture.Height; m++)
            {
                if (MatrizColisao[k, m] == 1)
                {
                    if (MatrizPontuacao[k, m] > maior && MatrizPontuacao[k, m] != 9999999)
                    {
                        maior = MatrizPontuacao[k, m];
                        indicek = k;
                        indicem = m;
                    }
                }
            }
        }

        return maior;
    }
    public void SalvarPontuacao()
    {
        using (StreamWriter sw = new StreamWriter("data\\mapaPontuacao\\mapaPontuacao1.txt"))
        {
            for (int x = 0; x < mapaTexture.Width; x++)
            {
                for (int y = 0; y < mapaTexture.Height; y++)
                {
                    sw.WriteLine(MatrizPontuacao[x, y]);
                }
            }
        }
        
    }
    public void CarregarPontuacao()
    {
        
        // Read and show each line from the file.
        using (StreamReader sr = new StreamReader("data\\mapaPontuacao\\mapaPontuacao1.txt"))
        {


            int x = 0; 
            int y = 0;
            string ln;

            while ((ln = sr.ReadLine()) != null)
            {
                Console.WriteLine(ln);
                MatrizPontuacao[x, y] = int.Parse(ln);
                y++;
                if(y == mapaTexture.Height)
                {
                    x++;
                    y = 0;
                }
            }
        }
    }
}