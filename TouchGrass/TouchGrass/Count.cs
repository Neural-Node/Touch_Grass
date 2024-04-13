// Count.cs
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace TouchGrass;

public class Count
{
    //represents how many pieces of grass that have been clicked
    public int clicks;

    public Count(){
        //sets it to 0
        clicks = 0;
    }

    //This needs a reference event for the updates
    private void clickedGrass()
    {
        clicks++;
        //This could get changed later
        //Label1.Text = clicks.ToString();
    }
}
