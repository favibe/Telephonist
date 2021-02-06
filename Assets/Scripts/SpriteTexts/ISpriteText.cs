using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteTexts
{
    public interface ISpriteText
    {
        public int Length { get; }
        public void Add(char c);
        public void Add(char c, int index);
        public void Remove(int index);
        public void CLear();
    }
}
