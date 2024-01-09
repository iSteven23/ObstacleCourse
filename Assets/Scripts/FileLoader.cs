using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class FileLoader : MonoBehaviour
{
    public GameObject scrollViewContent;
    public GameObject buttonTemplate;
    public string directoryPath = @"J:\Projects\JSON";

    // Start is called before the first frame update
    void Start()
    {
        if (Directory.Exists(directoryPath)){
            // Get all JSON files in the directory
            string[] jsonFiles = Directory.GetFiles(directoryPath, "*.json");

            // Loop through each file and print its name
            foreach (string file in jsonFiles)
            {
                string fileName = Path.GetFileName(file);
                Debug.Log("Found JSON File: " + fileName);
                GameObject newItems = Instantiate<GameObject>(buttonTemplate, transform);                
                newItems.transform.SetParent(scrollViewContent.transform);
                
                Text buttonText = newItems.GetComponentInChildren<Text>();
                if (buttonText != null) {
                    buttonText.text = fileName;
                }
                // Add onClick Listener
                newItems.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(fileName));
            }
            
        }
        else
        {
            Debug.LogError("Directory does not exist. ");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonClicked(string filePath)
    {
        // Handle the button click event
        Debug.Log("Button clicked for file: " + filePath);
        // Add your code here to handle what happens when the button is clicked
    }
}
