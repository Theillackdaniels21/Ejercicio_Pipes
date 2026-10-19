using System;
using System.Drawing;

namespace Ucu.Poo.PipesAndFilters.Filters
{
    public class FilterSave : IFilter
    {
        private PictureProvider p;

        private string path;
        public FilterSave(string path)
        {
            this.p = new PictureProvider();
            this.path = path;
        }
        public IPicture Filter(IPicture image)
        {
            p.SavePicture(image, this.path);
            return image;
        }
    }

}