using System.Collections;
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

}


