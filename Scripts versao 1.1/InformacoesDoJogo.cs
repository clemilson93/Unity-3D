using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class InformacoesDoJogo : MonoBehaviour {

    public int maiorPontuacao;
    public int pontosDoJogador;
    Ranking ranking;
    BinaryFormatter bf;
    FileStream file;

    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(gameObject);
        if (File.Exists(Application.persistentDataPath + "/Game data/Ranking_Data.sys"))
        {
            bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + "/Game data/Ranking_Data.sys", FileMode.Open);
            ranking = (Ranking)bf.Deserialize(file);
            maiorPontuacao = ranking.pontos;
            file.Close();
        }
        else
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Game data");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/Game data/Ranking_Data.sys");
            ranking = new Ranking();
            bf.Serialize(file, ranking);
            file.Close();
        }
    }
	
	// Update is called once per frame
	public void SalvarPontuacao(int pontuacao)
    {
        file = File.Open(Application.persistentDataPath + "/Game data/Ranking_Data.sys", FileMode.Open);
        if (pontuacao > maiorPontuacao)
        {
            ranking.pontos = pontuacao;
            maiorPontuacao = pontuacao;
            bf.Serialize(file, ranking);
        }
        file.Close();
    }
}
[Serializable]
public class Ranking
{
    public int pontos = 0;
}