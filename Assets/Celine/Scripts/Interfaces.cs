using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameAction
{
    JUMP,
    DUCK,
    MOVE_HORIZONTAL,
}

public interface IInputSystem
{
    float GetAxis(GameAction action);
}

public interface IControllable
{
    void Move(float x);
}

