using shop25.Data.Model;

namespace shop25.Data.Interfaces
{
    public interface ITovap
    {
        Task<Tovap> Tovap { get; }
    }
}
