using UnityEngine;

public class InteractableObject :MonoBehaviour
{
    public InteractableSO objectBase;
    public Canvas canvas;
    private InteractableSO info;

    


    private void Awake()
    {
        info = new InteractableSO(objectBase);
        canvas.gameObject.SetActive(false);


    }

    public void OnInteractUI()
    {
        canvas.gameObject.SetActive(true);
    }

    public void OffInteractUI()
    {
        canvas.gameObject.SetActive(false);
    }
    public void Interact()
    {
        if (info.interactionTime > 0)
        {
            Debug.Log(info.interactionTime);
            info.interactionTime -= 1;

            if (info.interactionTime <= 0) 
            {
                DropItem();
            }
        }
    }

    public void DropItem()
    {
        int index = Random.Range(0, info.dropItemLists.Count);
        Instantiate(info.dropItemLists[index], transform.position + new Vector3(0,1,0), Quaternion.identity, MapManager.Instance.CurrentMap.transform);
        Destroy(gameObject);
    }
}