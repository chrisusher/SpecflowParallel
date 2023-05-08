namespace SpecflowParallel.Pages;

public class PageBase
{
    protected IPage Page;

    public virtual bool OnPage => false;
}