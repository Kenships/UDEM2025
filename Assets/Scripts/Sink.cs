
using UnityEngine;

public class Sink : Appliance
{
    public override void Interact(GameObject player)
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Sink);
        InteractMode(player);
    }

    public override void Exit(GameObject player)
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Bark);
        MovementMode(player);
    }
}