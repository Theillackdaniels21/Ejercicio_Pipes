using System;

namespace Ucu.Poo.PipesAndFilters
{
    public interface IConditionalFilter : IFilter
    {
        bool Result{ get;}
    }
}