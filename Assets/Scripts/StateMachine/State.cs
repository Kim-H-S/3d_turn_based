using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T> where T : class
{
    public abstract void Enter(T entity);

    public abstract void Excute(T entity);
    
    public abstract void Exit(T entity);
}
