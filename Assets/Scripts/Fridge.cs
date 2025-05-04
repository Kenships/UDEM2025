using UnityEngine;

public class Fridge : Appliance
{
    public override void Interact(GameObject player)
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Door_Open);
        InteractMode(player);
    }

    public override void Exit(GameObject player)
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Door_Close);
        MovementMode(player);
    }
}