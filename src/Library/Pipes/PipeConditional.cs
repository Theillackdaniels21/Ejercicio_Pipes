using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucu.Poo.PipesAndFilters;

namespace Ucu.Poo.PipesAndFilters.Pipes
{
    public class PipeConditional : IPipe
    {

        public IPipe NextPipe { get; protected set; }

        public IConditionalFilter Filter { get; protected set; }

        public IPipe NextPipeTrue { get; protected set; }
        public IPipe NextPipeFalse { get; protected set; }
        public PipeConditional(IConditionalFilter filter, IPipe nextPipe, IPipe nextPipeTrue, IPipe nextPipeFalse)
        {
            this.NextPipe = nextPipe;
            this.Filter = filter;
            this.NextPipeTrue = nextPipeTrue;
            this.NextPipeFalse = nextPipeFalse;
        }
        public IPicture Send(IPicture picture)
        {
            picture = this.Filter.Filter(picture);
            if (Filter.Result)
            {
                return this.NextPipeTrue.Send(picture);
            }
            else
            {
                return this.NextPipeFalse.Send(picture);
            }
        }
    }
}