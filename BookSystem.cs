using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class BookSystem : MonoBehaviour
{
    public Book[] books;
    private string savePath;
    public UnityEvent FirstPlay;
    public UnityEvent notFirstPlay;
    public float discoveryThreshold;

    void Start()
    {
        savePath = Application.persistentDataPath + "/saveDiscover.dat";
        if (File.Exists(savePath))
        {
            notFirstPlay.Invoke();
        }
        else
        {
            FirstPlay.Invoke();
        }
    }

    public void DiscoverObject(string objectName)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (objectName == books[i].name)
            {
                books[i].isDiscover = true;
                books[i].pages.SetActive(true);
                SaveDiscoverStatus();
            }
        }
    }

    public void ResetData()
    {
        for (int i = 0; i < books.Length; i++)
        {
            books[i].isDiscover = false;
            books[i].pages.SetActive(false);
        }
        SaveDiscoverStatus();
    }

    void SaveDiscoverStatus()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savePath);
        bf.Serialize(file, books);
        file.Close();
    }

    void LoadDiscoverStatus()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            books = (Book[])bf.Deserialize(file);
            file.Close();
        }
    }

    void CheckEnding()
    {
        int discoveredCount = 0;
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].isDiscover)
            {
                discoveredCount++;
            }
        }

        float percentageDiscovered = (float)discoveredCount / books.Length;

        if (percentageDiscovered >= discoveryThreshold)
        {
            // Jika jumlah makhluk yang telah ditemukan mencapai threshold, alihkan ke scene ending
            SceneManager.LoadScene("EndingScene");
        }
    }
}
