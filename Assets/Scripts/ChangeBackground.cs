using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement; 

public class ChangeBackground : MonoBehaviour
{
    private string folderPath;
    List<Texture2D> images;
    private int counter;

    [SerializeField] private Image setImage;

    private void Start()
    {
        counter = 0;
        folderPath = Application.dataPath + "/StreamingAssets/Images";
        string[] files = Directory.GetFiles(folderPath, "*.jpg");
        images = new List<Texture2D>();

        foreach(string filePath in files)
        {
            byte[] imageData = File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(imageData);
            images.Add(texture);
        }

        setImage.sprite = Sprite.Create(images[counter], new Rect(0, 0, images[counter].width, images[counter].height), Vector2.zero);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(counter < images.Count -1)
            {
                counter += 1;
                setImage.sprite = setImage.sprite = Sprite.Create(images[counter], new Rect(0, 0, images[counter].width, images[counter].height), Vector2.zero);
                print(counter);
            }

        }

        if (Input.GetKeyDown(KeyCode.Return) && counter == 3)
        {
            SceneManager.LoadScene("DragAndDrop");
        }

        

    }
}


