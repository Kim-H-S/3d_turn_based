using System.Collections.Generic;
using UnityEngine;

public enum LocationType
{
    WoodArea,
    StoneArea,

    EndPoint,
}

public class Location
{
    public Location(Pos locationPos)
    {
        LocationPos = locationPos;
        LocationType = (LocationType)Random.Range(0,(int)LocationType.EndPoint);
        AdjLocations = new List<Pos>();
    }

    public Pos LocationPos { get; private set; }
    public List<Pos> AdjLocations { get; private set; }
    public LocationType LocationType { get; private set; }  

    public void DrawLocationIcon(Transform parent, Vector2 position)
    {
        GameObject go = GameObject.Instantiate(MapManager.Instance._iconList[LocationType], parent);
        if (go != null)
        {
            go.transform.localPosition = (Vector3)position;
            go.GetComponent<UIMapIconTemp>().Init(this);
        }
        
    }

}


