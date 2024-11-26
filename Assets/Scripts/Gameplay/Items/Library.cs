using DG.Tweening;
using UnityEngine;

public class Library : Item
{
    public Transform libraryRenderer;
    public float yMove;
    public void Interact(bool isOpen)
    {
        if (isOpen)
            Unlock();
        else
            Lock();
    }

    void Lock()
    {
        libraryRenderer.DOLocalMoveY(0, 1);
    }

    public void Unlock()
    {
        libraryRenderer.DOLocalMoveY(yMove, 1);
    }
}
