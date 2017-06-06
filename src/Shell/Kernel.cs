
namespace Marcetux.Shell
{

    using Marcetux.Services.Interfaces;
    public class Kernel
{
    private readonly IMinuxService _minuxService;
 
    public Kernel(IMinuxService minuxService)
    {
        _minuxService = minuxService;
    }
 
    public void Run()
    {
        
        //_minuxService.Run();
        //System.Console.ReadKey();




    }
}
}