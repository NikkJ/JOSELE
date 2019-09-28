internal class vector2
{
    private float v1;
    private int v2;
    private int v;
    private float maxHeight;

    public vector2(float v1, int v2)
    {
        this.v1 = v1;
        this.v2 = v2;
    }

    public vector2(int v, float maxHeight)
    {
        this.v = v;
        this.maxHeight = maxHeight;
    }
}