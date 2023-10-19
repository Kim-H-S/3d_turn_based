using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableObject :MonoBehaviour
{
    public InteractableSO info;


    private void Awake()
    {


        GameManager.Instance.ResourceRepository.InteractableObjectScriptList.Add(this);

    }

    public virtual void Interact()
    {

        if(info is GatheringInteractableSO)
        {

            var gatheringSO = info as GatheringInteractableSO;

            if (gatheringSO.interactionTime > 0)
            {
                Debug.Log(gatheringSO.interactionTime);
                gatheringSO.interactionTime -= 1;

                if (gatheringSO.interactionTime <= 0)
                {
                    DropItem();
                }
            }

        }
        
    }

    public void DropItem()
    {

        var gatheringSO = info as GatheringInteractableSO;

        int index = Random.Range(0, gatheringSO.dropItemLists.Count);
        Instantiate(gatheringSO.dropItemLists[index], transform.position + new Vector3(0,1,0), Quaternion.identity, MapManager.Instance.CurrentMap.transform);
        Destroy(gameObject);

    }

}