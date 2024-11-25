using DG.Tweening;
using UnityEngine;

public class Lever : Item
{
    public Library library;
    public Transform leverStick;
    bool isActive = false;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            isActive = !isActive;
            library.Interact(isActive);
            ActiveAnimation(isActive);
        }
    }
    public override void Interaction(PlayerInteractor player)
    {
        base.Interaction(player);
        isActive = !isActive;
        library.Interact(isActive);
        ActiveAnimation(isActive);
    }

    void ActiveAnimation(bool isActive)
    {
        if (isActive)
        {
            leverStick.DOLocalRotate(new Vector3(50,0,0), 1);
        } else
            leverStick.DOLocalRotate(new Vector3(-50,0,0), 1);
    }
}
