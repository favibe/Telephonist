namespace Text
{
    interface ISpriteText
    {
        public int Length { get; }
        public void Add(char symbol);
        public void Remove(int index);
        public void Clear();
    }
}
