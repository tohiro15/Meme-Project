using UnityEngine;

public interface IMovement
{
    void HandleMovement(Vector2 input);
}

public interface IJump
{
    void HandleJump();
    void Update();
}
public interface ILook
{
    void HandleLook(Vector2 input);
}