using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml;
using System.Collections;
using System.Collections.Generic;


public class Cerebro
{
    public Cerebro(){ }
    Player player;

    System.Random random = new System.Random();

    public int[] oculto;
    int numOcultos;

    public int[][] pesosEntrada;
    int[][] pesosSaida;
    int[] saidaInt;
    public bool[] saidaBool;

    public Color corOriginal;


    public Cerebro(Player player)
	{
        this.player = player;
        corOriginal = player.corPlayer;

        numOcultos = 4;
        oculto = new int[numOcultos];
        saidaBool = new bool[numOcultos];
        saidaInt = new int[numOcultos];


        pesosEntrada = new int[numOcultos][];
        pesosSaida = new int[numOcultos][];

        for (int i = 0; i < numOcultos; i++)
        {
            pesosEntrada[i] = new int[player.olhos + 1];
            pesosSaida[i] = new int[numOcultos];
            pesosEntrada[i][player.olhos] = 1;
        }


    }

    public void Processamento()
    {

        for(int i = 0; i < numOcultos; i++)
        {
            oculto[i] = 0;
            for (int j = 0; j < player.olhos + 1; j++)
            {
                if(!(j == player.olhos))
                    oculto[i] = oculto[i] + (player.raycasting.disCadaRaio[j] * pesosEntrada[i][j]);
                oculto[i] = oculto[i] + pesosEntrada[i][j];
            }
            oculto[i] = oculto[i] + pesosEntrada[i][player.olhos];
            //if (oculto[i] < 0)
                //oculto[i] = 0;
        }

        for(int i = 0; i < numOcultos; i++) 
        {
            saidaInt[i] = 0;
            saidaBool[i] = false;
            for (int j = 0; j < numOcultos; j++)
            {
                saidaInt[i] = saidaInt[i] + player.raycasting.disCadaRaio[j] * pesosSaida[i][j];
            }
            if (saidaInt[i] > 0)
                saidaBool[i] = true;
        }

    }

    public void PreencherPesosIniciais()
    {
        for(int i = 0; i < player.olhos + 1; i++) 
        {
            for (int j = 0; j < numOcultos; j++)
            {
                pesosEntrada[j][i] = PreencherPesoAleatoriamente();
            }
        }
        for (int i = 0; i < numOcultos; i++)
        {
            for (int j = 0; j < numOcultos; j++)
            {
                pesosSaida[i][j] = PreencherPesoAleatoriamente();
            }
        }
    }
    public int PreencherPesoAleatoriamente()
    {
        return random.Next(-1000, 1001);
    }

    public void CopiarInteligencia(Cerebro alvoCopia)
    {
        for (int i = 0; i < player.olhos + 1; i++)
        {
            for (int j = 0; j < numOcultos; j++)
            {
                pesosEntrada[j][i] = alvoCopia.pesosEntrada[j][i];
            }
        }
        for (int i = 0; i < numOcultos; i++)
        {
            for (int j = 0; j < numOcultos; j++)
            {
                pesosSaida[i][j] = alvoCopia.pesosSaida[j][i];
            }
        }
    }

    public void MutarGenes()
    {
        double mutar;
        for(int i = 0;i < player.genesMutaveis; i++)
        {
            mutar = random.Next(0, (numOcultos * numOcultos) + (numOcultos * (player.olhos + 1)) - 1);
            if (mutar > numOcultos * numOcultos - 1)
            {
                mutar = mutar - (numOcultos * numOcultos);
                pesosEntrada[System.Convert.ToInt32(mutar % numOcultos)][System.Convert.ToInt32(System.Math.Floor(mutar / numOcultos))] = PreencherPesoAleatoriamente();
            }
            else
                pesosSaida[System.Convert.ToInt32(System.Math.Floor(mutar / numOcultos))][System.Convert.ToInt32(mutar % numOcultos)] = PreencherPesoAleatoriamente();
        }
    }

    public void SalvarInteligencia()
    {
        //data\\InteligenciaIA\\IAtest.dat
        FileStream writer = new FileStream("data\\InteligenciaIA\\IA_Gen_"+ player.game.geracao +"_ID_" + player.game.idSimulacao + ".dat", FileMode.Create);
        DataContractSerializer ser = new DataContractSerializer(typeof(Cerebro));
        ser.WriteObject(writer, this);
        writer.Close();



    }
    public void LerInteligencia()
    {
        FileStream fs = new FileStream("data\\InteligenciaIA\\IAtest.dat", FileMode.Open);
        XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
        DataContractSerializer ser = new DataContractSerializer(typeof(Cerebro));
        Cerebro deserializedPerson = (Cerebro)ser.ReadObject(reader, true);
        reader.Close();
        fs.Close();
    }
}