using Unity.VisualScripting;

public class FollowPlayerFirstPerson : FollowPlayer {

    public FollowPlayerFirstPerson() : base(new(-0.5f, 1.8f, 1)) {
        // noop
    }

    public override void LateUpdate() {
        base.LateUpdate();

        // not perfect because the camera
        // is not at the center of the player
        // but it's fine to play with
        transform.rotation = player.transform.rotation;
    }
}
