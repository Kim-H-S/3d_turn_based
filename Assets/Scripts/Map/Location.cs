using System.Collections.Generic;
using UnityEngine;
public class Location
{
    public GameObject Icon;
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
        Icon = GameObject.Instantiate(MapManager.Instance._iconList[LocationType], parent);
        if (Icon != null)
        {
            Icon.transform.localPosition = (Vector3)position;
            Icon.GetComponent<UIMapIconTemp>().Init(this);
        }
        
    }

}


