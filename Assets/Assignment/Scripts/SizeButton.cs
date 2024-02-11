using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SizeButton : MonoBehaviour
{
    // I'll use the coal and diamond objects to use inside the inspector
    public GameObject coal;
    public GameObject diamond;

    /* 2 animation curves are needed because one to increase the size of the diamond and coal
    and the other to decrease the size of the diamond and coal */
    public AnimationCurve increaseSize;
    public AnimationCurve decreaseSize;

    float timer; // This will increment the timer of the animation curve

    Vector3 zeroPointThree; // This is used for the minimum scale of the diamond and coal during lerp

    // Start is called before the first frame update
    void Start()
    {
        zeroPointThree = new Vector3(0.3f, 0.3f, 0.3f); // Set the Vector3 to 0.3 for the x, y, and z axes

        // These are warnings you may want to read in the console when the game runs
        Debug.Log("When you press the + button, the scale of the diamond and coal will be sometimes set to its" +
            " lowest number. Keep pressing the + button to increase the size of the diamond and coal!");

        Debug.Log("When you press the - button, the scale of the diamond and coal will be sometimes set to its" +
            " highest number. Keep pressing the - button to decrease the size of the diamond and coal!");

        Debug.Log("You may need to press on the diamond or coal prefab to see its adjusted scale during runtime!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickPlusButton()
    {
        // Increment the timer and create an increased interpolation float for evaluating increase size curve timer
        timer += Time.deltaTime;
        float increasedInterpolation = increaseSize.Evaluate(timer);

        // Reset the timer to 0 if it's greater than 1 so that you can still lerp the diamond and coal size
        if (timer >= 1)
        {
            timer = 0;
        }

        // Lerp the diamond and coal size to increase each time the player presses the + button

        /* Warning: when you press the + button, the scale will be sometimes set to its lowest number
        (keep pressing the + button to increase the size of the diamond and coal) */
        diamond.transform.localScale = Vector3.Lerp(zeroPointThree, Vector3.one, increasedInterpolation);
        coal.transform.localScale = Vector3.Lerp(zeroPointThree, Vector3.one, increasedInterpolation);
    }

    public void ClickResetButton()
    {
        // Reset the scale of the diamond and coal back to its normal values when the player presses the reset button
        diamond.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        coal.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }

    public void ClickMinusButton()
    {
        // Increment the timer and create a decreased interpolation float for evaluating decrease size curve timer
        timer += Time.deltaTime;
        float decreasedInterpolation = decreaseSize.Evaluate(timer);

        // Reset the timer to 0 if it's greater than 1 so that you can still lerp the diamond and coal size
        if (timer >= 1)
        {
            timer = 0;
        }

        // Lerp the diamond and coal size to decrease each time the player presses the - button

        /* Warning: when you press the - button, the scale will be sometimes set to its highest number
        (keep pressing the - button to decrease the size of the diamond and coal) */
        diamond.transform.localScale = Vector3.Lerp(zeroPointThree, Vector3.one, decreasedInterpolation);
        coal.transform.localScale = Vector3.Lerp(zeroPointThree, Vector3.one, decreasedInterpolation);
    }
}
