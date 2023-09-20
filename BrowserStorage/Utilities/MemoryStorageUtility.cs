namespace BrowserStorage.Utilities;

public class MemoryStorageUtility
{
    private Dictionary<string, object> _storage = new();


    public string GetSync(string key) {
        if(_storage.TryGetValue(key, out var value))
        {
            return value.ToString() ?? "";
        }
        else
        {
            return "";
        }

    
    }

    public void SetSync(string key, string value) { _storage[key] = value; }

    public void ClearSync() { _storage.Clear();}

    public void RemoveSync(string key) { _storage.Remove(key);}
}
