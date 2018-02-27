using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;


public class TextReader : MonoBehaviour {

    //Function to read any given text file that converts all data to string arrays
    public bool Load(string fileName,List<string>l) {
        string line;
        Debug.Log(fileName + "read");
            // Create a new StreamReader, tell it which file to read and what encoding the file was saved as
        StreamReader theReader = new StreamReader(Application.streamingAssetsPath + "/" + fileName + ".txt", Encoding.Default);
        using (theReader) {
            // While there's lines left in the text file, do this:
            do {
                line = theReader.ReadLine();
                if (line != null) {
                    // Do whatever you need to do with the text line, it's a string now
                    string[] entries = line.Split(',');
                    if (entries.Length > 0) {
                        l.Add(line);
                    }
                }
            }

            while (line != null);
                        // Done reading, close the reader
                        theReader.Close();
                        return true;
                    }
                }       
    }