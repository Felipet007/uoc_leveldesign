using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    public int keysObtained = 0;

	public void AddKey()
    {
        keysObtained++;
        Debug.Log("Key added. Number of keys: " + keysObtained);
    }

    public bool UseKey()
    {
        if (keysObtained == 0) return false;
        keysObtained--;
        Debug.Log("Used key. Number of keys: " + keysObtained);
        return true;
    }

    public int GetKeyAmount()
    {
        return keysObtained;
    }
}
