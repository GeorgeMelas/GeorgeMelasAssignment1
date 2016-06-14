using UnityEngine;
using System.Collections;

using LitJson;// Allows us to take JSON data and turn it into a C# object!
// We Need Access to the file system
using System.IO;

// We need a generic list of items
using System.Collections.Generic;

// Class to define our stats
[System.Serializable]
public class Stat
{
    public int power { get; set; }
    public int defence { get; set; }
    public int vitalitiy { get; set; }
}
// Class to define our Item
[System.Serializable]
    public class ItemData
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Value { get; set; }
    public Stat Stats { get; set; }
    public bool Stackable { get; set; }
    public string Slug { get; set; }
    public Sprite sprite { get; set; }
    public GameObject gameobject { get; set; }

    // Custom Constructor for item that takes in JsonData
    public ItemData(JsonData data)
    {
        Id = (int)data["id"];
        Title = data["title"].ToString();
        Description = data["description"].ToString();
        Value = (int)data["value"];
        Stats = new Stat();
        Stats.power = (int)data["stats"]["power"];
        Stats.defence = (int)data["stats"]["defence"];
        Stats.vitalitiy =(int)data["stats"]["vitality"];
        Stackable = (bool)data["stackable"];
        Slug = data["slug"].ToString();


        sprite = Resources.Load<Sprite>("Sprites/Items/" + Slug);
    }
}
public class ItemDatabase : MonoBehaviour
{
    private List<ItemData> database = new List<ItemData>();
    // Holds the JSON data we pull in from the scene
    private JsonData itemData;


	// Use this for initialization
	void Awake ()
    {
        // Read in from Json File
        string jsonFilePath = Application.dataPath + "/StreamingAssets/items.json";
       
        // Load in the data
        string jsonData = File.ReadAllText(jsonFilePath);

        

        // Read the Json file
        itemData = JsonMapper.ToObject(jsonData);

        // Construct item database
        ConstructItemDatabase();
    }
	
    void ConstructItemDatabase()
    {
        // Loop through all items from Json data
        for (int i = 0; i < itemData.Count; i++)
        {
            // Add each to database list
            database.Add(new ItemData(itemData[i]));
        }
    }
	public ItemData GetItemById(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            // Check if current itme has the same ID

            if(database[i].Id == id)
            {
                return database[i];
            }
        }

        //Return null otherwise

        return null;
    }
}
