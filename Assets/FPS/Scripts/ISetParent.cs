using UnityEngine;

public interface ISetParent 
{
    public void SetParent(GameObject parentGameObject, GameObject childGameObject);
    public void ClearParent();
}
